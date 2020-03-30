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

        public Task<User> AddAsync(User user)
        {
            throw new NotImplementedException();
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

        //public async Task<IdentityUser> AddAsync(User user)
        //{
        //    //await _context.Users.AddAsync(user);
        //    //await _context.SaveChangesAsync();
        //    //return user;
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user != null)
        //    {
        //        user.IsDeleted = true;
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<IEnumerable<User>> GetAllAsync()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        //public async Task<User> GetAsync(int id)
        //{
        //    return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        //}

        //public async Task<bool> IsUserExist(User user)
        //{
        //    return await _context.Users.AnyAsync(u => u.UserName == user.UserName);
        //}

        //public async Task<User> UpdateAsync(User userToUpdate)
        //{
        //    _context.Entry(userToUpdate).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return userToUpdate;
        //}
    }
}
