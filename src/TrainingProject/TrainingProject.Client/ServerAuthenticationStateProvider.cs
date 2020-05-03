using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Models.User;

namespace TrainingProject.Client
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        public ServerAuthenticationStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var response = await _httpClient.GetAsync($"api/user/user");
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }

            var userInfo = await response.Content.ReadAsJsonAsync<UserInfo>();

            var identity = userInfo.IsAuthenticated
                ? new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, userInfo.Name),
                        new Claim(ClaimTypes.Role, userInfo.Role)
                    }, "serverauth")
                : new ClaimsIdentity();

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
