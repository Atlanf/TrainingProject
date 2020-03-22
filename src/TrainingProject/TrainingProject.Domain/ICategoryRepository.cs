using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface ICategoryRepository
    {
        Category Get(int id);
        IEnumerable<Category> GetAll();
        void Update(Category categoryToUpdate, int id);
        void Delete(int id);
        void Add(Category category);
    }
}
