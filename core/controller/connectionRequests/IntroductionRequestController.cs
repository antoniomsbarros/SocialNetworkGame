using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.infrastructure;
using Microsoft.AspNetCore.Cors;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.relationships;
using SocialNetwork.core.model.relationships.dto;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.connectionRequests;

namespace SocialNetwork.core.controller.connectionRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroductionRequestController : ControllerBase
    {
        private readonly IntroductionRequestService _service;
        private readonly RelationshipService _relationshipService;
        public IntroductionRequestController( IntroductionRequestService service,RelationshipService relationshipService )
        {
            _relationshipService = relationshipService;
                _service=service;
                
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConnectionIntroductionDTO>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConnectionIntroductionDTO), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGetById(string id)
        {
            var cat = await _service.GetByIdAsync(new ConnectionRequestId(id));

            if (cat == null)
            {
                return NotFound($"the request with id:{id} does not exist");
            }

            return Ok(cat);
        }


       [HttpPut("{id}")]
       [ProducesResponseType(typeof(IEnumerable<ConnectionIntroductionDTO>),200)]
       [ProducesResponseType(400)]
       public async Task<IActionResult> UpdateIntroductionStatus( string id,
           ConnectionIntroductionRelactionshipDTO connectionIntroductionRelactionshipDto)
       {
           if (!id.Equals(connectionIntroductionRelactionshipDto.Id))
           {
               return BadRequest($"id introction {id} and {connectionIntroductionRelactionshipDto.Id}");
           }

           try
           {
               
               ConnectionIntroductionDTO connectionIntroductionDto1 = new ConnectionIntroductionDTO(
                   connectionIntroductionRelactionshipDto.TextIntroduction,
                   connectionIntroductionRelactionshipDto.PlayerIntroduction,
                   connectionIntroductionRelactionshipDto.IntroductionStatus,
                   connectionIntroductionRelactionshipDto.Id,
                   connectionIntroductionRelactionshipDto.ConnectionRequestStatus,
                   connectionIntroductionRelactionshipDto.PlayerSender,
                   connectionIntroductionRelactionshipDto.PlayerReceiver,
                   connectionIntroductionRelactionshipDto.Text, connectionIntroductionRelactionshipDto.CreationDate,
                   connectionIntroductionRelactionshipDto.ConnectionStrenghtAproval,
                   connectionIntroductionRelactionshipDto.Tags);
               
               
               
               var cat = await _service.UpdateIntroductionStatus(connectionIntroductionDto1);
               if (connectionIntroductionRelactionshipDto.ConnectionStrenghtAproval>100 && 
                   connectionIntroductionRelactionshipDto.ConnectionStrenghtAproval<0)
               {
                   return NotFound($"The connection strenght's value must be between 0 and 100.");
               }

               ConnectionStrenght connectionStrenght =
                   new ConnectionStrenght(connectionIntroductionRelactionshipDto.ConnectionStrenghtAproval);
               
               if (cat==null)
               {
                   return NotFound($"could not change the introduction status");
               }
               if (connectionIntroductionRelactionshipDto.IntroductionStatus.Equals(ConnectionRequestStatusEnum.Approved.ToString()))
               {
                   var cat1 = await _service.GetByIdAsync(new ConnectionRequestId(connectionIntroductionDto1.Id));
                   RelationshipPostDto sender = new RelationshipPostDto(
                       
                       connectionIntroductionDto1.PlayerSender,connectionIntroductionDto1.PlayerIntroduction,
                       cat1.ConnectionStrenght,
                       cat1.Tags);
                   await _relationshipService.AddAsync(sender);
                   RelationshipPostDto introduction = new RelationshipPostDto(
                       connectionIntroductionDto1.PlayerIntroduction,
                       connectionIntroductionDto1.PlayerSender,
                       connectionIntroductionDto1.ConnectionStrenght,
                       connectionIntroductionDto1.Tags);
                   await _relationshipService.AddAsync(introduction);
                   return Ok(cat);
               }
               return NotFound("aqui");
           }
           catch (BusinessRuleValidationException exception)
           {
               return BadRequest(new {Message = exception.Message});
           }
       }
       
       
        [HttpGet("PlayerIntroduction={PlayerIntroduction}")]
        [ProducesResponseType(typeof(IEnumerable<ConnectionIntroductionDTO>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPendingIntroductions(Guid PlayerIntroduction)
        {
            var cat = await _service.GetAllPendingIntroduction(new PlayerId(PlayerIntroduction));
            if (cat.Count == 0)
            {
                return NotFound($"the Player does not have pending introduction");
            }

            return Ok(cat);
        }


    }
}