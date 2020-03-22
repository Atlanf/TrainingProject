using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models
{
    public class TestResult
    {
        public int UserId { get; set; }
        public int TestId { get; set; }
        public Test TestName { get; set; }
        public User UserName { get; set; }
        public bool TestFinished { get; set; }
        public DateTime DateFinished { get; set; }

    }
}
