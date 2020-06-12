using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Data.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public string[] Choices { get; set; }
        public int[] Answers { get; set; }
        public bool IsDeleted { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
