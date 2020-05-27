using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Result;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IResultService _resultService;

        public ResultController(ITestService testService, IResultService resultService)
        {
            _testService = testService;
            _resultService = resultService;
        }

        [HttpGet]
        public async Task<ResultDTO> GetResult(ResultRequestDTO resultModel)
        {
            return null;
        }
    }
}