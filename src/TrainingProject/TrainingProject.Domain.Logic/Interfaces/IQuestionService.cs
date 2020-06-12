using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models.Question;
using TrainingProject.Domain.Models;
using TrainingProject.Domain.Models.Admin;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionDTO> GetQuestion(int questionId);
        Task<bool> CreateQuestion(CreateQuestionDTO questionModel);
        Task ApproveQuestion(ApproveQuestionDTO questionModel);
        Task<AnswerResultDTO> AnswerQuestion(QuestionAnswerDTO questionModel);
        Task<AnswerDTO> GetAnswerAsync(int questionId);
    }
}
