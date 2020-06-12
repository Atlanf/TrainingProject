using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface ITestRepository
    {
        Task<Test> GetAsync(int id);
        Task<IEnumerable<Test>> GetAllAsync();
        Task<Test> UpdateAsync(Test testToUpdate);
        Task DeleteAsync(int id);
        Task<Test> AddAsync(Test test);
        IEnumerable<Test> GetByCategory(Category category);
        int GetMaxQuestions(int testId);
        Task<ICollection<Category>> GetTestsWithCategoryAsync();
        Task<Test> GetTestDetailsAsync(string shortName);
        Task<string> GetTestNameAsync(string testName, string shortName);
        Task<string> GetTestMinimizedNameAsync(int testId);
    }
}
