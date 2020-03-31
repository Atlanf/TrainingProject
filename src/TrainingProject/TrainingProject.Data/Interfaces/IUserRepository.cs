using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateAsync(User userToUpdate);
        Task DeleteAsync(int id);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task<IdentityResult> AddRoleAsync(User user, string role);
        Task<bool> IsUserExist(User user);
    }
}
