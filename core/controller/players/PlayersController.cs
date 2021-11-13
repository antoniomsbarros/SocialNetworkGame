﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.players.application;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.model.systemUsers.dto;
using SocialNetwork.core.services.players;
using SocialNetwork.core.services.systemUsers;

namespace SocialNetwork.core.controller.players
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly SystemUserService _systemUserService;
        private readonly PlayerService _userService;

        public PlayersController(PlayerService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDto>> GetById([FromQuery] Guid id)
        {
            var cat = await _userService.GetByIdAsync(new PlayerId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<PlayerDto>> GetByEmail([FromQuery] string email)
        {
            var cat = await _userService.GetByEmailAsync(Email.ValueOf(email));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpPost]
        public async Task<ActionResult<PlayerDto>> Create(RegisterUserAsPlayerDto dto) //TODO To test
        {
            try
            {
                var user = await _systemUserService.AddAsync(new SystemUserDto(dto.email,
                    dto.password), new PlayerPasswordPolicy());

                var con = await _userService.AddAsync(new RegisterPlayerDto(dto.email,
                    dto.phoneNumber, dto.facebookProfile, dto.linkedinProfile, dto.dateOfBirth,
                    dto.shortName, dto.fullName, dto.emotionalStatus));

                return CreatedAtAction(nameof(Create), new {email = con.email}, con);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

/* 
        [HttpPut("{id}")]
        public async Task<ActionResult<PlayerDto>> Update(string id, PlayerDto dto)
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
        public async Task<ActionResult<PlayerDto>> SoftDelete(Guid id)
        {
            var cat = await _service.InactivateAsync(new RelationshipId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<PlayerDto>> HardDelete(string id)
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
        */
    }
}