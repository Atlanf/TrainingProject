﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        public async Task<ActionResult<List<TestCategoryDTO>>> GetAsync()
        {
            var result = await _testService.GetTestsByCategoryAsync();
            
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}