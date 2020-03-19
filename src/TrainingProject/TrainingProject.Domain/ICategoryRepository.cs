using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
        IEnumerable<Category> GetAll();
        void UpdateCategory(Category categoryToUpdate, int id);
        void DeleteCategory(int id);
        Category AddCategory(Category category);
    }
}
