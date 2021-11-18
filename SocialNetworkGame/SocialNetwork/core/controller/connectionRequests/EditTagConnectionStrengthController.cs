﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SocialNetwork.core.model.shared;
using SocialNetwork.core.services.relationships;

using SocialNetwork.DTO;

namespace SocialNetwork.core.controller.connectionRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditTagConnectionStrengthController : ControllerBase
    {
        private readonly RelationshipService _relationshipService;

        public EditTagConnectionStrengthController( RelationshipService service) => _relationshipService = service;

        //Put: api/EditTagConnectionStrength/id
        [HttpPut("{id}/{newTag}/{conStrength}")]

        public async Task<ActionResult<RelationshipDto>> ChangeRelationshipTag(string id, List<String> newTag, int conStrength)
        {
            try
            {
                var relationship2 = await _relationshipService.ChangeRelationshipTagConnectionStrength(id, newTag, conStrength);
                if(relationship2 ==null)
                {
                    return NotFound();
                }

                return Ok(relationship2);
            }
        catch (BusinessRuleValidationException ex)
        {
            return BadRequest(new {ex.Message});
        }

        }
    }
}