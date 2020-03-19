using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface IChoiceRepository
    {
        Choice GetById(int id);
        IEnumerable<Choice> GetAll();
        void UpdateChoice(Choice choiceToUpdate, int id);
        void DeleteChoice(int id);
        Choice AddChoice(Choice choice);
    }
}
