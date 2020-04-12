using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Logic.Models.Question;

namespace TrainingProject.Domain.Logic.Models.Test
{
    public class TestDTO
    {
        public int TestId { get; set; }

        public ICollection<int> QuestionsId { get; set; }
    }
}
