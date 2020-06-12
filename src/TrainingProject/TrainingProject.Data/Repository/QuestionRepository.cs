using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain;
using TrainingProject.Data.Models;
using TrainingProject.Data.Interfaces;

namespace TrainingProject.Data.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Question> AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                question.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions
                .Include(c => c.Choices)
                .ToListAsync();
        }

        public async Task<Question> UpdateAsync(Question questionToUpdate)
        {
            _context.Entry(questionToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return questionToUpdate;
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _context.Questions
                .Include(c => c.Choices)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<Question>> GetQuestionsByTestAsync(int testId)
        {
            return await _context.Questions
                .Where(t => t.TestId == testId && t.IsApproved == true)
                .OrderBy(i => i.Id)
                .Include(c => c.Choices)
                .ToListAsync();
        }

        public async Task<int> GetQuestionsCountAsync(int testId)
        {
            return await _context.Questions
                .Where(t => t.TestId == testId)
                .CountAsync();
        }

        public async Task<Question> ApproveQuestionAsync(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<IList<Question>> GetUnapprovedQuestionsAsync()
        {
            return await _context.Questions
                .Where(a => a.IsApproved == false && a.IsDeleted == false)
                .Include(c => c.Choices)
                .Include(t => t.Test).ThenInclude(cat => cat.Category)
                .ToListAsync();
        }
    }
}
