using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Test
{
    public class TestDetailsDTO
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public string MinimizedName { get; set; }
        public string TestDescription { get; set; }
        public int QuestionsApproved { get; set; }
    }
}
