using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Domain.Entities
{
    public class Current
    {
        public string Observation_time { get; set; }
        public decimal Temperature { get; set; }
        public decimal Weather_code { get; set; }
        public List<string> Weather_icons { get; set; }
        public List<string> Weather_descriptions { get; set; }
        public decimal Wind_speed { get; set; }
        public decimal Wind_degree { get; set; }
        public string Wind_dir { get; set; }
        public decimal Pressure { get; set; }
        public decimal Precip { get; set; }
        public decimal Humidity { get; set; }
        public decimal Cloudcover { get; set; }
        public decimal Feelslike { get; set; }
        public decimal Uv_index { get; set; }
        public decimal Visibility { get; set; }
    }
}
