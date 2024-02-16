using ClassLibrary.HarborFramework.Interfaces;
namespace ClassLibrary.HarborFramework.Utilities
{
    /// <summary>
    /// Administrerer både enkelte og gjentakende seilaser for skip.
    /// </summary>
    public class SailingSchedule : ISailing
    {
        private List<Ship> singleSailings = new List<Ship>();
        private Dictionary<DayOfWeek, List<Ship>> recurringSailings = new Dictionary<DayOfWeek, List<Ship>>();

        /// <summary>
        /// Initialiserer en ny instans av <see cref="SailingSchedule"/>-klassen.
        /// </summary>
        public SailingSchedule()
        {
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                recurringSailings[day] = new List<Ship>();
            }
        }

        /// <summary>
        /// Legger et skip til planen for en enkelt seilas.
        /// </summary>
        /// <param name="ship">Skipet som skal legges til.</param>
        public void AddSingleSailing(Ship ship)
        {
            if (!singleSailings.Contains(ship))
            {
                singleSailings.Add(ship);
            }
        }

        /// <summary>
        /// Legger et skip til planen for gjentakende seilaser på en spesifikk ukedag.
        /// </summary>
        /// <param name="ship">Skipet som skal legges til.</param>
        /// <param name="dayOfWeek">Ukedagen skipet skal seile.</param>
        public void AddRecurringSailing(Ship ship, DayOfWeek dayOfWeek)
        {
            if (!recurringSailings[dayOfWeek].Contains(ship))
            {
                recurringSailings[dayOfWeek].Add(ship);
            }
        }

        /// <summary>
        /// Fjerner et skip fra både enkelt og gjentakende seilasplaner.
        /// </summary>
        /// <param name="ship">Skipet som skal fjernes.</param>
        public void RemoveSailing(Ship ship)
        {
            // Fjerner fra enkelte seilaser
            singleSailings.Remove(ship);

            // Fjerner fra alle gjentakende seilaser
            foreach (var daySailings in recurringSailings.Values)
            {
                daySailings.Remove(ship);
            }
        }

        /// <summary>
        /// Henter en liste over skip planlagt å seile på en spesifisert dato.
        /// </summary>
        /// <param name="date">Datoen for hvilken seilasplanen skal hentes.</param>
        /// <returns>En liste over skip planlagt å seile på den spesifiserte datoen.</returns>
        public List<Ship> GetSailingScheduleBasedOnDay(DateTime date)
        {
            var sailingsOnDate = new List<Ship>();

            // Legger til enkelte seilaser planlagt for den spesifikke datoen
            sailingsOnDate.AddRange(singleSailings.Where(ship => ship.dateTime.Date == date.Date));

            // Legger til gjentakende seilaser for ukedagen
            if (recurringSailings.ContainsKey(date.DayOfWeek))
            {
                sailingsOnDate.AddRange(recurringSailings[date.DayOfWeek]);
            }

            return sailingsOnDate;
        }

        /// <summary>
        /// Henter en kombinert liste over alle enkelte og gjentakende seilaser.
        /// </summary>
        /// <returns>En liste over alle planlagte seilaser.</returns>
        public List<Ship> GetAllSailings()
        {
            var allSailings = new List<Ship>();

            // Legger til alle enkelte seilaser
            allSailings.AddRange(singleSailings);

            // Legger til alle gjentakende seilaser
            foreach (var daySailingPair in recurringSailings)
            {
                allSailings.AddRange(daySailingPair.Value);
            }

            return allSailings;
        }

    }
}
