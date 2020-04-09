using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Test;

namespace TrainingProject.Domain.Logic.Services
{
    public class TestService : ITestService
    {
        private readonly IMapper _mapper;
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;

        public TestService(IMapper mapper, ITestRepository testRepository, IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
        }

        public async Task<TestDTO> GetTestAsync(int testId)
        {


            return null;
        }
    }
}
