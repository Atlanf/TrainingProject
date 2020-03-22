using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface ITestRepository
    {
        Test Get(int id);
        IEnumerable<Test> GetAll();
        void Update(Test testToUpdate, int id);
        void Delete(int id);
        void Add(Test test);
        IEnumerable<Test> GetByCategory(Category category);
    }
}
