using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Admin
{
    public class QuestionToApproveDTO
    {
        public int QuestionId { get; set; }
        public string TestName { get; set; }
        public string Description { get; set; }
        public IList<string> Choices { get; set; }
    }
}
