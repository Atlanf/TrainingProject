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
            var result = await _questionService.CreateQuestion(questionModel);
            if (result)
            {
                return Ok();
            }
            else
            {
                return Problem(
                    title: "Error on creating question.",
                    detail: "Error occured on creating new question. Try again.",
                    statusCode: 500);
            }
        }
    }
}