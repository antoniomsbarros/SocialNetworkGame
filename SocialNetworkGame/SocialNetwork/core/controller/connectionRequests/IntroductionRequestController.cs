using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.relationships.dto;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.relationships;
using SocialNetwork.core.services.connectionRequests;
using SocialNetwork.core.services.players;
using SocialNetwork.core.services.tags;
using SocialNetwork.core.model.tags.dto;
using SocialNetwork.core.model.tags.domain;

namespace SocialNetwork.core.controller.connectionRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroductionRequestController : ControllerBase
    {
        private readonly IntroductionRequestService _service;
        private readonly RelationshipService _relationshipService;
        private readonly PlayerService _playerService;
        private readonly TagsService _tagsService;

        public IntroductionRequestController(IntroductionRequestService service,
            RelationshipService relationshipService, PlayerService playerService, TagsService tagsService)
        {
            _relationshipService = relationshipService;
            _service = service;
            _playerService = playerService;
            _tagsService = tagsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntroductionRequestDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IntroductionRequestDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetById(string id)
        {
            var cat = await _service.GetByIdAsync(new ConnectionRequestId(id));

            if (cat == null)
            {
                return NotFound($"The request with id:{id} does not exist");
            }

            return Ok(cat);
        }

        
        [HttpPost]
        public async Task<ActionResult<IntroductionRequestDto>> CreateIntroductionRequest(
            CreateIntroductionRequestDto dto)
        {
            try
            {
                dto.PlayerIntroduction = _playerService.GetByEmailAsync(Email.ValueOf(dto.PlayerIntroduction)).Result.id;
                dto.PlayerReceiver = _playerService.GetByEmailAsync(Email.ValueOf(dto.PlayerReceiver)).Result.id;
                dto.PlayerSender = _playerService.GetByEmailAsync(Email.ValueOf(dto.PlayerSender)).Result.id;
                var tagsNameList = new List<string>(dto.Tags);

                var nTag = 0;
                while (nTag < dto.Tags.Count)
                {
                    var tag = _tagsService.GetByNameAsync(TagName.ValueOf(dto.Tags[nTag])).Result;
                    if (tag != null)
                        dto.Tags[nTag] = tag.id;
                    else
                    {
                        var newTag = _tagsService.AddAsync(new CreateTagDto(dto.Tags[nTag])).Result;
                        dto.Tags[nTag] = newTag.id;
                    }

                    ++nTag;
                }

                var introRequestDto = await _service.AddIntroduction(dto);
                introRequestDto.Tags = tagsNameList;

                return CreatedAtAction(nameof(CreateIntroductionRequest), introRequestDto);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }
        
        [HttpPut("playerIntroduction/{id}")]
        [ProducesResponseType(typeof(IEnumerable<IntroductionRequestDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateIntroductionStatus(string id,
            IntroductionRequestDto connectionIntroductionRelactionshipDto)
        {
            if (!id.Equals(connectionIntroductionRelactionshipDto.Id))
            {
                return NotFound($"id introction {id} and {connectionIntroductionRelactionshipDto.Id}");
            }
            PlayerDto playerSenderDto =  _playerService.GetByEmailAsync(new Email(connectionIntroductionRelactionshipDto.PlayerSender)).Result;
            PlayerDto playerReaceverDto =  _playerService.GetByEmailAsync(new Email(connectionIntroductionRelactionshipDto.PlayerReceiver)).Result;
            PlayerDto playerIntroductionDto =  _playerService.GetByEmailAsync(new Email(connectionIntroductionRelactionshipDto.PlayerIntroduction)).Result;
            if (playerSenderDto==null||playerReaceverDto==null|| playerIntroductionDto==null)
            {
                return StatusCode(409); 
            }
            
            
            IntroductionRequestDto introductionRequestDto =
                await _service.UpdateStatus(new UpdateIntroductionRequestStatus(id, connectionIntroductionRelactionshipDto.IntroductionStatus.ToString()));
            if (introductionRequestDto==null)
            {
                return NotFound("The introduction Request Dont exist");
            }
            
            if (introductionRequestDto.IntroductionStatus.Equals(ConnectionRequestStatusEnum.Approved))
            {
                if (checkifExistRelaction(playerSenderDto.email, playerIntroductionDto.email))
                {
                    return StatusCode(409);
                }
                var nTag = 0;
                while (nTag < connectionIntroductionRelactionshipDto.Tags.Count)
                {
                    var tag = _tagsService.GetByNameAsync(TagName.ValueOf(connectionIntroductionRelactionshipDto.Tags[nTag])).Result;
                    if (tag != null)
                        connectionIntroductionRelactionshipDto.Tags[nTag] = tag.id;
                    else
                    {
                        var newTag = _tagsService.AddAsync(new CreateTagDto(connectionIntroductionRelactionshipDto.Tags[nTag])).Result;
                        connectionIntroductionRelactionshipDto.Tags[nTag] = newTag.id;
                    }

                    ++nTag;
                }
                
                RelationshipPostDto relationshipDto1 = new RelationshipPostDto(
                    introductionRequestDto.PlayerSender, introductionRequestDto.PlayerIntroduction,
                    connectionIntroductionRelactionshipDto.ConnectionStrengthConf,
                    connectionIntroductionRelactionshipDto.Tags);
                
                RelationshipDto relationshipDtoIntroduction = await _relationshipService.AddAsync(relationshipDto1);
                
                RelationshipPostDto relationshipDto2 = new RelationshipPostDto(
                     introductionRequestDto.PlayerIntroduction,introductionRequestDto.PlayerSender,
                     introductionRequestDto.ConnectionStrengthConf,
                     introductionRequestDto.Tags);
                RelationshipDto relationshipDtoSender = await _relationshipService.AddAsync(relationshipDto2);
                if (relationshipDtoIntroduction==null || relationshipDtoSender==null)
                {
                    return StatusCode(500);
                }

                introductionRequestDto.PlayerIntroduction = playerIntroductionDto.email;
                introductionRequestDto.PlayerSender = playerSenderDto.email;
                introductionRequestDto.PlayerReceiver = playerReaceverDto.email;
                return Ok(introductionRequestDto);
            }
            introductionRequestDto.PlayerIntroduction = playerIntroductionDto.email;
            introductionRequestDto.PlayerSender = playerSenderDto.email;
            introductionRequestDto.PlayerReceiver = playerReaceverDto.email;
            return Ok(introductionRequestDto);

        }

        private bool checkifExistRelaction(string playerSender, string playerIntroduction)
        {
            List<PlayerEmailDto> list=   _relationshipService.GetRelationByEmail(playerSender).Result;
            if (list==null || list.Count==0)
            {
                return false;
            }

            foreach (var VARIABLE in list)
            {
                if (VARIABLE.Email.Equals(playerIntroduction))
                {
                    return true;
                }
            }

            return false;
        }


        [HttpGet("PlayerIntroduction={playerIntroduction}")]
        [ProducesResponseType(typeof(IEnumerable<IntroductionRequestDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPendingIntroductions(string playerIntroduction)
        {
            var introRequest = await _service.GetAllPendingIntroduction(playerIntroduction);

            if (introRequest == null)
            {
                return NotFound($"The Player does not exist");
            }

            if (introRequest.Count == 0)
            {
                return NotFound($"The Player does not have any pending introduction requests");
            }

            List<IntroductionRequestDto> list = new List<IntroductionRequestDto>();
            for (int i = 0; i < introRequest.Count; i++)
            {
                IntroductionRequestDto temp =new IntroductionRequestDto();
                temp.Id = introRequest[i].Id;
                temp.ConnectionRequestStatus = introRequest[i].ConnectionRequestStatus;
                temp.IntroductionStatus = introRequest[i].IntroductionStatus;
                temp.PlayerIntroduction = introRequest[i].PlayerIntroduction;
                temp.TextIntroduction = introRequest[i].TextIntroduction;
                temp.Text = introRequest[i].Text;
                temp.CreationDate = introRequest[i].CreationDate;
                temp.PlayerReceiver = introRequest[i].PlayerReceiver;
                temp.PlayerSender = introRequest[i].PlayerSender;
                temp.ConnectionStrengthConf = introRequest[i].ConnectionStrengthConf;
                temp.Tags = new List<string>();
                for (int j = 0; j < introRequest[i].Tags.Count; j++)
                {
                    TagDto dto1=await _tagsService.GetByIdAsync(new TagId( introRequest[i].Tags[j]));
                    temp.Tags.Add(dto1.name);
                }
                list.Add(temp);
            }

            return Ok(list);
        }
        
        [HttpGet("PlayerAproval={PlayerAproval}")]
        [ProducesResponseType(typeof(IEnumerable<IntroductionRequestDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPendingAprovolIntroductions(string PlayerAproval)
        {
            var introRequest = await _service.GetAllPendingApproval(new Email(PlayerAproval));

            if (introRequest == null)
            {
                return NotFound($"The Player does not exist");
            }

            if (introRequest.Count == 0)
            {
                return NotFound($"The Player does not have any pending introduction requests");
            }

            return Ok(introRequest);
        }
        

        [HttpPut("playerapproval/{idrequest}")]
        public async Task<IActionResult> UpdateIntroductionConnectionApproval(string idrequest,
            IntroductionRequestDto connectionIntroductionRelactionshipDto)
        {
            if (!idrequest.Equals(connectionIntroductionRelactionshipDto.Id))
            {
                return BadRequest();
            }
            try
            {
                var cat = await _service.UpdateConnectionStatus(new UpdateIntroductionRequestStatus(idrequest, connectionIntroductionRelactionshipDto.ConnectionRequestStatus.ToString()));
                
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
        
        

        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<IntroductionRequestDto>> HardDelete(string id)
        {
            try
            {
                var introRequest = await _service.DeleteAsync(id);
                if (introRequest == null)
                {
                    return NotFound("Could not delete the introduction Request");
                }

                return Ok(introRequest);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {ex.Message});
            }
        }
    }
}