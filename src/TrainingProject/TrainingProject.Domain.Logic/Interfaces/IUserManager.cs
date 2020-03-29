using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models.User;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IUserManager
    {
        public Task<bool> LoginUser(LoginDTO user);

        public Task<bool> RegisterUser(RegisterDTO user);
       
    }
}
