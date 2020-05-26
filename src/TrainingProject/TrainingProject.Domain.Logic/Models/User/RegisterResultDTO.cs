using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.User
{
    public class RegisterResultDTO
    {
        public bool Successful { get; set; }
        public IList<string> Errors { get; set; }
    }
}
