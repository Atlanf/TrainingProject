using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain;
using System.Linq;
using TrainingProject.Data.Models;
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
        
        public async Task<Result> GetBestResultAsync(string userId, int testId)
        {
            return await _context.Results
                .Where(r => r.UserId == userId && r.TestId == testId)
                .OrderByDescending(r => r.CorrectAnswers)
                .ThenByDescending(r => r.DateFinished)
                .FirstOrDefaultAsync();
        }

        public async Task<Result> GetResultAsync(string userId, int testId)
        {
            return await _context.Results
                .Where(r => r.UserId == userId && r.TestId == testId )
                .OrderByDescending(r => r.CorrectAnswers)
                .ThenByDescending(r => r.DateFinished)
                .FirstOrDefaultAsync();
        }

        public async Task<Result> GetLastResultAsync(string userId, int testId)
        {
            return await _context.Results
                .Where(r => r.UserId == userId && r.TestId == testId)
                .OrderByDescending(r => r.DateFinished)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Result>> GetFinishedUserResultsAsync(string userId)
        {
            return await _context.Results
                .Where(r => r.UserId == userId && r.TestFinished)
                .OrderByDescending(r => r.DateFinished)
                .Include(r => r.Test)
                .ToListAsync();
        }

        public async Task<List<Result>> GetUserResultsAsync(string userId, bool finishedOnly)
        {
            var result = await _context.Results
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.DateFinished)
                .Include(r => r.Test)
                .ToListAsync();

            if (finishedOnly)
            {
                result.RemoveAll(r => !r.TestFinished);
            }

            return result;
        }

        public async Task<List<Result>> GetResultsByBestAsync(string userId)
        {
            return await _context.Results
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.CorrectAnswers)
                .Include(r => r.Test)
                .ToListAsync();
        }
    }
}
