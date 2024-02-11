﻿using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.HarborFramework.ShipInfo;

namespace ClassLibrary.HarborFramwork.Utilities
{
    public class SingleSailing
    {
        private Dictionary<Ship, DateTime> sailings = new Dictionary<Ship, DateTime>();


        /// <summary>
        /// Adds a ship to a single sailing schedule.
        /// </summary>
        /// <param name="ship">The ship to add to the sailing.</param>
        /// <param name="sailingDate">The date and time of the sailing.</param>
        public void AddSailing(Ship ship, DateTime sailingDate)
        {
            sailings.Add(ship, sailingDate);
        }

        /// <summary>
        /// Removes a specific sailing from the schedule.
        /// </summary>
        /// <param name="ship">The ship whose sailing is to be removed.</param>
        /// <param name="sailingDate">The date and time of the sailing to remove.</param>
        public void RemoveSailing(Ship ship, DateTime sailingDate)
        {
            sailings.Remove(ship);
        }

        /// <summary>
        /// Retrieves a list of all scheduled sailings.
        /// </summary>
        /// <returns>A list of all sailings.</returns>
        public List<KeyValuePair<Ship, DateTime>> GetAllSailings()
        {
            return sailings.ToList();
        }
    }
}
