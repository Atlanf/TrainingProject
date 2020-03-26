using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface IUserRepository
    {
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateAsync(User userToUpdate);
        Task DeleteAsync(int id);
        Task<User> AddAsync(User user);
        Task<bool> IsUserExist(User user);
    }
}
