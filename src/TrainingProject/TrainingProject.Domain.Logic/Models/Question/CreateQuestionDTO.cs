using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingProject.Domain.Logic.Models.Question
{
    public class CreateQuestionDTO
    {
        public int TestId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Поле \"Описание вопроса\" должно быть заполнено.")]
        [MinLength(10)]
        public string QuestionDescription { get; set; }
        public bool MultipleAnswers { get; set; } = false;
        public IFormFile QuestionImage { get; set; }

        [Required(ErrorMessage = "На вопрос должно быть не менее 2 вариантов ответа.")]
        [MinLength(2)]
        [MaxLength(6)]
        public ICollection<string> Choices { get; set; }

        [Required(ErrorMessage = "У вопроса должен быть хотя бы 1 верный ответ.")]
        [MinLength(1)]
        public ICollection<int> Answers { get; set; }    }
}
