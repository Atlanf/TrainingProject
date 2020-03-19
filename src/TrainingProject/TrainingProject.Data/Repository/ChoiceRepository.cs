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
        private AppDbContext _context { get; set; }

        public ChoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public Choice GetById(int id)
        {
            return _context.Choices.FirstOrDefault(choice => choice.Id == id);
        }

        public IEnumerable<Choice> GetAll()
        {
            return _context.Choices.ToList();
        }

        public void UpdateChoice(Choice choiceToUpdate, int id)
        {
            if (_context.Choices.First(choice => choice.Id == id) != null)
            {
                _context.Choices.Update(choiceToUpdate);
                _context.SaveChanges();
            }
        }

        public void DeleteChoice(int id)
        {
            var choice = _context.Choices.Find(id);
            if (choice != null)
            {
                _context.Choices.Remove(choice);
                _context.SaveChanges();
            }
        }

        public Choice AddChoice(Choice choice)
        {
            if (choice != null)
            {
                _context.Choices.Add(choice);
                _context.SaveChanges();
                return choice;
            }
            else
            {
                return null;
            }
        }
    }
}
