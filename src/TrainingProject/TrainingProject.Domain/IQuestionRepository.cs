using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface IQuestionRepository
    {
        Question Get(int id);
        IEnumerable<Question> GetAll();
        void Update(Question questionToUpdate, int id);
        void Delete(int id);
        void Add(Question question);
    }
}
