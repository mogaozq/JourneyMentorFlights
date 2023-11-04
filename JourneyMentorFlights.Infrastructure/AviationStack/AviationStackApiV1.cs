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

        public AviationStackApiV1(IHttpClientFactory httpClientFactory)
        {
            _HttpClient = httpClientFactory.CreateClient();
            _HttpClient.BaseAddress = new Uri("https://api.aviationstack.com/v1");
        }

        public async Task<PaginatedList<Flight>?> GetFlightsAsync(PaginationParameters paginationParameters)
        {
  
                var queryString = $"access_key={accessKey}&limit={paginationParameters.limit}&offset={paginationParameters.offset}";
                var response = await _HttpClient.GetFromJsonAsync<PaginatedList<Flight>>($"flights?{queryString}");

                return response;
        }

        public async Task<PaginatedList<Airline>?> GetAirlinesAsync(PaginationParameters paginationParameters)
        {
            var queryString = $"access_key={accessKey}&limit={paginationParameters.limit}&offset={paginationParameters.offset}";
            var response = await _HttpClient.GetFromJsonAsync<PaginatedList<Airline>>($"airlines?{queryString}");

            return response;
        }

        public async Task<PaginatedList<Airport>?> GetAirportsAsync(PaginationParameters paginationParameters)
        {
            var queryString = $"access_key={accessKey}&limit={paginationParameters.limit}&offset={paginationParameters.offset}";
            return await _HttpClient.GetFromJsonAsync<PaginatedList<Airport>>($"airports?{queryString}");
        }

    }
}
