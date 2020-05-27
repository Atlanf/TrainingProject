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

        public ResultService(IMapper mapper, IResultRepository resultRepository)
        {
            _mapper = mapper;
            _resultRepository = resultRepository;
        }

        public async Task<ResultDTO> GetUserResultAsync(ResultRequestDTO resultModel)
        {
            var user = await _userRepository.GetUserByNameAsync(resultModel.UserName);
            var userId = user.Id.ToString();

            var test = await _testRepository.GetTestDetailsAsync(resultModel.TestName);
            var testId = test.Id;

            var userResult = await _resultRepository.GetResultAsync(userId, testId);


            throw new NotImplementedException();
        }
    }
}
