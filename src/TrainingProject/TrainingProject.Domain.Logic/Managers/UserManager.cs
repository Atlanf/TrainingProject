using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.User;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain.Logic.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserManager(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IdentityResult> LoginUser(LoginDTO user)
        {
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> RegisterUser(RegistrationDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _userRepository.AddUserAsync(user, userDto.Password);
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
