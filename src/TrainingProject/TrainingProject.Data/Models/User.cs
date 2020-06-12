using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Data.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }

        //public int Id { get; set; }
        //public string LastName { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }

        //public int RoleId { get; set; }
        //public Role Role { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
