using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.User
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Укажите имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Укажите Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
