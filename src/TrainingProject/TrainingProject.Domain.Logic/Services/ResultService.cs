using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Data.Interfaces;
using TrainingProject.Domain.Logic.Interfaces;

namespace TrainingProject.Domain.Logic.Services
{
    public class ResultService : IResultService
    {
        private readonly IMapper _mapper;
        private readonly IResultRepository _resultRepository;

        public ResultService(IMapper mapper, IResultRepository resultRepository)
        {
            _mapper = mapper;
            _resultRepository = resultRepository;
        }
    }
}
