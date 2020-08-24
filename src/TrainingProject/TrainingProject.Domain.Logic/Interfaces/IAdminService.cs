using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models;
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
        Task<PagedResultDTO<QuestionToApproveDTO>> GetPagedQuestionsAsync(int page, int pageSize, string searchRequest = "");
        Task<QuestionDTO> EditQuestionAsync(UpdatedQuestionDTO updatedQuestion);
    }
}
