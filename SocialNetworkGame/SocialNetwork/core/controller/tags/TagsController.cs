using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.core.model.tags.dto;
using SocialNetwork.core.services.tags;

namespace SocialNetwork.core.controller.tags
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly TagsService _tagsService;

        public TagsController(IConfiguration config, TagsService tagsService)
        {
            _config = config;
            _tagsService = tagsService;
        }
        [HttpGet("all/")]
        public async Task<ActionResult<IEnumerable<TagDto>>> GetAll()
        {
            var tags=  await _tagsService.GetAllAsync();
              return tags;
        }
    }
}
