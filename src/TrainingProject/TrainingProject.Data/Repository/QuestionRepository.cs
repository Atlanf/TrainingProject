using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain;
using TrainingProject.Domain.Models;
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

        public async Task<Question> GetAsync(int id)
        {
            return await _context.Questions
                .Include(c => c.Choices)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Question> UpdateAsync(Question questionToUpdate)
        {
            _context.Entry(questionToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return questionToUpdate;
        }
    }
}
