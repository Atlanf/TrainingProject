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
                    title: "Get best result error",
                    detail: "Error occured on getting best result. Try again later",
                    statusCode: 500);
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
                    title: "Get last result error",
                    detail: "Error occured on getting last result. Try again later",
                    statusCode: 500);
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
                    title: "Get user results error",
                    detail: "Error occured on getting all user results. Try again.",
                    statusCode: 500);
            }
        }
    }
}