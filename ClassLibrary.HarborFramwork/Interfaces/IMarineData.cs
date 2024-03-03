using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Interfaces
{
    internal interface IMarineData
    {
        double TideLevel { get; }
        double WaveHeight { get; }
        string WaveDirection { get; }
        double Speed { get; }
        string Direction { get; }
        void MeasureWind();
        void GetWaveForecast();
        void GetTideInformation();
    }
}
