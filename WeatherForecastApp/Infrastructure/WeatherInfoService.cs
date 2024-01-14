using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Application.Interface;
using WeatherApp.Domain.Entities;

namespace WeatherApp.Infrastructure
{
    public class WeatherInfoService
    {
        private readonly IWeatherInfoRepository _weatherInfoRepository;
        public WeatherInfoService(IWeatherInfoRepository weatherInfoRepository)
        {
            _weatherInfoRepository = weatherInfoRepository;
        }

        public Task<WeatherInfoDTO> GetWeatherInfos(string zipCode)
        {
            var result = _weatherInfoRepository.GetWeatherInfo(zipCode);
            return result;
        }

    }
}
