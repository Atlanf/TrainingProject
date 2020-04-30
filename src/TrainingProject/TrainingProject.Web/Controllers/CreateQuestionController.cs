using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Question;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateQuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public CreateQuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<ActionResult<QuestionDTO>> Post(CreateQuestionDTO questionModel)
        {
            if (ModelState.IsValid)
            {
                await _questionService.CreateQuestion(questionModel);

                return Ok();
            }
            return Problem();
        }
    }
}