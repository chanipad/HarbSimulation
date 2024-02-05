using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.MarineData
{
    internal class TrafficConditions
    {
        private WeatherForecast weatherForcast { get; set; }
        private WindMeasurement windMeasurement { get; set; }
        private TideInformation tideInformation { get; set; }
        private WaveForecast waveForeCast { get; set; }
    }
}
