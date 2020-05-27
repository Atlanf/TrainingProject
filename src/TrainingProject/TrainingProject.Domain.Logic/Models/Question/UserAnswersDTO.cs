using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Question
{
    public class UserAnswersDTO
    {
        public string UserName { get; set; }
        public int TestId { get; set; }
        public List<AnswerResultDTO> UserAnswers { get; set; }

    }
}
