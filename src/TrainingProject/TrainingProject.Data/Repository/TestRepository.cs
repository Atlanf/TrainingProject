using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingProject.Domain;
using TrainingProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TrainingProject.Data.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _context;

        public TestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Test> GetAsync(int id)
        {
            return await _context.Tests.FirstOrDefaultAsync(test => test.Id == id);
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            return await _context.Tests.ToListAsync();
        }

        public async Task<Test> UpdateAsync(Test testToUpdate)
        {
            _context.Entry(testToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return testToUpdate;
        }

        public async Task DeleteAsync(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test != null)
            {
                test.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Test> AddAsync(Test test)
        {
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public IEnumerable<Test> GetByCategory(Category category)
        {
            return _context.Tests.Where(c => c.Category.Id == category.Id);
        }
    }
}
