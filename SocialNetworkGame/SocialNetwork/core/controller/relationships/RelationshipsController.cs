using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using SocialNetwork.DTO;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.relationships.dto;
using SocialNetwork.core.services.relationships;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.players.domain;

namespace SocialNetwork.core.controller.relationships
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipsController : ControllerBase
    {
        private readonly RelationshipService _service;

        public RelationshipsController(RelationshipService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelationshipDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RelationshipDto>> GetGetById(Guid id)
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
                var con = await _service.AddAsync(dto);
                return CreatedAtAction(nameof(GetGetById), new {id = con.id}, con);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
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


        [HttpDelete("{id}")]
        public async Task<ActionResult<RelationshipDto>> SoftDelete(Guid id)
        {
            var cat = await _service.InactivateAsync(new RelationshipId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

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
                return BadRequest(new {Message = ex.Message});
            }
        }



    }
}