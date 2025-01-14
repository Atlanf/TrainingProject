﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Models.Question;
using TrainingProject.Domain.Models.Result;
using TrainingProject.Domain.Models.Test;

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

        [HttpPost("finish")]
        public async Task<ActionResult<ResultDTO>> FinishTest(UserAnswersDTO answersModel)
        {
            var result = await _testService.FinishTestAsync(answersModel);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Problem(
                    title: "Error on finishing test.",
                    detail: "Something went wrong on writing result.",
                    statusCode: 500);
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
                return Problem(
                    title: "Test not found.",
                    detail: "Test with these parameters not found.",
                    statusCode: 404);
            }
        }

        [HttpGet("answer/{questionId}")]
        public async Task<ActionResult<AnswerDTO>> GetAnswer(int questionId)
        {
            var result = await _questionService.GetAnswerAsync(questionId);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Problem(
                    title: "Question not found.",
                    detail: "Question with these parameters not found.",
                    statusCode: 404);
            }
        }
    }
}