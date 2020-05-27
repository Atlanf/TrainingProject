using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain;
using System.Linq;
using TrainingProject.Domain.Models;
using TrainingProject.Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrainingProject.Data.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly AppDbContext _context;

        public ResultRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result> AddResultAsync(Result result)
        {
            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();
            return result;
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
        
        public async Task<Result> GetResultAsync(string userId, int testId)
        {
            //return await _context.Results
            //    .Where(r => r.UserId)

            //return await _context.Results
            //    .Where(r => r.UserId == userId && r.TestId == testId && r.TestFinished)
            //    .LastOrDefaultAsync();

            return null;
        }
    }
}
