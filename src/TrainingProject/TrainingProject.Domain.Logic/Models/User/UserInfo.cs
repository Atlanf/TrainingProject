using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.User
{
    public class UserInfo
    {
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
