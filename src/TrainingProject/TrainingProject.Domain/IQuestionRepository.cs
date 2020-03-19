using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface IQuestionRepository
    {
        Question GetById(int id);
        IEnumerable<Question> GetAll();
        void UpdateQuestion(Question questionToUpdate, int id);
        void DeleteQuestion(int id);
        Question AddQuestion(Question question);
    }
}
