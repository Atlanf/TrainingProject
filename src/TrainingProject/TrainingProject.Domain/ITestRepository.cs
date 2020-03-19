using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface ITestRepository
    {
        Test GetById(int id);
        IEnumerable<Test> GetAll();
        void UpdateTest(Test testToUpdate, int id);
        void DeleteTest(int id);
        Test AddTest(Test test);
    }
}
