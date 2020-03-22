using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface IChoiceRepository
    {
        Choice Get(int id);
        IEnumerable<Choice> GetAll();
        void Update(Choice choiceToUpdate, int id);
        void Delete(int id);
        void Add(Choice choice);
    }
}
