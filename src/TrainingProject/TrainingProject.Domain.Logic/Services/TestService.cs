using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Question;
using TrainingProject.Domain.Logic.Models.Result;
using TrainingProject.Domain.Logic.Models.Test;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain.Logic.Services
{
    public class TestService : ITestService
    {
        private readonly IMapper _mapper;
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IResultRepository _resultRepository;

        public TestService( IMapper mapper,
                            ITestRepository testRepository,
                            IQuestionRepository questionRepository,
                            IUserRepository userRepository,
                            IResultRepository resultRepository)
        {
            _mapper = mapper;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _userRepository = userRepository;
            _resultRepository = resultRepository;
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

        public async Task<List<TestCategoryDTO>> GetTestsByCategoryAsync()
        {
            var categories = await _testRepository.GetTestsWithCategoryAsync();

            var result = new List<TestCategoryDTO>();

            foreach (var category in categories)
            {
                result.Add(new TestCategoryDTO
                {
                    CategoryName = category.Name,
                    TestFullNames = category.Tests.Select(t => t.Name).ToList(),
                    TestShortNames = category.Tests.Select(t => t.MinimizedName).ToList()
                });

            }

            return result;
        }

        public async Task<ResultDTO> FinishTestAsync(UserAnswersDTO answersModel)
        {
            int correctAnswers = CountCorrectAnswers(answersModel.UserAnswers);
            var resultInfo = new ResultDTO();
            var result = new Result();

            try
            {
                result.User = await _userRepository.GetUserByNameAsync(answersModel.UserName);
                result.Test = await _testRepository.GetAsync(answersModel.TestId);
                result.DateFinished = DateTime.UtcNow;
                result.CorrectAnswers = correctAnswers;
                result.TestFinished = SetFinishedTestResult(answersModel.UserAnswers.Count, correctAnswers);

                await _resultRepository.AddResultAsync(result);

                resultInfo = _mapper.Map<ResultDTO>(result);
                resultInfo.TotalQuestions = answersModel.UserAnswers.Count;
                resultInfo.CorrectAnswers = correctAnswers;
                resultInfo.TestShortName = await _testRepository.GetTestMinimizedNameAsync(answersModel.TestId);
                resultInfo.UserName = answersModel.UserName;
            }
            catch (Exception ex)
            {
                return null;
            }

            return resultInfo;
        }

        public async Task<string> GetShortNameAsync(int testId)
        {
            return await _testRepository.GetTestMinimizedNameAsync(testId);
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

        private int CountCorrectAnswers(List<AnswerResultDTO> answerResults)
        {
            return answerResults.Where(a => a.IsCorrect).Count();
        }

        private bool SetFinishedTestResult(int totalQuestions, int correctAnswers)
        {
            int percentage = (totalQuestions / correctAnswers) * 100;
            return percentage >= 50 ? true : false;
        }
    }
}
