using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.tags.domain;
using SocialNetwork.core.model.tags.dto;
using SocialNetwork.core.services.connectionRequests;
using SocialNetwork.core.services.players;
using SocialNetwork.core.services.tags;

namespace SocialNetwork.core.controller.connectionRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectRequestsController : ControllerBase
    {
        private readonly DirectRequestService _service;
        private readonly PlayerService _playerService;
        private readonly TagsService _tagsService;

        public DirectRequestsController(DirectRequestService service, PlayerService playerService, TagsService tagsService)
        {
            _service = service;
            _playerService = playerService;
            _tagsService = tagsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectRequestDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }


        [HttpGet("player={player}")]
        public async Task<IActionResult> GetPendingRequests(string player)
        {
            var directRequestDtos = await _service.GetPendingRequests(player);

            if (directRequestDtos == null)
            {
                return NotFound($"The Player does not exist");
            }

            if (directRequestDtos.Count == 0)
            {
                return NotFound($"The Player does not have any pending introduction request");
            }

            List<DirectRequestDto> list = new List<DirectRequestDto>();
            for (int i = 0; i < directRequestDtos.Count; i++)
            {
                var tempTags = new List<string>();
                for (int j = 0; j < directRequestDtos[i].Tags.Count; j++)
                {
                    TagDto dto1=await _tagsService.GetByIdAsync(new TagId(directRequestDtos[i].Tags[j]));
                    tempTags.Add(dto1.name);
                }
                DirectRequestDto temp = new DirectRequestDto(directRequestDtos[i].Id, directRequestDtos[i].ConnectionRequestStatus,
                    directRequestDtos[i].PlayerSender, directRequestDtos[i].PlayerReceiver, directRequestDtos[i].Text,
                    directRequestDtos[i].CreationDate, directRequestDtos[i].ConnectionStrengthConf, tempTags);
                list.Add(temp);
            }

            return Ok(list);
        }

        
        
        
        [HttpPost]
        public async Task<ActionResult<DirectRequestDto>> Create(CreateDirectRequestDto
            createDirectRequestDto)
        {
            try
            {
                
                var nTag = 0;
                while (nTag < createDirectRequestDto.Tags.Count)
                {
                    var tag = _tagsService.GetByNameAsync(TagName.ValueOf(createDirectRequestDto.Tags[nTag])).Result;
                    if (tag != null)
                        createDirectRequestDto.Tags[nTag] = tag.id;
                    else
                    {
                        var newTag = _tagsService.AddAsync(new CreateTagDto(createDirectRequestDto.Tags[nTag])).Result;
                        createDirectRequestDto.Tags[nTag] = newTag.id;
                    }
                    ++nTag;
                }
                
                
                createDirectRequestDto.PlayerReceiver =
                    _playerService.GetByEmailAsync(Email.ValueOf(createDirectRequestDto.PlayerReceiver)).Result.id;

                createDirectRequestDto.PlayerSender =
                    _playerService.GetByEmailAsync(Email.ValueOf(createDirectRequestDto.PlayerSender)).Result.id;

                var con = await _service.AddAsync(createDirectRequestDto);

                return CreatedAtAction(nameof(Create), con);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }
        
        
        [HttpPut]
        public async Task<IActionResult> UpdateDirectRequest(DirectRequestDto directRequestDto)
        {
            try
            {
                var cat = await _service.UpdateRequestStatus(
                    new UpdateDirectRequestStatus(directRequestDto.Id, 
                        directRequestDto.ConnectionRequestStatus.ToString(),
                        directRequestDto.PlayerReceiver,
                        directRequestDto.PlayerSender,
                        directRequestDto.Tags));
                if (cat == null)
                {
                    return NotFound();
                }
                return Ok(cat);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }
        
    }
}