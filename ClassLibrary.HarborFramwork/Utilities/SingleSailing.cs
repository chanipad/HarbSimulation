using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.HarborFramework.ShipInfo;

namespace ClassLibrary.HarborFramwork.Utilities
{
    public class SingleSailing
    {
        public List<Ship> sailings = new List<Ship>();

        /// <summary>
        /// Adds a ship to a single sailing schedule.
        /// </summary>
        /// <param name="ship">The ship to add to the sailing.</param>
        /// <param name="sailingDate">The date and time of the sailing.</param>
        public void AddSailing(Ship ship, DateTime sailingDate)
        {
            sailings.Add(new Ship(ship), new sailingDate());
        }

        /// <summary>
        /// Removes a specific sailing from the schedule.
        /// </summary>
        /// <param name="ship">The ship whose sailing is to be removed.</param>
        /// <param name="sailingDate">The date and time of the sailing to remove.</param>
        public void RemoveSailing(Ship ship, DateTime sailingDate)
        {
            sailings.RemoveAll(s => s.Ship == ship && s.SailingDate == sailingDate);
        }

        /// <summary>
        /// Retrieves a list of all scheduled sailings.
        /// </summary>
        /// <returns>A list of all sailings.</returns>
        public List<Ship> GetAllSailings()
        {
            return new List<Ship>(sailings);
        }
    }
}
