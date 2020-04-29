using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Question;
using TrainingProject.Domain.Logic.Models.Test;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;

        public TestController(ITestService testService, IQuestionService questionService)
        {
            _testService = testService;
            _questionService = questionService;
        }

        [HttpPost]
        public async Task<ActionResult<AnswerResultDTO>> Post(QuestionAnswerDTO questionAnswer)
        {
            var result = await _questionService.AnswerQuestion(questionAnswer);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("{testId}")]
        public async Task<ActionResult<List<QuestionDTO>>> Get(string testId)
        {
            var id = Convert.ToInt32(testId);

            var test = await _testService.GetTestAsync(id);

            if (test != null)
            {
                return Ok(test);
            }
            else
            {
                return Problem();
            }
        }
    }
}