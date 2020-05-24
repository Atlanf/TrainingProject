using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Question
{
    public class AnswerDTO
    {
        public int QuestionId { get; set; }
        public IList<int> CorrectAnswers { get; set; }

    }
}
