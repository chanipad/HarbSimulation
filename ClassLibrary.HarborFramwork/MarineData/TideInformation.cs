using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.MarineData
{
    internal class TideInformation
    {
        private Dictionary<DateTime, double> tideLevel;

        // Constructor
        public TideInformation()
        { 
            tideLevel = new Dictionary<DateTime, double>();
        }


        private void SetTideLevel(DateTime datre, double level)
        {
            tideLevel[datre] = level;
        }

        /// <summary>
        /// Get information about tide level on date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public double GetTideLevel(DateTime date) 
        { 
            if (tideLevel.ContainsKey(date))
            {
                return tideLevel[date];
            }
            else 
            { 
                return -1;   // Return a default value indicating tide information not available
            }
        }

    }
}
