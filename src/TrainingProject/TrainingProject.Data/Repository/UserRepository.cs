using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain;
using TrainingProject.Domain.Models;
using TrainingProject.Data.Interfaces;

namespace TrainingProject.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IList<string>> GetUserRolesAsync(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> AddRoleAsync(User user, string role)
        {
             return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserExist(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User userToUpdate)
        {
            throw new NotImplementedException();
        }


    }
}
