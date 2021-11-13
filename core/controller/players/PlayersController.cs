using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.players.dto;
using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.players;

namespace SocialNetwork.core.controller.players
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _service;

        public PlayersController(PlayerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDto>> GetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(new PlayerId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<PlayerDto>> GetByEmail(string email)
        {
            var cat = await _service.GetByEmailAsync(Email.ValueOf(email));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpPost]
        public async Task<ActionResult<PlayerDto>> Create(RegisterPlayerDto dto) //TODO To test
        {
            try
            {
                var con = await _service.AddAsync(dto);
                return CreatedAtAction(nameof(GetByEmail), new {email = con.email}, con);
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