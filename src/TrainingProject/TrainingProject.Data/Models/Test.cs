using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Data.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MinimizedName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int MaxQuestions { get; set; } = 10;
        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public List<Question> Questions { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
