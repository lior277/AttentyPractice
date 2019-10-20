using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AttentyPractice.Internals.DAL
{
    public class ApiAccess : IApiAccess
    {
        HttpClient _client;

        public string baseApiUrl = @"https://api.weather.com";
        public ApiAccess(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(baseApiUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TResponseDto> ExecuteGetEntry<TResponseDto>(string apiRoute)
        {
            var response = _client.GetAsync(apiRoute);
            var json = await response.Result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponseDto>(json);
        }
    }
}
