using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TrainingProject.Domain.Logic.Validators;

namespace TrainingProject.Domain.Logic.Models.Question
{
    public class CreateQuestionDTO
    {
        public int TestId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Введите, пожалуйста, вопрос")]
        [MinLength(25, ErrorMessage = "Длина вопроса вопроса должна быть не менее 25 символов.")]
        [MaxLength(255, ErrorMessage = "Длина вопроса вопроса должна быть не более 255 символов.")]
        public string QuestionDescription { get; set; }
        public bool MultipleAnswers { get; set; } = false;
        public IFormFile QuestionImage { get; set; }

        [Required(ErrorMessage = "Укажите, пожалуйста, варианты ответа.")]
        [MinLength(2, ErrorMessage = "В вопросе должно быть не менее 2 вариантов ответа.")]
        [MaxLength(6, ErrorMessage = "В вопросе должно быть не более 6 вариантов ответа.")]
        [EnsureListIsNotEmpty(ErrorMessage = "Требуется заполнить все поля")]
        [EnsureNoForbiddenCharacters(ErrorMessage = "Символ \" | \" является запрещенным.")]
        public IList<string> Choices { get; set; }

        [Required(ErrorMessage = "Укажите, пожалуйста, верные варианты ответа.")]
        [MinLength(1, ErrorMessage = "В вопросе должно быть не менее 1 верного варианта ответа.")]
        [MaxLength(6, ErrorMessage = "В вопросе должно быть не более 6 верных вариантов ответа.")]
        public IList<int> Answers { get; set; }    
    }
}
