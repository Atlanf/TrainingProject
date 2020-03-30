﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.User;

namespace TrainingProject.Domain.Logic.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;

        public UserManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<bool> LoginUser(LoginDTO user)
        {
            return true;
        }

        public Task<bool> RegisterUser(RegisterDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
