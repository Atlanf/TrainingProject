using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain;
using System.Linq;
using TrainingProject.Domain.Models;

namespace TrainingProject.Data.Repository
{
    public class TestResultRepository : ITestResultRepository
    {
        private readonly AppDbContext _context;

        public TestResultRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TestResult result)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TestResult Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestResult> GetByTest(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestResult> GetByUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TestResult resultToUpdate, int id)
        {
            throw new NotImplementedException();
        }
    }
}
