using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Test
{
    public class TestCategoryDTO
    {

        /* Category - Key; Tests, related to category - Item*/
        public IDictionary<string, ICollection<string>> TestsByCategory { get; set; }

    }
}
