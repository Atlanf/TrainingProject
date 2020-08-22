using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Models.Result;
using TrainingProject.Data.Models;
using TrainingProject.Domain.Models.User;
using System.Linq;

namespace TrainingProject.Domain.Logic.Services
{
    public class ResultService : IResultService
    {
        private readonly IMapper _mapper;
        private readonly IResultRepository _resultRepository;
        private readonly ITestRepository _testRepository;
        private readonly IUserRepository _userRepository;

        public ResultService(IMapper mapper, 
                            IResultRepository resultRepository, 
                            ITestRepository testRepository, 
                            IUserRepository userRepository)
        {
            _mapper = mapper;
            _resultRepository = resultRepository;
            _testRepository = testRepository;
            _userRepository = userRepository;
        }

        public async Task<MinimizedResultDTO> GetBestResultAsync(ResultRequestDTO resultModel)
        {
            var user = await _userRepository.GetUserByNameAsync(resultModel.UserName);
            var test = await _testRepository.GetTestDetailsAsync(resultModel.TestName);

            var userResult = await _resultRepository.GetBestResultAsync(user.Id.ToString(), test.Id);
            var result = _mapper.Map<MinimizedResultDTO>(userResult);
            if (userResult != null)
            {
                result.TotalQuestions = test.MaxQuestions;
                result.TestName = test.Name;
            }
            else
            {
                result = null;
            }

            return result;
        }

        public async Task<ResultDTO> GetLastResultAsync(ResultRequestDTO resultModel)
        {
            var user = await _userRepository.GetUserByNameAsync(resultModel.UserName);
            var test = await _testRepository.GetTestDetailsAsync(resultModel.TestName);

            var userResult = await _resultRepository.GetLastResultAsync(user.Id.ToString(), test.Id);

            var result = new ResultDTO(); _mapper.Map<ResultDTO>(userResult);

            if (userResult != null)
            {
                result = _mapper.Map<ResultDTO>(userResult);
            }
            else
            {
                result = null;
            }
            return result;
        }

        public async Task<List<ResultDTO>> GetUserResultsAsync(string userName, bool finishedOnly = false)
        {
            var user = await _userRepository.GetUserByNameAsync(userName);
            var result = new List<ResultDTO>();
            var userResult = await _resultRepository.GetUserResultsAsync(user.Id, finishedOnly);

            if (userResult != null)
            {
                result = _mapper.Map<List<Result>, List<ResultDTO>>(userResult);
            }
            else
            {
                result = null;
            }

            return result;
        }

        public async Task<UserResultsDTO> GetProfileResultsAsync(string userName)
        {
            var result = new UserResultsDTO() {
                CompletedTestNames = new Dictionary<string,string>(),
                NotCompletedTestNames = new Dictionary<string, string>()
            };
            var user = await _userRepository.GetUserByNameAsync(userName);
            var userResult = await _resultRepository.GetResultsByBestAsync(user.Id);

            if (userResult != null)
            {
                userResult = userResult.GroupBy(r => r.TestId).Select(r => r.FirstOrDefault()).ToList();
                foreach (var res in userResult)
                {
                    if (res.TestFinished)
                    {
                        result.CompletedTestNames.Add(res.Test.MinimizedName, res.Test.Name);
                    }
                    else
                    {
                        result.NotCompletedTestNames.Add(res.Test.MinimizedName, res.Test.Name);
                    }
                }
            }
            else
            {
                result = null;
            }

            return result;
        }
    }
}
