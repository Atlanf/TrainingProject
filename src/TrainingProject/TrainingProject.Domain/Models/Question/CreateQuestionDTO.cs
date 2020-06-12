using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TrainingProject.Domain.Validators;

namespace TrainingProject.Domain.Models.Question
{
    public class CreateQuestionDTO
    {
        public int TestId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter the question")]
        [MinLength(25, ErrorMessage = "Question must be larger than 25 characters.")]
        [MaxLength(255, ErrorMessage = "Question must be shorter than 255 characters.")]
        public string QuestionDescription { get; set; }
        public bool MultipleAnswers { get; set; } = false;

        [Required(ErrorMessage = "Enter choices.")]
        [MinLength(2, ErrorMessage = "There's must be more than 2 choices.")]
        [MaxLength(6, ErrorMessage = "There's must be more than 4 choices.")]
        [EnsureListIsNotEmpty(ErrorMessage = "All fields should be filled.")]
        [EnsureNoForbiddenCharacters(ErrorMessage = "Symbol \" | \" is forbidden.")]
        public IList<string> Choices { get; set; }

        [Required(ErrorMessage = "Choose the answer.")]
        [MinLength(1, ErrorMessage = "There's must be at least 1 answer.")]
        [MaxLength(6, ErrorMessage = "There's must be less than 4 answers.")]
        public IList<int> Answers { get; set; }    
    }
}
