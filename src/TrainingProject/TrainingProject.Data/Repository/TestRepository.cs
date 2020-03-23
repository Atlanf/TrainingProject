using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingProject.Domain;
using TrainingProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TrainingProject.Data.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _context;

        public TestRepository(AppDbContext context)
        {
            _context = context;
        }

        public Test Get(int id)
        {
            return _context.Tests.FirstOrDefault(test => test.Id == id);
        }

        public IEnumerable<Test> GetAll()
        {
            return _context.Tests.ToList();
        }

        public void Update(Test testToUpdate, int id)
        {
            if (_context.Tests.First(test => test.Id == id) != null)
            {
                _context.Tests.Update(testToUpdate);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var test = _context.Tests.Find(id);
            if (test != null)
            {
                test.IsDeleted = true;
                // _context.Tests.Remove(test);
                _context.SaveChanges();
            }
        }

        public void Add(Test test)
        {
            _context.Tests.Add(test);
            _context.SaveChanges();
        }

        public IEnumerable<Test> GetByCategory(Category category)
        {
            return _context.Tests.Where(c => c.Category.Id == category.Id);
        }
    }
}
