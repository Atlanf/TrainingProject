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
        private AppDbContext _context { get; set; }

        public TestRepository(AppDbContext context)
        {
            _context = context;
        }

        public Test GetById(int id)
        {
            return _context.Tests.FirstOrDefault(test => test.Id == id);
        }

        public IEnumerable<Test> GetAll()
        {
            return _context.Tests.ToList();
        }

        public void UpdateTest(Test testToUpdate, int id)
        {
            if (_context.Tests.First(test => test.Id == id) != null)
            {
                _context.Tests.Update(testToUpdate);
                _context.SaveChanges();
            }
        }

        public void DeleteTest(int id)
        {
            var test = _context.Tests.Find(id);
            if (test != null)
            {
                _context.Tests.Remove(test);
                _context.SaveChanges();
            }
        }

        public Test AddTest(Test test)
        {
            if (test != null)
            {
                _context.Tests.Add(test);
                _context.SaveChanges();
                return test;
            }
            else
            {
                return null;
            }
        }
    }
}
