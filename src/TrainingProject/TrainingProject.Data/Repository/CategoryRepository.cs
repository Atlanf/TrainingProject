using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingProject.Domain;
using TrainingProject.Domain.Models;

namespace TrainingProject.Data.Repository
{
    class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(category => category.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category categoryToUpdate, int id)
        {
            if (_context.Categories.First(category => category.Id == id) != null)
            {
                _context.Categories.Update(categoryToUpdate);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
