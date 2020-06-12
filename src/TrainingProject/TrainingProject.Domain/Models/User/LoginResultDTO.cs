using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models.User
{
    public class LoginResultDTO
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
