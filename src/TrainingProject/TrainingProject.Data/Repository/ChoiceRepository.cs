using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingProject.Domain;
using TrainingProject.Domain.Models;

namespace TrainingProject.Data.Repository
{
    public class ChoiceRepository : IChoiceRepository
    {
        private readonly AppDbContext _context;

        public ChoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public Choice Get(int id)
        {
            return _context.Choices.FirstOrDefault(choice => choice.Id == id);
        }

        public IEnumerable<Choice> GetAll()
        {
            return _context.Choices.ToList();
        }

        public void Update(Choice choiceToUpdate, int id)
        {
            if (_context.Choices.First(choice => choice.Id == id) != null)
            {
                _context.Choices.Update(choiceToUpdate);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var choice = _context.Choices.Find(id);
            if (choice != null)
            {
                _context.Choices.Remove(choice);
                _context.SaveChanges();
            }
        }

        public void Add(Choice choice)
        {
            _context.Choices.Add(choice);
            _context.SaveChanges();
        }
    }
}
