using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models.Result;
using TrainingProject.Domain.Models.User;

namespace TrainingProject.Domain.Logic.Interfaces
{
    public interface IResultService
    {
        Task<List<ResultDTO>> GetUserResultsAsync(string userName, bool finishedOnly = false);
        Task<MinimizedResultDTO> GetBestResultAsync(ResultRequestDTO resultModel);
        Task<ResultDTO> GetLastResultAsync(ResultRequestDTO resultModel);
        Task<UserResultsDTO> GetProfileResultsAsync(string userName);
    }
}
