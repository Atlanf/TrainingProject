using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models.Result;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IResultService
    {
        Task<List<ResultDTO>> GetUserResultsAsync(string userName, bool finishedOnly = false);
        Task<MinimizedResultDTO> GetBestResultAsync(ResultRequestDTO resultModel);
        Task<ResultDTO> GetLastResultAsync(ResultRequestDTO resultModel);
    }
}
