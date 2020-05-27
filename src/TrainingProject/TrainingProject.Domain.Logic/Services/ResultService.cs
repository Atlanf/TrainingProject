using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Result;

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
            var userId = user.Id.ToString();

            var test = await _testRepository.GetTestDetailsAsync(resultModel.TestName);
            var testId = test.Id;

            var userResult = await _resultRepository.GetResultAsync(userId, testId);

            var result = _mapper.Map<MinimizedResultDTO>(userResult);
            result.TotalQuestions = test.MaxQuestions;
            result.TestName = test.Name;

            return result;
        }

        public async Task<ResultDTO> GetLastResultAsync(ResultRequestDTO resultModel)
        {
            var user = await _userRepository.GetUserByNameAsync(resultModel.UserName);
            var userId = user.Id.ToString();

            var test = await _testRepository.GetTestDetailsAsync(resultModel.TestName);
            var testId = test.Id;

            var userResult = await _resultRepository.GetLastResultAsync(userId, testId);

            var result = _mapper.Map<ResultDTO>(userResult);

            result.UserName = user.UserName;
            result.TestShortName = test.MinimizedName;
            result.TotalQuestions = test.MaxQuestions;

            return result;
        }

        public async Task<ResultDTO> GetUserResultAsync(ResultRequestDTO resultModel)
        {
            //var user = await _userRepository.GetUserByNameAsync(resultModel.UserName);
            //var userId = user.Id.ToString();

            //var test = await _testRepository.GetTestDetailsAsync(resultModel.TestName);
            //var testId = test.Id;

            //var userResult = await _resultRepository.GetResultAsync(userId, testId);

            //var result = _mapper.Map<ResultDTO>(userResult);

            //result.UserName = user.UserName;
            //result.TestShortName = test.MinimizedName;
            //result.TotalQuestions = test.MaxQuestions;

            return null;
        }
    }
}
