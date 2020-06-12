using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models.Question
{
    public class AnswerResultDTO
    {
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
