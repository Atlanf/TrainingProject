using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Question
{
    public class ApproveQuestionDTO
    {
        public int QuestionId { get; set; }

        [Required]
        public bool QuestionApproved { get; set; }
        [Required]
        public bool DeleteQuestion { get; set; }
    }
}
