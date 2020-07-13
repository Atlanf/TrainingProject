using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Models.User;
using TrainingProject.Data.Models;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;

        private static UserInfo LoggedOutUser = new UserInfo { IsAuthenticated = false };

        public UserController(IUserService userService, SignInManager<User> signInManager, IConfiguration config)
        {
            _userService = userService;
            _signInManager = signInManager;
            _config = config;
        }

        [HttpGet("user")]
        public UserInfo GetUser()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                var result = new UserInfo();
                result.Name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                result.Role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                result.IsAuthenticated = User.Identity.IsAuthenticated;
                return result;
            }
            else
            {
                return LoggedOutUser;
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(LoginDTO loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false);

            if (!result.Succeeded)
            {
                return BadRequest(new LoginResultDTO() { Successful = false, Error = "Username or password are invalid." });
            }

            var claims = await _userService.GetListOfClaims(loginModel);
             
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_config["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _config["JwtIssuer"],
                _config["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResultDTO() 
            {
                Successful = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registrationModel)
        {
            var result = await _userService.RegisterUser(registrationModel);

            return Ok(result);
        }

        [HttpPost("signout")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("~/");
        }
    }
}