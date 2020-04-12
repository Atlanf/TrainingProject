using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Test;
using TrainingProject.Domain.Models;

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
            var maxQuestions = _testRepository.GetMaxQuestions(testId);
            var questions = await _questionRepository.GetQuestionsByTestAsync(testId);

            var result = GetRandomQuestions(questions, maxQuestions);

            var test = new TestDTO()
            {
                TestId = testId,
                QuestionsId = result
            };

            return test;
        }

        public async Task<TestsWithCategoryDTO> GetTestsByCategoryAsync()
        {
            var result = new TestsWithCategoryDTO();

            var categories = await _testRepository.GetTestsWithCategoryAsync();

            foreach(var category in categories)
            {
                result.TestsByCategory.Add(category.Name, ExtractTestNames(category));
            }

            return result;
        }

        private List<int> GetRandomQuestions(List<int> questions, int maxQuestions)
        {
            var rand = new Random();

            if (questions.Count < maxQuestions)
            {
                maxQuestions = questions.Count;
            }

            var result = new List<int>();

            for (int i = 0; i < maxQuestions; i++)
            {
                int index = rand.Next(0, questions.Count);
                result.Add(questions[index]);
                questions.RemoveAt(index);
            }

            return result;
        }

        private List<string> ExtractTestNames(Category category)
        {
            var result = new List<string>();

            foreach(var test in category.Tests)
            {
                result.Add(test.Name);
            }

            return result;
        }
    }
}
