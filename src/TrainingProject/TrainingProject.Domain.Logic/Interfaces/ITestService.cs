using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models.Question;
using TrainingProject.Domain.Logic.Models.Test;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface ITestService
    {
        public Task<List<QuestionDTO>> GetTestAsync(int testId);
        public Task<List<TestCategoryDTO>> GetTestsByCategoryAsync();
        Task<TestDetailsDTO> GetTestDetailsAsync(string shortName);
    }
}
