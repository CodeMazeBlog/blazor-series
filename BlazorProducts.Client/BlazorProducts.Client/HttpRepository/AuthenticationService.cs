using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorProducts.Client.HttpRepository
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;

        public AuthenticationService(HttpClient client)
        {
            _client = client;
        }

        public async Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var content = JsonSerializer.Serialize(userForRegistration);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var registrationResult = await _client.PostAsync("https://localhost:5011/api/accounts/registration", bodyContent);
            var registrationContent = await registrationResult.Content.ReadAsStringAsync();

            if (!registrationResult.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<RegistrationResponseDto>(registrationContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result;
            }

            return new RegistrationResponseDto { IsSuccessfulRegistration = true };
        }
    }
}
