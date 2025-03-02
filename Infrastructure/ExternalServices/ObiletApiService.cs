using DTOs.Concrete;
using Common.Constants;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.ExternalServices
{
    /// <summary>
    /// Obitel Api Service
    /// </summary>
    public class ObiletApiService : IObiletApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiConfig _apiConfig;
        private readonly JsonSerializerOptions _jsonOptions;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="apiConfig"></param>
        public ObiletApiService(HttpClient httpClient, IOptions<ApiConfig> apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig.Value;
            _httpClient.BaseAddress = new Uri(_apiConfig.ApiUrl);
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        }

        /// <summary>
        /// Get Session
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public async Task<SessionData> GetSessionAsync(SessionInfo session)
        {
            return await SendRequestAsync<SessionData>("/api/client/getsession", session);
        }

        /// <summary>
        /// Get Bus Locations
        /// </summary>
        /// <param name="busLocationRequest"></param>
        /// <returns></returns>
        public async Task<BusLocationResponse> GetBusLocationsAsync(BusLocationRequest busLocationRequest)
        {
            return await SendRequestAsync<BusLocationResponse>("/api/location/getbuslocations", busLocationRequest);
        }

        /// <summary>
        /// Get Bus Journeys
        /// </summary>
        /// <param name="busJourneyRequest"></param>
        /// <returns></returns>
        public async Task<BusJourneyResponse> GetBusJourneysAsync(BusJourneyRequest busJourneyRequest)
        {
            return await SendRequestAsync<BusJourneyResponse>("/api/journey/getbusjourneys", busJourneyRequest);
        }

        /// <summary>
        /// Send Request Async to Obilet Api Service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="requestData"></param>
        /// <returns></returns>
        private async Task<T> SendRequestAsync<T>(string endpoint, object requestData)
        {
            var json = JsonSerializer.Serialize(requestData, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var request = new HttpRequestMessage(HttpMethod.Post, endpoint)
            {
                Content = content
            };

            request.Headers.Add("Authorization", $"Basic {_apiConfig.ApiClientToken}");

            using var response = await _httpClient.SendAsync(request).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                return default;

            var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonSerializer.Deserialize<T>(responseJson, _jsonOptions);
        }
    }
}
