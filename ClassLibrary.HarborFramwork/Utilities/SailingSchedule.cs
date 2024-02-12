using ClassLibrary.HarborFramework.Interfaces;
namespace ClassLibrary.HarborFramework.Utilities
{
    /// <summary>
    /// Manages both single and recurring sailings for ships.
    /// </summary>
    public class SailingSchedule : ISailingSchedule
    {
        private List<Ship> singleSailings = new List<Ship>();
        private Dictionary<DayOfWeek, List<Ship>> recurringSailings = new Dictionary<DayOfWeek, List<Ship>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SailingSchedule"/> class.
        /// </summary>
        public SailingSchedule()
        {
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                recurringSailings[day] = new List<Ship>();
            }
        }

        /// <summary>
        /// Adds a ship to the schedule for a single sailing.
        /// </summary>
        /// <param name="ship">The ship to be added.</param>
        /// <param name="sailingDate">The date and time of the sailing.</param>
        public void AddSingleSailing(Ship ship, DateTime sailingDate)
        {
            ship.dateTime = sailingDate;
            if (!singleSailings.Contains(ship))
            {
                singleSailings.Add(ship);
            }
        }

        /// <summary>
        /// Adds a ship to the schedule for recurring sailings on a specific day of the week.
        /// </summary>
        /// <param name="ship">The ship to be added.</param>
        /// <param name="dayOfWeek">The day of the week the ship will sail.</param>
        public void AddRecurringSailing(Ship ship, DayOfWeek dayOfWeek)
        {
            if (!recurringSailings[dayOfWeek].Contains(ship))
            {
                recurringSailings[dayOfWeek].Add(ship);
            }
        }

        /// <summary>
        /// Removes a ship from both single and recurring sailing schedules.
        /// </summary>
        /// <param name="ship">The ship to be removed.</param>
        public void RemoveSailing(Ship ship)
        {
            // Remove from single sailings
            singleSailings.Remove(ship);

            // Remove from all recurring sailings
            foreach (var daySailings in recurringSailings.Values)
            {
                daySailings.Remove(ship);
            }
        }

        /// <summary>
        /// Gets a list of ships scheduled to sail on a specified date.
        /// </summary>
        /// <param name="date">The date for which to retrieve the sailing schedule.</param>
        /// <returns>A list of ships scheduled to sail on the specified date.</returns>
        public List<Ship> GetSailingsOn(DateTime date)
        {
            var sailingsOnDate = new List<Ship>();

            // Add single sailings scheduled for the specific date
            sailingsOnDate.AddRange(singleSailings.Where(ship => ship.dateTime.Date == date.Date));

            // Add recurring sailings for the day of the week
            if (recurringSailings.ContainsKey(date.DayOfWeek))
            {
                sailingsOnDate.AddRange(recurringSailings[date.DayOfWeek]);
            }

            return sailingsOnDate;
        }
    }
}
