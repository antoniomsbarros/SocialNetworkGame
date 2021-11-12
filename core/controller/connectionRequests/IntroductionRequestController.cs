
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.connectionRequests.domain;
using SocialNetwork.core.model.connectionRequests.repository;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.posts.application;
using SocialNetwork.infrastructure;
using Microsoft.AspNetCore.Cors;

namespace SocialNetwork.core.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroductionRequestController : ControllerBase
    {
        
        private readonly IntroductionRequestService _service;
        
        public IntroductionRequestController( IntroductionRequestService service)
        {
           
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConnectionIntroductionDTO>>> GetAll()
        {
            return await _service.GetAllAsync();
        }
        
        /*[HttpGet("PlayerIntroduction={PlayerIntroduction}")]
        public async Task<ActionResult<IEnumerable<ConnectionIntroductionDTO>>> GetAllPendingIntroductions(string playerId)
        {
            try
            {
                PlayerId playerId1 = new PlayerId(playerId);
                List<IntroductionRequest> op = await Task.Run((() => this.introductionRequestRepository.FindbyPlayerIntroductionIdThatAreOnHold(playerId1)));
                List<ConnectionIntroductionDTO> requestDtos = new List<ConnectionIntroductionDTO>();
                op.ForEach(o=> requestDtos.Add(o.Dto()));
                return requestDtos;
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }*/
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConnectionIntroductionDTO),200)]
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
        
       
       [HttpGet("PlayerIntroduction={PlayerIntroduction}")]
       [ProducesResponseType(typeof(ConnectionIntroductionDTO),200)]
       [ProducesResponseType(400)]
       public  async Task<ActionResult<IEnumerable<ConnectionIntroductionDTO>>> GetPendingIntroductions(Guid PlayerIntroduction)
       {
           return await _service.GetAllPendingIntroduction(new PlayerId(PlayerIntroduction));
       }
       
       
    }
}