using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Question
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public bool MultipleAnswers { get; set; }
        public string Image { get; set; }
        public ICollection<string> Choices { get; set; }
    }
}
