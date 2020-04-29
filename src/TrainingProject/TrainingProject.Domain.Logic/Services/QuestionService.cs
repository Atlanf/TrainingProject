using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Models.Question;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain.Logic.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IChoiceRepository _choiceRepository;

        public QuestionService(IMapper mapper, IQuestionRepository questionRepository, IChoiceRepository choiceRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _choiceRepository = choiceRepository;
        }

        public async Task<AnswerResultDTO> AnswerQuestion(QuestionAnswerDTO questionModel)
        {
            var result = new AnswerResultDTO()
            {
                QuestionId = questionModel.QuestionId,
                IsCorrect = false 
            };

            if (questionModel.Choices.Count > 0)
            {
                var correctAnswers = await _choiceRepository.GetCorrectAnswersAsync(questionModel.QuestionId); 

                if (questionModel.Choices.SequenceEqual(correctAnswers.ToList()))
                {
                    result.IsCorrect = true;
                }
            }

            return result;
        }

        public async Task ApproveQuestion(ApproveQuestionDTO questionModel)
        {
            var question = _mapper.Map<Question>(questionModel);
            if (questionModel.QuestionApproved)
            {
                question.DateApproved = DateTime.UtcNow;
                await _questionRepository.UpdateAsync(question);
            }
            else
            {
                question.IsDeleted = true;
                await _questionRepository.UpdateAsync(question);
            }
        }

        public async Task CreateQuestion(CreateQuestionDTO questionModel)
        {
            var question = _mapper.Map<Question>(questionModel);
            var choices = _mapper.Map<Choice>(questionModel);

            question.Choices = choices;

            if (choices.Answers.Length > 1)
            {
                question.MultipleAnswers = true;
            }

            await _questionRepository.AddAsync(question);
        }

        //
        public async Task<QuestionDTO> GetQuestion(int questionId)
        {
            var question = await _questionRepository.GetQuestionAsync(questionId);

            var result = _mapper.Map<QuestionDTO>(question);

            return result;
        }
    }
}
