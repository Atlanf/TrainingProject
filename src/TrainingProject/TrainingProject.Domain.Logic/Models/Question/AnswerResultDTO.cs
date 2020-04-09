using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Question
{
    public class AnswerResultDTO
    {
        public int QuestionId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
