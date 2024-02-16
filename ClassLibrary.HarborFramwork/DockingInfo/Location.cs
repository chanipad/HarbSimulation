namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en lokasjon med tilknytning til en spesifikk dokkplass og et tidspunkt.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Identifikatoren for dokkplassen assosiert med denne lokasjonen.
        /// </summary>
        public string DockLocation { get; private set; }

        /// <summary>
        /// Tidspunktet for når lokasjonen er relevant, for eksempel for planlegging av laste- eller lossingsoperasjoner.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Dokkplassen assosiert med denne lokasjonen.
        /// </summary>
        public DockSpace DockSpace { get; private set; }

        /// <summary>
        /// Initialiserer en ny instans av Location-klassen med en dokkplass, tidspunkt, og dokkplassobjekt.
        /// </summary>
        /// <param name="dockLocation">Identifikatoren for dokkplassen.</param>
        /// <param name="timestamp">Tidspunktet for lokasjonen.</param>
        /// <param name="dockSpace">Dokkplassobjektet assosiert med lokasjonen.</param>
        public Location(string dockLocation, DateTime timestamp, DockSpace dockSpace)
        {
            DockLocation = dockLocation;
            Timestamp = timestamp;
            DockSpace = dockSpace;
        }

        /// <summary>
        /// Initialiserer en ny instans av Location-klassen med en dokkplass og tidspunkt, uten et eksplisitt dokkplassobjekt.
        /// Dette kan være nyttig for tilfeller hvor detaljert dokkplassinformasjon ikke er nødvendig eller tilgjengelig.
        /// </summary>
        /// <param name="dockLocation">Identifikatoren for dokkplassen.</param>
        /// <param name="timestamp">Tidspunktet for lokasjonen.</param>
        public Location(string dockLocation, DateTime timestamp)
        {
            DockLocation = dockLocation;
            Timestamp = timestamp;
            DockSpace = null;
        }

        /// <summary>
        /// Standardkonstruktør for Location-klassen.
        /// </summary>
        public Location()
        {
        }
    }
}
