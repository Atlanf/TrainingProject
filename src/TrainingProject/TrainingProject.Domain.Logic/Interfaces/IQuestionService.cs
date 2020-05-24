using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models.Question;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionDTO> GetQuestion(int questionId);
        Task CreateQuestion(CreateQuestionDTO questionModel);
        Task ApproveQuestion(ApproveQuestionDTO questionModel);
        Task<AnswerResultDTO> AnswerQuestion(QuestionAnswerDTO questionModel);
        Task<AnswerDTO> GetAnswerAsync(int questionId);
    }
}
