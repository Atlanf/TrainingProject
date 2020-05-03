﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.User;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain.Logic.Services
{
    public class UserService : IUserService
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
            var roles = await _userRepository.GetUserRolesAsync(user);

            if (user != null && await _userManager.CheckPasswordAsync(user, userModel.Password))
            {
                var claims = GetClaims(user, roles);
                var id = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme, user.UserName, roles.FirstOrDefault());

                return id;
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

        private List<Claim> GetClaims(User user, IList<string> roles)
        {
            return new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                };
        }
    }
}
