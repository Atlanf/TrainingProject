using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain;
using TrainingProject.Domain.Logic.Models.User;
using TrainingProject.Domain.Models;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IChoiceRepository _choiceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public HomeController(IMapper mapper, IUserRepository userRepository, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var result = await _questionRepository.GetAsync(id);
            return Ok();
        }

        [HttpPost("Login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO userModel)
        {
            var u = new Domain.Logic.Services.UserService(_mapper, _userRepository, _userManager);

            var claims = await u.LoginUser(userModel);

            if (claims.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                    new ClaimsPrincipal(claims));
            }

            return Ok(claims.Name);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationDTO userModel)
        {
            var u = new Domain.Logic.Services.UserService(_mapper, _userRepository, _userManager);

            var i = await u.RegisterUser(userModel);

            return Ok();
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return Ok();
        }
    }
}