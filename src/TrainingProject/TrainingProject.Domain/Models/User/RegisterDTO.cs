using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingProject.Domain.Models.User
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Enter your User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter your Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password mismatch.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string RedirectUri { get; set; }
    }
}
