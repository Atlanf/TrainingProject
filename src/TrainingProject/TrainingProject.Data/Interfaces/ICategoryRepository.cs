using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> UpdateAsync(Category categoryToUpdate);
        Task DeleteAsync(int id);
        Task<Category> AddAsync(Category category);
        Task<string> GetCategoryNameAsync(string categoryName);
        Task<Category> GetCategoryByNameAsync(string categoryName);
    }
}
