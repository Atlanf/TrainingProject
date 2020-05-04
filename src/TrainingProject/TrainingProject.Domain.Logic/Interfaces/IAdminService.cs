using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models.Admin;
using TrainingProject.Domain.Logic.Models.Question;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IAdminService
    {
        Task<List<QuestionToApproveDTO>> GetQuestionsToApproveAsync();
        Task ApproveQuestionAsync(ApproveQuestionDTO question);
    }
}
