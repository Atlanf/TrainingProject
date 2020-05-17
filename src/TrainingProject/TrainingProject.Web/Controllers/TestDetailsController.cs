using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Test;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDetailsController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestDetailsController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("{shortName}")]
        public async Task<ActionResult<TestDetailsDTO>> Get(string shortName)
        {
            var result = await _testService.GetTestDetailsAsync(shortName);
            return Ok(result);
        }
    }
}