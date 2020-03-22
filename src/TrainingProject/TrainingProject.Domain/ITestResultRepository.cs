using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface ITestResultRepository
    {
        TestResult Get(int id);
        IEnumerable<TestResult> GetAll();
        void Update(TestResult resultToUpdate, int id);
        void Delete(int id);
        void Add(TestResult result);
        IEnumerable<TestResult> GetByUser(int id);
        IEnumerable<TestResult> GetByTest(int id);
    }
}
