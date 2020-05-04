using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Admin;
using TrainingProject.Domain.Logic.Models.Question;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
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
    }
}