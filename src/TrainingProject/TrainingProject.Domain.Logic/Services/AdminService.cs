using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Models.Admin;
using TrainingProject.Domain.Models.Question;
using TrainingProject.Data.Models;
using TrainingProject.Domain.Models;
using TrainingProject.Domain.Logic.Helpers;

namespace TrainingProject.Domain.Logic.Services
{
    public class AdminService : IAdminService
    {
        private readonly int _defaultPageSize = 5;

        private readonly IMapper _mapper;
        private readonly IQuestionRepository _quesitonRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITestRepository _testRepository;
        public AdminService(IQuestionRepository questionRepository, ICategoryRepository categoryRepository, ITestRepository testRepository, IMapper mapper)
        {
            _quesitonRepository = questionRepository;
            _categoryRepository = categoryRepository;
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task ApproveQuestionAsync(ApproveQuestionDTO question)
        {
            var dbQuestion = await _quesitonRepository.GetQuestionAsync(question.QuestionId);

            if (dbQuestion != null)
            {
                dbQuestion.IsApproved = question.QuestionApproved;
                dbQuestion.IsDeleted = question.DeleteQuestion;
                dbQuestion.DateApproved = DateTime.UtcNow;

                await _quesitonRepository.ApproveQuestionAsync(dbQuestion);
            }
        }

        public async Task<List<QuestionToApproveDTO>> GetQuestionsToApproveAsync()
        {
            var questionList = await _quesitonRepository.GetUnapprovedQuestionsAsync();
            var result = new List<QuestionToApproveDTO>();

            foreach (var question in questionList)
            {
                result.Add(_mapper.Map<QuestionToApproveDTO>(question));
            }

            return result;
        }

        public async Task<bool> CreateCategoryAsync(CreateCategoryDTO categoryModel)
        {
            if (string.IsNullOrEmpty(await _categoryRepository.GetCategoryNameAsync(categoryModel.CategoryName)))
            {
                var category = _mapper.Map<Category>(categoryModel);
                await _categoryRepository.AddAsync(category);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CreateTestAsync(CreateTestDTO testModel)
        {
            if (string.IsNullOrEmpty(await _testRepository.GetTestNameAsync(testModel.TestName, testModel.ShortName)))
            {
                var test = _mapper.Map<Test>(testModel);
                var testCategory = await _categoryRepository.GetCategoryByNameAsync(testModel.CategoryName);

                if (testCategory != null)
                {
                    test.Category = testCategory;
                    await _testRepository.AddAsync(test);
                }
                else
                {
                    return false;
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<PagedResultDTO<QuestionToApproveDTO>> GetPagedQuestionsAsync(int page, int pageSize)
        {
            var pagedResult = new PagedResultDTO<QuestionToApproveDTO>();

            var unapprovedQuestions = await _quesitonRepository.GetUnapprovedQuestionsCountAsync();
            pageSize = PageVerifier.CheckPageSize(pageSize, unapprovedQuestions);

            pagedResult.TotalPages = (int)Math.Ceiling(unapprovedQuestions / (float)pageSize);
            page = PageVerifier.CheckPage(page, pagedResult.TotalPages);

            pagedResult.Items = _mapper.Map<List<QuestionToApproveDTO>>(await _quesitonRepository.GetQuesitonsPageAsync(page, pageSize));

            if (pagedResult.Items == null)
            {
                return null;
            }

            return pagedResult;
        }
    }
}
