using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Result
{
    public class MinimizedResultDTO
    {
        public string TestName { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalQuestions { get; set; }
        public bool TestFinished { get; set; }
    }
}
