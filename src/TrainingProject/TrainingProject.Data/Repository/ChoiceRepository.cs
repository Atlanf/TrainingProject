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
    public class ChoiceRepository : IChoiceRepository
    {
        private readonly AppDbContext _context;

        public ChoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Choice> GetAsync(int id)
        {
            var result = await _context.Choices.Include(q => q.Question).FirstOrDefaultAsync(c => c.Id == id); // 
            return result;
        }

        public async Task<IEnumerable<Choice>> GetAllAsync()
        {
            return await _context.Choices.ToListAsync();
        }

        public async Task<Choice> UpdateAsync(Choice choiceToUpdate)
        {
            _context.Entry(choiceToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return choiceToUpdate;
        }

        public async Task DeleteAsync(int id)
        {
            var choice = await _context.Choices.FindAsync(id);
            if (choice != null)
            {
                choice.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Choice> AddAsync(Choice choice)
        {
            await _context.Choices.AddAsync(choice);
            await _context.SaveChangesAsync();
            return choice;
        }

        public async Task<int[]> GetCorrectAnswersAsync(int id)
        {
            return await _context.Choices
                .Where(c => c.Id == id)
                .Select(a => a.Answers)
                .FirstOrDefaultAsync();
        }
    }
}
