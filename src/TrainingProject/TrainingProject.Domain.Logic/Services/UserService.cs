using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.User;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain.Logic.Services
{
    public class UserService : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, IUserRepository userRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<ClaimsIdentity> LoginUser(LoginDTO userModel)
        {
            var user = await _userRepository.GetUserByEmailAsync(userModel.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, userModel.Password))
            {
                var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                return identity;               
            }
            else
            {
                return new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            }
        }

        public async Task<IdentityResult> RegisterUser(RegistrationDTO userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var result = await _userRepository.AddUserAsync(user, userModel.Password);
            if (result.Succeeded)
            {
                return await _userRepository.AddRoleAsync(user, "Visitor");
            }
            else
            {
                return result;
            }
        }
    }
}
