using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models.Question
{
    public class UpdatedQuestionDTO
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }

        public string Description { get; set; }
        public IList<string> Choices { get; set; }
    }
}
