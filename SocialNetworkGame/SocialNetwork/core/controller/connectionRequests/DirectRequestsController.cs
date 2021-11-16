using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.connectionRequests.dto;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.connectionRequests;
using SocialNetwork.core.services.players;

namespace SocialNetwork.core.controller.connectionRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectRequestsController : ControllerBase
    {
        private readonly DirectRequestService _service;
        private readonly PlayerService _playerService;

        public DirectRequestsController(DirectRequestService service, PlayerService playerService)
        {
            _service = service;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectRequestDTO>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<DirectRequestDTO>> Create(CreateDirectRequestDto
            createDirectRequestDto)
        {
            try
            {
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
    }
}