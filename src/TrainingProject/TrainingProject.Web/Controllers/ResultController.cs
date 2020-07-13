using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Models.Result;

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

        [HttpGet("best/{userName}/{testName}")]
        public async Task<ActionResult<ResultDTO>> GetBestResult(string userName, string testName)
        {
            var resultModel = new ResultRequestDTO()
            {
                UserName = userName,
                TestName = testName
            };

            var result = await _resultService.GetBestResultAsync(resultModel);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Problem(
                    title: "Result not found",
                    detail: "Result for this user not found",
                    statusCode: 404);
            }
        }


        /*testName - minimized name*/
        [HttpGet("minimized/{userName}/{testName}")]
        public async Task<ActionResult<MinimizedResultDTO>> GetMinimizedResult(string userName, string testName)
        {
            var resultModel = new ResultRequestDTO()
            {
                UserName = userName,
                TestName = testName
            };

            var result = await _resultService.GetLastResultAsync(resultModel);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Problem(
                    title: "Result not found",
                    detail: "Result for this user not found",
                    statusCode: 404);
            }
        }

        [HttpGet("{userName}/{finisedOnly?}")]
        public async Task<ActionResult<List<ResultDTO>>> GetUserResults(string userName, bool finishedOnly = false)
        {
            var result = await _resultService.GetUserResultsAsync(userName, finishedOnly);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Problem(
                    title: "Result not found",
                    detail: "Result for this user not found",
                    statusCode: 404);
            }
        }
    }
}