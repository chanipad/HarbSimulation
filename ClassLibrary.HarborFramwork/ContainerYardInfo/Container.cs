using System;
using System.Collections.Generic;
using ClassLibrary.HarborFramework.DockingInfo;
using ClassLibrary.HarborFramework.Interfaces;

namespace ClassLibrary.HarborFramework.ContainerYardInfo
{
    /// <summary>
    /// Representerer informasjon om en container og dens historikk.
    /// </summary>
    public class Container : IHarb // Antar at IHarb er et grensesnitt som eksisterer i prosjektet
    {
        /// <summary>
        /// Får containerens ID.
        /// </summary>
        public int ContainerId { get; private set; }

        /// <summary>
        /// Holder en privat liste av lokasjoner for å spore containerens historikk.
        /// </summary>
        private List<Location> Locations { get; set; } = new List<Location>();

        /// <summary>
        /// Konstruktør for å opprette en ny container med en spesifikk ID.
        /// </summary>
        /// <param name="containerId">Containerens unike ID.</param>
        public Container(int containerId)
        {
            ContainerId = containerId;
        }

        /// <summary>
        /// Legger til en ny lokasjon i containerens historikk.
        /// </summary>
        /// <param name="newLocation">Den nye lokasjonen å legge til.</param>
        public void AddNewLocation(Location newLocation)
        {
            Locations.Add(newLocation);
        }

        /// <summary>
        /// Henter og skriver ut til konsollen en liste av alle lokasjonene containeren har vært på.
        /// Denne metoden skriver ut hver lokasjonens detaljer til konsollen, inkludert dokkplassidentifikatoren og tidsstempelet, før den returnerer listen.
        /// </summary>
        /// <remarks>
        /// Listen som returneres er en kopi av den interne listen for å forhindre eksterne modifikasjoner.
        /// </remarks>
        /// <returns>En liste av <see cref="Location"/> objekter som representerer containerens historikk.</returns>
        public List<Location> GetContainerHistory()
        {
            List<Location> historyCopy = new List<Location>(Locations);

            foreach (var location in historyCopy)
            {
                Console.WriteLine($"Location: {location.DockLocation}, Timestamp: {location.Timestamp}");
            }

            return historyCopy;
        }


        // Implementasjon av IHarb grensesnittmetoder (antar at disse er del av IHarb)
        public void ConfigureHarbor() { throw new NotImplementedException(); }
        public void ConfigureDockSpace() { throw new NotImplementedException(); }
        public void ConfigureContainerYard() { throw new NotImplementedException(); }
        public void SetSailingSchedule() { throw new NotImplementedException(); }
        public void ConfigureShipType() { throw new NotImplementedException(); }
        public ShipHistory GetShipHistory(int shipId) { throw new NotImplementedException(); }
        public void EvaluateTrafficWeatherSeaConditions() { throw new NotImplementedException(); }
        public void HandleSecurityRegulations() { throw new NotImplementedException(); }
    }
}
