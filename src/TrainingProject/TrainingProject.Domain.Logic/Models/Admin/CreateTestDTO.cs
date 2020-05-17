using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Admin
{
    public class CreateTestDTO
    {
        [Required(ErrorMessage = "Full name of the test is required.")]
        [MaxLength(50, ErrorMessage = "Name of the test has to be shorter than 50 characters.")]
        [MinLength(5, ErrorMessage = "Name of the test has to be longer than 5 characters.")]
        public string TestName { get; set; }

        [Required(ErrorMessage = "Short name of the test is required.")]
        [MaxLength(20, ErrorMessage = "Short name has to be shorter than 20 characters.")]
        [MinLength(5, ErrorMessage = "Short name has to be longer than 5 characters.")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Test description is required.")]
        public string TestDescription { get; set; }

        [Required(ErrorMessage = "Maximum questions per test is required.")]
        public int MaxQuestions { get; set; }

        [Required(ErrorMessage = "Category of the test is required.")]
        public string CategoryName { get; set; }
    }
}
