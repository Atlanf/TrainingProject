using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Admin;
using TrainingProject.Domain.Logic.Models.Question;
using TrainingProject.Domain.Logic.Models.Test;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ITestService _testService;
        public AdminController(IAdminService adminService, ITestService testService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<List<QuestionToApproveDTO>>> GetQuestionsToApprove()
        {
            var questions = await _adminService.GetQuestionsToApproveAsync();
            if (questions != null)
            {
                return Ok(questions);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut]
        public async Task<ActionResult> ApproveQuestion(ApproveQuestionDTO questionModel)
        {
            await _adminService.ApproveQuestionAsync(questionModel);

            return Ok();
        }

        [HttpPost("category/create")]
        public async Task<ActionResult> CreateCategory(CreateCategoryDTO categoryModel)
        {
            var result = await _adminService.CreateCategoryAsync(categoryModel);

            if (result)
            {
                return Ok();
            }
            else
            {
                return Problem("Such category already exists. Please, try again with different name");
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
                return Problem("Something went wrong");
            }
        }

        [HttpPost("test/get")]
        public async Task<ActionResult<List<TestCategoryDTO>>> GetExistingCategoriesAsync()
        {
            var result = await _testService.GetTestsByCategoryAsync();

            return Ok(result);
        }
    }
}