using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.core.model.players.application;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.systemUsers.domain;
using SocialNetwork.core.model.systemUsers.dto;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.model.tags.dto;
using SocialNetwork.core.services.players;
using SocialNetwork.core.services.systemUsers;
using SocialNetwork.core.services.tags;

namespace SocialNetwork.core.controller.players
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SystemUserService _systemUserService;
        private readonly PlayerService _playerService;
        private readonly TagsService _tagsService;

        public PlayersController(PlayerService playerService, SystemUserService systemUserService,
            IConfiguration config, TagsService tagsService)
        {
            _playerService = playerService;
            _systemUserService = systemUserService;
            _config = config;
            _tagsService = tagsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAll()
        {
            return await _playerService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDto>> GetById(Guid id)
        {
            var cat = await _playerService.GetByIdAsync(new PlayerId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpGet("email={email}")]
        public async Task<ActionResult<PlayerDto>> GetByEmail(string email)
        {
            var cat = await _playerService.GetByEmailAsync(Email.ValueOf(email));

            if (cat == null)
            {
                return NotFound();
            }

            for (int i = 0; i < cat.tags.Count; i++)
            {
                var tag = await _tagsService.GetByIdAsync(new TagId(cat.tags[i]));
                cat.tags[i] = tag.name;
            }

            return cat;
        }

        [HttpPost]
        public async Task<ActionResult<PlayerDto>> Create(RegisterUserAsPlayerDto dto)
        {
            try
            {
                await _systemUserService.AddAsyncWithoutSave(new SystemUserDto(dto.email,
                    dto.password), new PlayerPasswordPolicy(_config));

                var playerDto = await _playerService.AddAsyncWithoutSave(new RegisterPlayerDto(dto.email,
                    dto.phoneNumber, dto.facebookProfile, dto.linkedinProfile, dto.dateOfBirth,
                    dto.shortName, dto.fullName, dto.emotionalStatus));

                await _systemUserService.SaveChanges();
                await _playerService.SaveChanges();

                return CreatedAtAction(nameof(Create), new {playerDto.email}, playerDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new {ex.Message});
            }
        }

        [HttpPut("profile/{email}")]
        public async Task<ActionResult<UpdatePlayerDto>> UpdateProfile(string email, UpdatePlayerDto dto)
        {
            try
            {
                var tagsNameList = new List<string>(dto.tags);

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


                var player = await _playerService.UpdateAsync(dto);

                if (player == null)
                {
                    return NotFound();
                }

                player.tags = tagsNameList;
                return Ok(player);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {ex.Message});
            }
        }

        [HttpPut("humor/{id}")]
        public async Task<ActionResult<UpdateEmotionalStatusDto>> ChangeEmotionalStatus(Guid id,
            UpdateEmotionalStatusDto dto)
        {
            if (!id.Equals(Guid.Parse(dto.id)))
            {
                return BadRequest();
            }

            try
            {
                var player =
                    await _playerService.ChangeEmotionalStatus(dto);

                if (player == null)
                {
                    return NotFound();
                }

                return Ok(player);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {ex.Message});
            }
        }


        // For tests
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<PlayerDto>> HardDelete(string id)
        {
            try
            {
                var cat = await _playerService.DeleteAsync(new PlayerId(id));

                if (cat == null)
                {
                    return NotFound();
                }

                await _systemUserService.DeleteAsync(new Username(cat.email));

                return Ok(cat);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {ex.Message});
            }
        }

        [HttpGet("Tags/{email}")]
        public async Task<ActionResult<IEnumerable<TagDto>>> GetAllTagsofPLayer(string email)
        {
            try
            {
                var cat = await _playerService.GetByEmailAsync(new Email(email));
                List<TagDto> result = new List<TagDto>();
                foreach (var catTag in cat.tags)
                {
                    result.Add(_tagsService.GetByIdAsync(new TagId(catTag)).Result);
                }

                return Ok(result);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {ex.Message});
            }
        }
    }
}