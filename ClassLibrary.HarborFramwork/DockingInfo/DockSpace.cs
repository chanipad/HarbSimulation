using ClassLibrary.HarborFramework.Exceptions;
using static ClassLibrary.HarborFramework.Enums;
using System.Linq;
using ClassLibrary.HarborFramework.ContainerYardInfo;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en dokkplass hvor skip kan planlegges for dokking.
    /// </summary>
    public class DockSpace
    {
        /// <summary>
        /// Nummeret til dokkplassen.
        /// </summary>
        public int DockSpaceNumber { get; set; }

        /// <summary>
        /// Typen av dokkplass.
        /// </summary>
        public DockSpaceType Type { get; set; }

        /// <summary>
        /// Listen over skipstyper som er tillatt i denne dokkplassen.
        /// </summary>
        public List<ShipType> AllowedShipTypes { get; set; } = new List<ShipType>();

        /// <summary>
        /// Listen over skip som er planlagt for dokking.
        /// </summary>
        public List<ScheduledShip> ScheduledShips { get; set; } = new List<ScheduledShip>();

        /// <summary>
        /// Listen over kraner tilgjengelig for lasteoperasjoner ved denne dokkplassen.
        /// </summary>
        public List<Crane> Cranes { get; set; } = new List<Crane>();

        /// <summary>
        /// Initialiserer en ny instans av DockSpace-klassen.
        /// </summary>
        /// <param name="dockSpaceNumber">Nummeret til dokkplassen.</param>
        public DockSpace(int dockSpaceNumber)
        {
            DockSpaceNumber = dockSpaceNumber;
            InitializeCranes();
        }

        /// <summary>
        /// Initialiserer kranene for dokkplassen.
        /// </summary>
        private void InitializeCranes()
        {
            for (int i = 0; i < 7; i++)
            {
                Cranes.Add(item: new Crane(i + 1));
            }
        }

        /// <summary>
        /// Konfigurerer dokkplassen med en spesifikk type og tillatte skipstyper.
        /// </summary>
        /// <param name="type">Typen av dokkplass.</param>
        /// <param name="allowedShipTypes">Listen over skipstyper som er tillatt.</param>
        public void ConfigureDockSpace(DockSpaceType type, List<ShipType> allowedShipTypes)
        {
            Type = type;
            AllowedShipTypes = allowedShipTypes;
        }

        /// <summary>
        /// Planlegger et skip for dokking ved dokkplassen, gitt at skipstypen er tillatt.
        /// </summary>
        /// <param name="ship">Skipet som skal planlegges for dokking.</param>
        /// <param name="dockingDateTime">Tidspunktet for når dokkingen skal finne sted.</param>
        /// <returns>True hvis skipet ble planlagt for dokking, ellers false.</returns>
        public bool ScheduleShip(Ship ship, DateTime dockingDateTime)
        {
            if (AllowedShipTypes.Contains(ship.ShipType))
            {
                ScheduledShips.Add(new ScheduledShip { Ship = ship, DockingDateTime = dockingDateTime });
                return true;
            }
            return false;
        }

        /// <summary>
        /// Laster av den første containeren fra et skip og overfører den til et kjøretøy ved hjelp av en tilgjengelig kran,
        /// basert på et planlagt tidspunkt. Metoden sjekker først om det er containere å laste av fra skipet,
        /// finner deretter en tilgjengelig kran og laster containeren over til kjøretøyet. Containeren fjernes fra skipets liste etter vellykket lasting.
        /// </summary>
        /// <param name="ship">Skipet som containeren skal lastes av fra. Må inneholde en liste over containere.</param>
        /// <param name="vehicle">Kjøretøyet som containeren skal lastes over til.</param>
        /// <param name="scheduledTime">Det planlagte tidspunktet for når containeren skal lastes over. Brukes til å finne en tilgjengelig kran.</param>
        /// <returns>
        /// Returnerer true hvis containeren ble vellykket lastet over til kjøretøyet og fjernet fra skipets liste.
        /// Returnerer false hvis det ikke var mulig å laste containeren på grunn av at ingen kraner var tilgjengelige på det planlagte tidspunktet.
        /// </returns>
        /// <exception cref="Exception">Kastes hvis det ikke er noen containere på skipet som kan lastes av.</exception>
        /// <exception cref="DockingExceptions.NoAvailableCranesException">Kastes hvis ingen kraner er tilgjengelige på det planlagte tidspunktet.</exception>
        public bool UnloadContainerFromShip(Ship ship, Vehicle vehicle, DateTime scheduledTime)
        {
            if (!ship.ListOfContainersOnShip.Any())
            {
                throw new Exception("Det er ingen containere å laste av skipet.");
            }

            var availableCrane = Cranes.FirstOrDefault(crane => crane.IsCraneAvailable(scheduledTime));
            if (availableCrane != null)
            {
                var containerToUnload = ship.ListOfContainersOnShip.FirstOrDefault();
                if (containerToUnload != null)
                {
                    bool loadSuccess = availableCrane.LoadContainerOnTransport(containerToUnload, vehicle, scheduledTime);
                    if (loadSuccess)
                    {
                        ship.ListOfContainersOnShip.Remove(containerToUnload);
                        return true;
                    }
                }
            }
            else
            {
                throw new DockingExceptions.NoAvailableCranesException("Ingen tilgjengelige kraner for det planlagte tidspunktet.");
            }

            return false;
        }

    }

    /// <summary>
    /// Representerer et skip som er planlagt for dokking, med tilhørende tidspunkt for dokkingen.
    /// </summary>
    public class ScheduledShip
    {
        /// <summary>
        /// Skipet som er planlagt for dokking.
        /// </summary>
        public Ship Ship { get; set; }

        /// <summary>
        /// Tidspunktet for når skipet er planlagt for dokking.
        /// </summary>
        public DateTime DockingDateTime { get; set; }
    }
}
