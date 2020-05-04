using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Admin;
using TrainingProject.Domain.Logic.Models.Question;

namespace TrainingProject.Domain.Logic.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _quesitonRepository;
        public AdminService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _quesitonRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task ApproveQuestionAsync(ApproveQuestionDTO question)
        {
            var dbQuestion = await _quesitonRepository.GetQuestionAsync(question.QuestionId);

            /*Add mapper (?)*/
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
    }
}
