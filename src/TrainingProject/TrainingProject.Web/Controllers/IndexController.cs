using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Test;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly ITestService _testService;

        public IndexController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<ActionResult<TestCategoryDTO>> GetAsync()
        {
            var result = await _testService.GetTestsByCategoryAsync();
            return Ok(result.TestsByCategory);
        }
    }
}