using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Question
{
    public class QuestionDTO
    {
        public int TestId { get; set; }
        public string Description { get; set; }
        public bool MultipleAnswers { get; set; }
        public ICollection<int> ChoicesId { get; set; }
        public ICollection<string> ChoicesDescription { get; set; }
    }
}
