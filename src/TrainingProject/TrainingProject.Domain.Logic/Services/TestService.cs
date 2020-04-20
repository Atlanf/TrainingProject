using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Question;
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

        public async Task<TestDetailsDTO> GetTestDetailsAsync(string shortName)
        {
            var test = await _testRepository.GetTestDetailsAsync(shortName);

            var result = _mapper.Map<TestDetailsDTO>(test);

            result.QuestionsApproved = await _questionRepository.GetQuestionsCountAsync(test.Id);

            return result;
        }

        public async Task<List<QuestionDTO>> GetTestAsync(int testId)
        {
            var maxQuestions = _testRepository.GetMaxQuestions(testId);
            var questions = await _questionRepository.GetQuestionsByTestAsync(testId);

            var questionList = GetRandomQuestions(questions, maxQuestions);

            var result = new List<QuestionDTO>();

            foreach (var question in questionList)
            {
                result.Add(_mapper.Map<QuestionDTO>(question));
            }

            return result;
        }

        public async Task<TestCategoryDTO> GetTestsByCategoryAsync()
        {
            var result = new TestCategoryDTO()
            {
                TestsByCategory = new Dictionary<string, ICollection<string>>(),
                TestNames = new Dictionary<string, string>()
            };

            var categories = await _testRepository.GetTestsWithCategoryAsync();

            foreach(var category in categories)
            {
                result.TestsByCategory.Add(category.Name, ExtractTestNames(category));
                foreach (var test in category.Tests)
                {
                    result.TestNames.Add(test.Name, test.MinimizedName);
                }
            }

            return result;
        }

        private List<Question> GetRandomQuestions(List<Question> questions, int maxQuestions)
        {
            var rand = new Random();

            if (questions.Count < maxQuestions)
            {
                maxQuestions = questions.Count;
            }

            var result = new List<Question>();

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
