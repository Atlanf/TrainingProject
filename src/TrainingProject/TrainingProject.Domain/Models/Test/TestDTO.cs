using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models.Question;

namespace TrainingProject.Domain.Models.Test
{
    public class TestDTO
    {
        public int TestId { get; set; }

        public ICollection<int> QuestionsId { get; set; }
    }
}
