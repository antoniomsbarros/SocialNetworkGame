using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork.core.model.systemUsers.domain;
using SocialNetwork.core.model.systemUsers.dto;
using SocialNetwork.core.services.systemUsers;

namespace SocialNetwork.core.controller.systemUsers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUsersController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SystemUserService _systemUserService;

        public SystemUsersController(IConfiguration config, SystemUserService systemUserService)
        {
            _config = config;
            _systemUserService = systemUserService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> AuthenticateSystemUser(AuthenticateSystemUserDto dto)
        {
            if (!await _systemUserService.Authenticate(Username.ValueOf(dto.username), Password.ValueOf(dto.password)))
                return Unauthorized();

            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, dto.username),
            };

            var identity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), new AuthenticationProperties()).Wait();

            return Ok();
        }
    }
}