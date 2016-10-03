using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whether.Model;

namespace Whether.ViewModels
{
    public class WeatherViewModel
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public RootObject WeatherData { get; set; }
    }
}
