using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain;
using System.Linq;
using TrainingProject.Domain.Models;
using TrainingProject.Data.Interfaces;

namespace TrainingProject.Data.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly AppDbContext _context;

        public ResultRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Result result)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Result Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Result> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Result> GetByTest(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Result> GetByUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Result resultToUpdate, int id)
        {
            throw new NotImplementedException();
        }
    }
}
