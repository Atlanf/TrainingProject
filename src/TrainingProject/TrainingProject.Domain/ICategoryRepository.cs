﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> UpdateAsync(Category categoryToUpdate);
        Task DeleteAsync(int id);
        Task<Category> AddAsync(Category category);
    }
}
