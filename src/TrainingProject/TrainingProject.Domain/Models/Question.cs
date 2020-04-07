using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool MultipleAnswers { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsApproved { get; set; } = false;
        public DateTime? DateApproved { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public Choice Choices { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
