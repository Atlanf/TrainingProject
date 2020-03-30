using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface IChoiceRepository
    {
        Task<Choice> GetAsync(int id);
        Task<IEnumerable<Choice>> GetAllAsync();
        Task<Choice> UpdateAsync(Choice choiceToUpdate);
        Task DeleteAsync(int id);
        Task<Choice> AddAsync(Choice choice);
    }
}
