using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.relationships.dto;
using SocialNetwork.core.services.relationships;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.model.tags.dto;
using SocialNetwork.core.services.tags;

namespace SocialNetwork.core.controller.relationships
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipsController : ControllerBase
    {
        private readonly RelationshipService _service;
        private readonly TagsService _tagsService;


        public RelationshipsController(RelationshipService service, TagsService tagsService)
        {
            _service = service;
            _tagsService = tagsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelationshipDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RelationshipDto>> GetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(new RelationshipId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpGet("friends/{email}")]
        public async Task<ActionResult<List<PlayerEmailDto>>> GetFriendsByEmail(string email)
        {
            return await _service.GetRelationByEmail(email);
        }

        [HttpGet("{email}/friends/friends")]
        public async Task<ActionResult<List<PlayerFriendsDTO>>> GetFriends(string email)
        {
            if (email.Length == 0)
            {
                return BadRequest();
            }

            return await _service.GetFriends(new Email(email));
        }

        [HttpGet("network/{email}/{depth}")]
        public async Task<ActionResult<NetworkFromPlayerPerspectiveDto>> GetNetwork(string email, int depth)
        {
            if (depth < 0 || email == null)
            {
                return BadRequest();
            }

            return await _service.GetNetworkAtDepthByEmail(Email.ValueOf(email), depth);
        }

        [HttpPost]
        public async Task<ActionResult<RelationshipDto>> Create(RelationshipPostDto dto)
        {
            try
            {
                var nTag = 0;
                while (nTag < dto.tags.Count)
                {
                    var tag = _tagsService.GetByNameAsync(TagName.ValueOf(dto.tags[nTag])).Result;
                    if (tag != null)
                        dto.tags[nTag] = tag.id;
                    else
                    {
                        var newTag = _tagsService.AddAsync(new CreateTagDto(dto.tags[nTag])).Result;
                        dto.tags[nTag] = newTag.id;
                    }

                    ++nTag;
                }

                var con = await _service.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new {con.id}, con);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RelationshipDto>> Update(string id, RelationshipDto dto)
        {
            if (id != dto.id)
            {
                return BadRequest();
            }

            try
            {
                var cat = await _service.UpdateAsync(dto);

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(cat);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        [HttpPut]
        public async Task<ActionResult<RelationshipDto>> Update(RelationshipDto dto)
        {
            try
            {
                var cat = await _service.ChangeRelationshipTagConnectionStrength(dto);

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(cat);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {ex.Message});
            }
        }


        // For testing
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<RelationshipDto>> HardDelete(string id)
        {
            try
            {
                var cat = await _service.DeleteAsync(new RelationshipId(id));

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(cat);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {ex.Message});
            }
        }

        //Put: api/EditTagConnectionStrength/id
        [HttpPut("{id}")]
        public async Task<ActionResult<RelationshipDto>> ChangeRelationshipTag(Guid id, RelationshipDto dto)
        {
            if (!id.Equals(Guid.Parse(dto.id)))
            {
                return BadRequest();
            }

            try
            {
                var relationship2 = await _service.ChangeRelationshipTagConnectionStrength(dto);

                if (relationship2 == null)
                {
                    return NotFound();
                }

                return Ok(relationship2);
            }

            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {ex.Message});
            }
        }
    }
}