using ClassLibrary.HarborFramework.ShipInfo;
using ClassLibrary.HarborFramework.Utilities;


namespace ClassLibrary.HarborFramework.Utilities
{
    public class SailingSchedule
    {
        private List<SingleSailing> singleSailings = new List<SingleSailing>();
        private RecurringSailing recurringSailing = new RecurringSailing();

        /// <summary>
        /// Retrieves a list of all ships from both single and recurring sailings.
        /// </summary>
        /// <returns>A list of <see cref="Ship"/> objects that are scheduled for either single or recurring sailings.</returns>
        /// <remarks>
        /// This method compiles ships from both single sailings and recurring weekly sailings into a single list.
        /// Ships from recurring sailings are included without duplication, even if they are scheduled on multiple days.
        /// </remarks>
        
        
        /*
        public List<Ship> GetAllSailings()
        {
            var allShips = new List<Ship>();

            // Add ships from single sailings
            foreach (var singleSailing in singleSailings)
            {
                allShips.AddRange(singleSailing.GetAllSailings());
            }

            // Add ships from recurring sailings without duplication
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                var shipsForDay = recurringSailing.GetShipsForDay(day);
                foreach (var ship in shipsForDay)
                {
                    if (!allShips.Contains(ship))
                    {
                        allShips.Add(ship);
                    }
                }
            }

            return allShips;
           }
        */

    }
}
