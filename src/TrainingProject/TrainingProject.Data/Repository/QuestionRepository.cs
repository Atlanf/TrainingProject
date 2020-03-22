using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingProject.Domain;
using TrainingProject.Domain.Models;

namespace TrainingProject.Data.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Question> GetAll()
        {
            return _context.Questions.ToList();
        }

        public Question Get(int id)
        {
            return _context.Questions.FirstOrDefault(question => question.Id == id);
        }

        public void Update(Question questionToUpdate, int id)
        {
            if (_context.Questions.First(question => question.Id == id) != null)
            {
                _context.Questions.Update(questionToUpdate);
                _context.SaveChanges();
            }
        }
    }
}
