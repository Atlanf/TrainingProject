using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingProject.Domain.Models.Question;

namespace TrainingProject.Client.Helpers
{
    public class HelperAnswerResult
    {
        public int QuestionPosition { get; set; }
        public AnswerResultDTO AnswerResult { get; set; }
    }
}
