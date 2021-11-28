using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.core.services.tags;

namespace SocialNetwork.core.controller.tags
{
    public class TagsController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly TagsService _tagsService;

        public TagsController(IConfiguration config, TagsService tagsService)
        {
            _config = config;
            _tagsService = tagsService;
        }
    }
}
