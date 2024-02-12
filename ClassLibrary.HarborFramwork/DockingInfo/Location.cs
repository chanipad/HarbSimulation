using ClassLibrary.HarborFramework.Utilities;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en lokasjon med tilknytning til en spesifikk dokkplass og tidspunkt.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Foreldrelokasjonen til denne lokasjonen, brukes for å bygge en hierarkisk struktur av lokasjoner.
        /// </summary>
        private Location parentLocation;

        // Denne egenskapen ser ut til å være internt brukt og dens formål er uklart uten kontekst.
        internal object dockLocation;

        /// <summary>
        /// Tidspunktet for når en hendelse skjer ved denne lokasjonen.
        /// </summary>
        internal DateTime timestamp;
        internal Location location;

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
        /// En ny identifikator for lokasjonen, potensielt for å beskrive en ny eller endret posisjon.
        /// </summary>
        public string NewLocation { get; private set; }

        /// <summary>
        /// Initialiserer en ny instans av Location-klassen med en dokkplass, tidspunkt, og dokkplassobjekt.
        /// </summary>
        /// <param name="dockLocation">Identifikatoren for dokkplassen.</param>
        /// <param name="timeSlot">Tidspunktet for lokasjonen.</param>
        /// <param name="dockSpace">Dokkplassobjektet assosiert med lokasjonen.</param>
        public Location(string dockLocation, DateTime timeSlot, DockSpace dockSpace)
        {
            DockLocation = dockLocation;
            Timestamp = timeSlot;
            DockSpace = dockSpace;
        }

        /// <summary>
        /// Initialiserer en ny instans av Location-klassen med en ny lokasjon og tidspunkt.
        /// </summary>
        /// <param name="newLocation">Den nye identifikatoren for lokasjonen.</param>
        /// <param name="timestamp">Tidspunktet for lokasjonen.</param>
        public Location(string newLocation, DateTime timestamp)
        {
            NewLocation = newLocation;
            this.timestamp = timestamp;
        }

        /// <summary>
        /// Standardkonstruktør for Location-klassen.
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Initialiserer en ny instans av Location-klassen med en dokkplass, tidspunkt, og en foreldrelokasjon.
        /// </summary>
        /// <param name="dockLocation">Identifikatoren for dokkplassen.</param>
        /// <param name="timestamp">Tidspunktet for lokasjonen.</param>
        /// <param name="parentLocation">Foreldrelokasjonen for hierarkisk strukturering.</param>
        public Location(string dockLocation, DateTime timestamp, Location parentLocation)
        : this(dockLocation, timestamp)
        {
            this.parentLocation = parentLocation;
        }

        /// <summary>
        /// Gjør det mulig å implicit konvertere en streng til en Location-instans. Implementasjonen er ikke fullført.
        /// </summary>
        /// <param name="newLocation">Strengen som representerer den nye lokasjonen.</param>
        public static implicit operator Location(string newLocation)
        {
            throw new NotImplementedException();
        }
    }
}
