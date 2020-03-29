﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface ITestRepository
    {
        Task<Test> GetAsync(int id);
        Task<IEnumerable<Test>> GetAllAsync();
        Task<Test> UpdateAsync(Test testToUpdate);
        Task DeleteAsync(int id);
        Task<Test> AddAsync(Test test);
        IEnumerable<Test> GetByCategory(Category category);
    }
}
