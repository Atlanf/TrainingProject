﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> GetAsync(int id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> UpdateAsync(Question questionToUpdate);
        Task DeleteAsync(int id);
        Task<Question> AddAsync(Question question);
    }
}