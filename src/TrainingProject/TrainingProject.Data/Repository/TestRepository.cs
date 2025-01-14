﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingProject.Domain;
using TrainingProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;

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
            return _context.Tests
                .Where(c => c.Category.Id == category.Id);
        }

        public int GetMaxQuestions(int testId)
        {
            return _context.Tests
                .Where(t => t.Id == testId)
                .Select(m => m.MaxQuestions)
                .FirstOrDefault();
        }

        public async Task<ICollection<Category>> GetTestsWithCategoryAsync()
        {
            return await _context.Categories
                .Where(c => c.IsDeleted == false)
                .Include(t => t.Tests)
                .ToListAsync();
        }

        public async Task<Test> GetTestDetailsAsync(string shortName)
        {
            return await _context.Tests
                .Where(t => t.MinimizedName == shortName)
                .FirstOrDefaultAsync();
        }

        public async Task<string> GetTestNameAsync(string testName, string shortName)
        {
            return await _context.Tests
                .Where(t => t.Name == testName || t.MinimizedName == shortName)
                .Select(n => n.Name)
                .FirstOrDefaultAsync();
        }

        public async Task<string> GetTestMinimizedNameAsync(int testId)
        {
            return await _context.Tests
                .Where(t => t.Id == testId)
                .Select(t => t.MinimizedName)
                .FirstOrDefaultAsync();
        }
    }
}
