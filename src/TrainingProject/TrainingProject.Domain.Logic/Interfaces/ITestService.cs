using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models.Test;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface ITestService
    {
        public Task<TestDTO> GetTestAsync(int testId);
        public Task<TestCategoryDTO> GetTestsByCategoryAsync();
        Task<TestDetailsDTO> GetTestDetailsAsync(string shortName);
    }
}
