using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models.Question;
using TrainingProject.Domain.Models.Result;
using TrainingProject.Domain.Models.Test;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface ITestService
    {
        public Task<List<QuestionDTO>> GetTestAsync(int testId);
        public Task<List<TestCategoryDTO>> GetTestsByCategoryAsync();
        Task<TestDetailsDTO> GetTestDetailsAsync(string shortName);
        Task<ResultDTO> FinishTestAsync(UserAnswersDTO answersModel);
        Task<string> GetShortNameAsync(int testId);
    }
}
