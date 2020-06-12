using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Domain.Models.User;

namespace TrainingProject.Client.Helpers
{
    public interface IAuthService
    {
        Task<LoginResultDTO> Login(LoginDTO loginModel);
        Task Logout();
        Task<RegisterResultDTO> Register(RegisterDTO registerModel);
    }
}
