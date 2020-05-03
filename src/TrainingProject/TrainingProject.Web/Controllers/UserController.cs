using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.User;
using TrainingProject.Domain.Models;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private static UserInfo LoggedOutUser = new UserInfo { IsAuthenticated = false };

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user")]
        public UserInfo GetUser()
        {
            return User.Identity.IsAuthenticated
                ? new UserInfo
                {
                    Name = User.Identity.Name,
                    IsAuthenticated = User.Identity.IsAuthenticated,
                    Role = User.Claims.FirstOrDefault(c => c.Type == "Role").Value
                }
                : LoggedOutUser;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(LoginDTO loginModel)
        {
            var claims = await _userService.LoginUser(loginModel);

            if (claims.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(claims));
            }

            return Ok();
            //return Redirect(loginModel.RedirectUri);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDTO registrationModel)
        {


            return Redirect(registrationModel.RedirectUri);
        }

        [HttpPost("signout")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("~/");
        }
    }
}