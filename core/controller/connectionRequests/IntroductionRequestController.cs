﻿
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
        /// <summary>
        /// esta classe está me a dar problemas para conseguir enviar para o postman
        /// </summary>
        /* private IntroductionRequestRepository introductionRequestRepository;
        private ConnectionRequestRepository connectionRequestRepository;*/
        private readonly IntroductionRequestService _service;
        
        public IntroductionRequestController( IntroductionRequestService service/*, SocialNetworkDbContext context*/)
        {
           /* introductionRequestRepository = context.repositories().IntroductionRequest();
            connectionRequestRepository = context.repositories().ConnectionRequest();*/
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConnectionIntroductionDTO>>> GetAll()
        {
            /*List<IntroductionRequest> op = await Task.Run((() => this.introductionRequestRepository.FindAll()));
            List<ConnectionIntroductionDTO> requestDtos = new List<ConnectionIntroductionDTO>();
            op.ForEach(o=> requestDtos.Add(o.Dto()));
            return requestDtos;*/
            System.Diagnostics.Debug.WriteLine("stuff");
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
        public async Task<ActionResult<ConnectionIntroductionDTO>> GetGetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(new ConnectionRequestId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }
    }
}