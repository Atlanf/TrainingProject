using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface IResultRepository
    {
        Task<Result> AddResultAsync(Result result);
        Task<Result> GetBestResultAsync(string userId, int testId);
        Task<Result> GetResultAsync(string userId, int testId);
        Task<Result> GetLastResultAsync(string userId, int testId);

        Result Get(int id);
        IEnumerable<Result> GetAll();
        void Update(Result resultToUpdate, int id);
        void Delete(int id);
        
        IEnumerable<Result> GetByUser(int id);
        IEnumerable<Result> GetByTest(int id);
         
    }
}
