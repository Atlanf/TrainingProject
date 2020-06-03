using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TrainingProject.Client.Helpers
{
    public class ResponseHandlingHelper<T>
    {
        public bool ErrorOccured { get; set; }
        public ProblemDetails ErrorDetails { get; set; }

        public ResponseHandlingHelper()
        {
            ResetErrors();
        }

        public async Task<T> GetResponseResult(HttpResponseMessage responseMessage)
        {
            T result = default;
            ResetErrors();
            switch (responseMessage.StatusCode.ToString())
            {
                case "200":
                    result = await responseMessage.Content.ReadAsJsonAsync<T>();
                    break;
                case "500":
                    ErrorOccured = true;
                    ErrorDetails = await responseMessage.Content.ReadAsJsonAsync<ProblemDetails>();
                    break;
            }
            return result;
        }

        private void ResetErrors()
        {
            ErrorOccured = false;
            ErrorDetails = new ProblemDetails();
        }
    }
}
