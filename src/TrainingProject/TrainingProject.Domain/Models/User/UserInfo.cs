using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models.User
{
    public class UserInfo
    {
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
