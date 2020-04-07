﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public List<Question> Questions { get; set; }

        public ICollection<Result> Results { get; set; }

        //public int AuthorId { get; set; }
        //public User Author { get; set; }
    }
}
