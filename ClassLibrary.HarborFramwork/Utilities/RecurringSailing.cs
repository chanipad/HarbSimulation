using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.HarborFramework.ShipInfo;
using ClassLibrary.HarborFramework.Enums;

namespace ClassLibrary.HarborFramwork.Utilities
{
    public class RecurringSailing
    {
        private Dictionary<DayOfWeek, List<Ship>> weeklySailings = new Dictionary<DayOfWeek, List<Ship>>();

        /// <summary>
        /// Initializes a new instance of the RecurringSailing class, setting up a weekly sailing schedule.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the weekly sailing schedule with empty lists of ships for each day of the week,
        /// ensuring that the schedule is ready to have ships added for any day.
        /// </remarks>
        public RecurringSailing()
        {
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                weeklySailings[day] = new List<Ship>();
            }
        }

        /// <summary>
        /// Retrieves a list of ships scheduled for sailing on a specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week for which to retrieve the scheduled ships.</param>
        /// <returns>A list of ships scheduled for sailing on the specified day.</returns>
        /// <remarks>
        /// This method returns all ships that are scheduled to sail on the given day of the week.
        /// If no ships are scheduled for that day, an empty list is returned.
        /// </remarks>
        public List<Ship> GetShipsForDay(DayOfWeek dayOfWeek)
        {
            return weeklySailings[dayOfWeek];
        }

        /// <summary>
        /// Adds a ship to the recurring sailing schedule for a specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week on which the ship will sail.</param>
        /// <param name="ship">The ship to be added to the sailing schedule.</param>
        /// <remarks>
        /// If the ship is already scheduled for sailing on the specified day, this method will not add it again,
        /// preventing duplicate entries in the sailing schedule.
        /// </remarks>
        public void AddShipToRecurringSailing(DayOfWeek dayOfWeek, Ship ship)
        {
            if (!weeklySailings[dayOfWeek].Contains(ship))
            {
                weeklySailings[dayOfWeek].Add(ship);
            }
        }

        /// <summary>
        /// Removes a ship from the recurring sailing schedule for a specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week from which the ship will be removed.</param>
        /// <param name="ship">The ship to be removed from the sailing schedule.</param>
        /// <remarks>
        /// This method removes the ship from the sailing schedule of the specified day.
        /// If the ship is not found in the schedule for that day, no action is taken.
        /// </remarks>
        public void RemoveShipFromRecurringSailing(DayOfWeek dayOfWeek, Ship ship)
        {
            weeklySailings[dayOfWeek].Remove(ship);
        }

        public List<Ship> GetShipsForDay(DayOfWeek dayOfWeek)
        {
            return weeklySailings[dayOfWeek];
        }

        /// <summary>
        /// Gets the list of sailing details for a specific day of the week.
        /// </summary>
        /// <param name="dayOfWeek">The day of the week for which to get the schedule.</param>
        /// <returns>A list of SailingDetails for the specified day.</returns>
        public void RemoveShipFromAllSailings(Ship ship)
        {
            foreach (var daySailings in weeklySailings.Values)
            {
                daySailings.Remove(ship);
            }
        }


    }