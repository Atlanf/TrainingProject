using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models.Question
{
    public class UserAnswersDTO
    {
        public string UserName { get; set; }
        public int TestId { get; set; }
        public List<AnswerResultDTO> UserAnswers { get; set; }

    }
}
