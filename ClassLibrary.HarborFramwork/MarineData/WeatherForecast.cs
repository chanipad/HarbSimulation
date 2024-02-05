using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.MarineData
{
    internal class WeatherForecast
    {
        private double temperature { get; set; }
        private double humidity { get; set; }
        private double precipitation { get; set; }
        public void GetForecast() 
        { 
            temperature = 0.0;
            humidity = 0.0;
            precipitation = 0.0;
    
        }
    }
}
