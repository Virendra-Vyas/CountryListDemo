using CountryListDemo.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountryListDemo.Services
{
    public class CountryListService : ICountryListService
    {
        private readonly HttpClient _httpClient;
        public CountryListService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("CountryListApi");
        }
        public async Task<List<CountryListModel>> GetCountryLists()
        {
            var url = string.Format("/v2/all");
            var result = new List<CountryListModel>();
            var response =  await _httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                var countryList = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<CountryListModel>>(countryList, new JsonSerializerOptions()
                        { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
