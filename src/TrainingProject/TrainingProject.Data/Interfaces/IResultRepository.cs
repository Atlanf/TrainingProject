using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface IResultRepository
    {
        Task<Result> AddResultAsync(Result result);
        Task<Result> GetBestResultAsync(string userId, int testId);
        Task<Result> GetResultAsync(string userId, int testId);
        Task<Result> GetLastResultAsync(string userId, int testId);
        Task<List<Result>> GetFinishedUserResultsAsync(string userId);
        Task<List<Result>> GetUserResultsAsync(string userId, bool finishedOnly);
    }
}
