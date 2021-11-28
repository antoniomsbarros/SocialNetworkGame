using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.relationships;
using SocialNetwork.core.services.connectionRequests;
using SocialNetwork.core.services.players;

namespace SocialNetwork.core.controller.connectionRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroductionRequestController : ControllerBase
    {
        private readonly IntroductionRequestService _service;
        private readonly RelationshipService _relationshipService;
        private readonly PlayerService _playerService;

        public IntroductionRequestController(IntroductionRequestService service,
            RelationshipService relationshipService, PlayerService playerService)
        {
            _relationshipService = relationshipService;
            _service = service;
            _playerService = playerService;
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

        /*
        
        [HttpPost]
        public async Task<ActionResult<ConnectionIntroductionDTO>> CreateIntroductionRequest(
            CreateConnectionIntroductionDTO infoReceived)
        {
            try
            {
                infoReceived.PlayerIntroduction = _playerService.GetByEmailAsync(Email.ValueOf(infoReceived.PlayerIntroduction)).Result.id;
                infoReceived.PlayerReceiver = _playerService.GetByEmailAsync(Email.ValueOf(infoReceived.PlayerReceiver)).Result.id;
                infoReceived.PlayerSender = _playerService.GetByEmailAsync(Email.ValueOf(infoReceived.PlayerSender)).Result.id;
                var opt = await _service.AddIntroduction(infoReceived);

                return CreatedAtAction(nameof(CreateIntroductionRequest), opt);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ConnectionIntroductionDTO>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateIntroductionStatus(string id,
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

                if (connectionIntroductionRelactionshipDto.ConnectionStrenghtAproval > 100 &&
                    connectionIntroductionRelactionshipDto.ConnectionStrenghtAproval < 0)
                {
                    return NotFound($"The connection strenght's value must be between 0 and 100.");
                }

                PlayerDto playersender =
                    _playerService.GetByEmailAsync(new Email(connectionIntroductionRelactionshipDto.PlayerSender))
                        .Result;
                PlayerDto pLayerIntroduction = _playerService.GetByEmailAsync(
                    new Email(connectionIntroductionRelactionshipDto.PlayerIntroduction)).Result;
                PlayerDto playerRecever = _playerService.GetByEmailAsync(
                    new Email(connectionIntroductionRelactionshipDto.PlayerReceiver)).Result;
                if (playersender == null || pLayerIntroduction == null || playerRecever == null)
                {
                    return NotFound("The player sender dont exist");
                }

                connectionIntroductionDto1.PlayerIntroduction = pLayerIntroduction.id;
                connectionIntroductionDto1.PlayerSender = playersender.id;
                connectionIntroductionDto1.PlayerReceiver = playerRecever.id;
                ConnectionStrength otherConnectionStrength =
                    new ConnectionStrength(connectionIntroductionRelactionshipDto.ConnectionStrenghtAproval);
                var cat = await _service.UpdateIntroductionStatus(connectionIntroductionDto1);
                if (cat == null)
                {
                    return NotFound($"could not change the introduction status," +
                                    connectionIntroductionDto1.PlayerSender);
                }

                if (connectionIntroductionRelactionshipDto.IntroductionStatus.Equals(ConnectionRequestStatusEnum
                    .Approved.ToString()))
                {
                    var cat1 = await _service.GetByIdAsync(new ConnectionRequestId(connectionIntroductionDto1.Id));


                    var relactionIntroduction =
                        _relationshipService.GetRelationByEmail(pLayerIntroduction.email);
                    foreach (var playerEmailDto in relactionIntroduction.Result)
                    {
                        if (playerEmailDto.Email.Equals(playersender.email))
                        {
                            return NotFound("the players have direct connection");
                        }
                    }

                    RelationshipPostDto sender = new RelationshipPostDto(
                        playersender.id, pLayerIntroduction.id,
                        cat1.ConnectionStrength,
                        cat1.Tags);
                    var relationshiptemp1 = await _relationshipService.AddAsync(sender);
                    if (relationshiptemp1 == null)
                    {
                        return NotFound("Could not create the relationship ");
                    }

                    RelationshipPostDto introduction = new RelationshipPostDto(
                        pLayerIntroduction.id, playersender.id,
                        connectionIntroductionDto1.ConnectionStrength,
                        connectionIntroductionDto1.Tags);
                    var relationshiptemp2 = await _relationshipService.AddAsync(introduction);
                    if (relationshiptemp2 == null)
                    {
                        return NotFound("Could not create the relationship ");
                    }

                    cat.PlayerIntroduction = pLayerIntroduction.email;
                    cat.PlayerSender = playersender.email;
                    cat.PlayerReceiver = playerRecever.email;
                    return Ok(cat);
                }

                return NotFound("");
            }
            catch (BusinessRuleValidationException exception)
            {
                return BadRequest(new {Message = exception.Message});
            }
        }
*/

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

            return Ok(introRequest);
        }


        /*

        [HttpPut("/playerapproval/{idrequest}")]
        public async Task<IActionResult> UpdateIntroductionConnection(string idrequest,
            ConnectionIntroductionDTO connectionIntroductionRelactionshipDto)
        {
            if (!idrequest.Equals(connectionIntroductionRelactionshipDto.Id))
            {
                return BadRequest();
            }
            try
            {
                var cat = await _service.UpdateIntroductionStatus(connectionIntroductionRelactionshipDto);
                
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
        */


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