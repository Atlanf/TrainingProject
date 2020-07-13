using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Models;
using TrainingProject.Domain.Models.Admin;
using TrainingProject.Domain.Models.Question;
using TrainingProject.Domain.Models.Test;

namespace TrainingProject.Web.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ITestService _testService;
        public AdminController(IAdminService adminService, ITestService testService)
        {
            _adminService = adminService;
            _testService = testService;
        }

        //[HttpGet("questions")]
        //public async Task<ActionResult<List<QuestionToApproveDTO>>> GetQuestionsToApprove()
        //{
        //    var questions = await _adminService.GetQuestionsToApproveAsync();
        //    if (questions != null)
        //    {
        //        return Ok(questions);
        //    }
        //    else
        //    {
        //        return Problem(
        //            title: "Questions to approve error.",
        //            detail: "Error occured while loading list of questions. Try again later.",
        //            statusCode: 500);
        //    }
        //}

        [HttpPut]
        public async Task<ActionResult> ApproveQuestion(ApproveQuestionDTO questionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _adminService.ApproveQuestionAsync(questionModel);

            return Ok();
        }

        [HttpPost("category/create")]
        public async Task<ActionResult> CreateCategory(CreateCategoryDTO categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _adminService.CreateCategoryAsync(categoryModel);
            if (result)
            {
                return Ok();
            }
            else
            {
                return Problem(
                    title: "Create category error.",
                    detail: "Error occured on creating new category. Try again.",
                    statusCode: 500);
            }
        }

        [HttpPost("test/create")]
        public async Task<ActionResult> CreateTest(CreateTestDTO testModel)
        {
            var result = await _adminService.CreateTestAsync(testModel);

            if (result)
            {
                return Ok();
            }
            else
            {
                return Problem(
                    title: "Create test error.",
                    detail: "Error occured on new test. Try again.",
                    statusCode: 500);
            }
        }

        [HttpGet("test/get")]
        public async Task<ActionResult<List<TestCategoryDTO>>> GetExistingCategoriesAsync()
        {
            var result = await _testService.GetTestsByCategoryAsync();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Problem(
                    title: "Get category error.",
                    detail: "Error occured while you tried to get list of categories. Try again later.",
                    statusCode: 500);
            }
        }

        [HttpGet("questions")]
        public async Task<ActionResult<PagedResultDTO<QuestionToApproveDTO>>> GetByPages(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 5)
        {
            var pagedResult = await _adminService.GetPagedQuestionsAsync(page, pageSize);

            if (pagedResult != null && pagedResult.Items != null)
            {
                return Ok(pagedResult);
            }
            else
            {
                return Problem(
                    title: "Get questions error.",
                    detail: "Error occured while you tried to get list of questions to approve. Try again later.",
                    statusCode: 500);
            }
        }

        [HttpPost("questions/search")]
        public async Task<ActionResult<PagedResultDTO<QuestionToApproveDTO>>> Search(
            [FromBody] string searchRequest,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 5)
        {
            var pagedResult = await _adminService.GetPagedQuestionsAsync(page, pageSize, searchRequest);

            if (pagedResult != null && pagedResult.Items != null)
            {
                return Ok(pagedResult);
            }
            else
            {
                return Problem(
                    title: "Search questions error.",
                    detail: "Error occured while you tried to search questions to approve. Try again later.",
                    statusCode: 500);
            }
        }
    }
}