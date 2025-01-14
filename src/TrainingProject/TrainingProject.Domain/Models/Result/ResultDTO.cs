﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models.Result
{
    public class ResultDTO
    {
        public int TestId { get; set; }
        public DateTime DateFinished { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalQuestions { get; set; }
        public bool TestFinished { get; set; }
        public string UserName { get; set; }
        public string TestShortName { get; set; }
    }
}
