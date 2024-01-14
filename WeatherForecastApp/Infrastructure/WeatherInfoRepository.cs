using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Application.Interface;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Infrastructure
{
    public class WeatherInfoRepository : IWeatherInfoRepository
    {
        private const string API_URL = "http://api.weatherstack.com/current?access_key=a24a5662854b835aaf6c03f17a3dcb1a&query=";
        private HttpClient _httpClient;

        public WeatherInfoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<WeatherInfoDTO> GetWeatherInfo(string zipcode)
        {
            string apiUrl = API_URL + zipcode;
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var weatherApiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherInfo>(jsonResponse);
                if (weatherApiResponse.Location != null)
                {
                    var weatherModel = new WeatherInfoDTO
                    {
                        LocationName = weatherApiResponse.Location.Name,
                        UVIndex = weatherApiResponse.Current.Uv_index,
                        WindSpeed = weatherApiResponse.Current.Wind_speed,
                        WeatherDescriptions = weatherApiResponse.Current.Weather_descriptions
                    };
                    return weatherModel;
                }
                return null;
            }
            return null;
        }
    }
}
