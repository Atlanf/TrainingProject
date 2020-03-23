using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsAnswer { get; set; }
        public bool IsDeleted { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
