using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Entities
{
    public class WeatherInfoDTO
    {
        public string? LocationName { get; set; }
        public decimal UVIndex { get; set; }
        public decimal WindSpeed { get; set; }
        public List<string>? WeatherDescriptions { get; set; }
    }
}
