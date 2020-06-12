using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models.Question
{
    public class AnswerDTO
    {
        public int QuestionId { get; set; }
        public IList<int> CorrectAnswers { get; set; }

    }
}
