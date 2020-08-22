using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models.User
{
    public class UserResultsDTO
    {
        public IDictionary<string, string> CompletedTestNames { get; set; }
        public IDictionary<string, string> NotCompletedTestNames { get; set; }
    }
}
