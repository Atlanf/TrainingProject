using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Admin
{
    public class CreateCategoryDTO
    {
        [Required]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
    }
}
