using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models.Result;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IResultService
    {
        Task<ResultDTO> GetUserResultAsync(ResultRequestDTO resultModel);
    }
}
