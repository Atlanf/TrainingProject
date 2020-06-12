using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IList<string>> GetUserRolesAsync(User user);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task<IdentityResult> AddRoleAsync(User user, string role);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByNameAsync(string name);
    }
}
