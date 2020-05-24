using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models
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

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}

/*
 public DateTime TestStarted { get; set; }
        public DateTime TestSupposedFinish { get; set; }
     */
