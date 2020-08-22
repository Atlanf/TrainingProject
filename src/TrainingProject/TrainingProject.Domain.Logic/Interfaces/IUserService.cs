using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models.User;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IUserService
    {
        public Task<ClaimsIdentity> LoginUser(LoginDTO user);

        public Task<RegisterResultDTO> RegisterUser(RegisterDTO user);

        Task<List<Claim>> GetListOfClaims(LoginDTO loginModel);

        Task<ProfileDTO> GetUserInfo(string userName);
    }
}
