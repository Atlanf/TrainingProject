﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Models;

namespace TrainingProject.Data.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> UpdateAsync(Question questionToUpdate);
        Task DeleteAsync(int id);
        Task<Question> AddAsync(Question question);
        Task<Question> GetQuestionAsync(int id);
        Task<List<Question>> GetQuestionsByTestAsync(int testId);
        Task<int> GetQuestionsCountAsync(int testId);

        Task<Question> ApproveQuestionAsync(Question question);
        Task<IList<Question>> GetUnapprovedQuestionsAsync();
        Task<IList<Question>> GetQuesitonsPageAsync(int page, int pageSize, string searchRequest);
        Task<int> GetUnapprovedQuestionsCountAsync(string searchRequest);
    }
}
