using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingProject.Domain.Models.Question
{
    public class QuestionAnswerDTO
    {
        public int QuestionId { get; set; }
        public ICollection<int> Choices { get; set; }
    }
}
