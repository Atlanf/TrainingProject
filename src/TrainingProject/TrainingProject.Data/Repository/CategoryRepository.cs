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
        private AppDbContext _context { get; set; }

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(category => category.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void UpdateCategory(Category categoryToUpdate, int id)
        {
            if (_context.Categories.First(category => category.Id == id) != null)
            {
                _context.Categories.Update(categoryToUpdate);
                _context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public Category AddCategory(Category category)
        {
            if (category != null)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return category;
            }
            else
            {
                return null;
            }
        }
    }
}
