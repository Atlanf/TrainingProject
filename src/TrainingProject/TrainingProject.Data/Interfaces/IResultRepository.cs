using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface IResultRepository
    {
        Result Get(int id);
        IEnumerable<Result> GetAll();
        void Update(Result resultToUpdate, int id);
        void Delete(int id);
        void Add(Result result);
        IEnumerable<Result> GetByUser(int id);
        IEnumerable<Result> GetByTest(int id);
    }
}
