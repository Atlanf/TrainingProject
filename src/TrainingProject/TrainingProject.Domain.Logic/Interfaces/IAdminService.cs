using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models.Admin;
using TrainingProject.Domain.Models.Question;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IAdminService
    {
        Task<List<QuestionToApproveDTO>> GetQuestionsToApproveAsync();
        Task ApproveQuestionAsync(ApproveQuestionDTO question);
        Task<bool> CreateCategoryAsync(CreateCategoryDTO categoryModel);
        Task<bool> CreateTestAsync(CreateTestDTO testModel);
        Task<List<QuestionToApproveDTO>> GetQuestionsByPageAsync(int page, int pageSize);
    }
}
