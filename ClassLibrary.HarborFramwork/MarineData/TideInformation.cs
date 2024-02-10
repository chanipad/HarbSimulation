using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.MarineData
{
    public class TideInformation
    {
        private Dictionary<DateTime, double> tideLevel;

        // Constructor
        public TideInformation()
        { 
            tideLevel = new Dictionary<DateTime, double>();
        }


        public void SetTideLevel(DateTime dateTime, double level)
        {
            tideLevel[dateTime] = level;
            //throw new NotImplementedException();
            //tideLevel[dateTime] = level;
        }

        /// <summary>
        /// Get information about tide level on date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public double GetTideLevel(DateTime dateTime) 
        { 
            if (tideLevel.ContainsKey(dateTime))
            {
                return tideLevel[dateTime];
            }
            else 
            { 
                return (double)-1;   // Return a default value indicating tide information not available
            }
        }


        /*public void SetTideLevel(DateTime dateTime, double v)
        {
            throw new NotImplementedException();
        }*/
    }
}
