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
        Task<Question> GetQuestion(QuestionDTO questionModel);
        Task CreateQuestion(CreateQuestionDTO questionModel);
        Task ApproveQuestion(ApproveQuestionDTO questionModel);
    }
}
