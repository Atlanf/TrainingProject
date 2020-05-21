using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Test
{
    public class TestCategoryDTO
    {
        public string CategoryName { get; set; }
        public IList<string> TestFullNames { get; set; }
        public IList<string> TestShortNames { get; set; }
    }
}
