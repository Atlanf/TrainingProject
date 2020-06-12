using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Data.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public int CorrectAnswers { get; set; }
        public bool TestFinished { get; set; }
        public DateTime DateFinished { get; set; }
        public bool IsDeleted { get; set; }

        public int? TestId { get; set; }
        public Test Test { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}

