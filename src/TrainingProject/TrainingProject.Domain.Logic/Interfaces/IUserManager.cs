using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models.User;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IUserManager
    {
        public Task<IdentityResult> LoginUser(LoginDTO user);

        public Task<IdentityResult> RegisterUser(RegistrationDTO user);
       
    }
}
