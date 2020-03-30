using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.User
{
    public class ProfileDTO
    {
        public string UserName { get; set; }
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // List of results; profile picture(?); 
    }
}
