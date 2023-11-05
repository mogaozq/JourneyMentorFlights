using JourneyMentorFlights.Infrastructure.AviationStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace JourneyMentorFlights.Infrastructure.AviationStack
{
    public class AviationStackApiV1
    {
        private readonly HttpClient _HttpClient;
        private const string accessKey = "4e042e4e544cdf79a5e173af4bc7046d";
        private const string _baseUrl = "http://api.aviationstack.com/v1";

        public AviationStackApiV1(IHttpClientFactory httpClientFactory)
        {
            _HttpClient = httpClientFactory.CreateClient();
            _HttpClient.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<PaginatedList<Flight>?> GetFlightsAsync(PaginationParameters paginationParameters)
        {
            var queryString = $"access_key={accessKey}&limit={paginationParameters.limit}&offset={paginationParameters.offset}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/flights?{queryString}"),
            };

            var response = await _HttpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<PaginatedList<Flight>>();
        }

        public async Task<PaginatedList<Airport>?> GetAirportsAsync(PaginationParameters paginationParameters)
        {
            var queryString = $"access_key={accessKey}&limit={paginationParameters.limit}&offset={paginationParameters.offset}";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_baseUrl}/airports?{queryString}"),
            };

            var response = await _HttpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<PaginatedList<Airport>>();
        }

    }
}
