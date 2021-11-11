using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using lapr5_3dg.Services;
using SocialNetwork.DTO;
using lapr5_3dg.DTO;
using lapr5_3dg.infrastructure.relationships;
using SocialNetwork.core.model.relationships.domain;
using SocialNetwork.core.model.shared;

namespace LEI_21s5_3dg_41.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipsController : ControllerBase
    {
        private readonly RelationshipService _service;

        public RelationshipsController(RelationshipService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelationshipDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RelationshipDto>> GetGetById(Guid id)
        {
            var cat = await _service.GetByIdAsync(new RelationshipId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        [HttpPost]
        public async Task<ActionResult<RelationshipDto>> Create(RelationshipDto dto)
        {
            var cat = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), cat);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<RelationshipDto>> Update(Guid id, RelationshipDto dto)
        {
            if (id.ToString() != dto.id)
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
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        /*
        [HttpDelete("{id}")]
        public async Task<ActionResult<RelationshipDto>> SoftDelete(Guid id)
        {
            var cat = await _service.InactivateAsync(new RelationshipId(id));

            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }*/
        
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<RelationshipDto>> HardDelete(Guid id)
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
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }

    }
}