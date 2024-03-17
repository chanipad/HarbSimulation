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
                Cranes.Add(new Crane(i + 1));
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
        /// Utfører en lasteoperasjon ved å bruke en ledig kran til å laste en container på et transportmiddel.
        /// </summary>
        /// <param name="container">Containeren som skal lastes.</param>
        /// <param name="vehicle">Transportmiddelet containeren skal lastes på.</param>
        /// <param name="scheduledTime">Tidspunktet for når lasteoperasjonen skal finne sted.</param>
        /// <returns>True hvis operasjonen var vellykket, ellers false.</returns>
        public bool PerformLoadingOperation(Container container, ITransportVehicle vehicle, DateTime scheduledTime)
        {
            var availableCrane = Cranes.FirstOrDefault(crane => crane.IsCraneAvailable(scheduledTime));
            if (availableCrane != null)
            {
                return availableCrane.LoadContainerOnTransport(container, vehicle, scheduledTime);
            }
            else
            {
                throw new DockingExceptions.NoAvailableCranesException("Ingen tilgjengelige kraner for det planlagte tidspunktet.");
            }
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

    /// <summary>
    /// Representerer en kran som brukes til å laste containere på transportmidler.
    /// </summary>
    public class Crane
    {
        /// <summary>
        /// Identifikatoren til kranen.
        /// </summary>
        public int CraneId { get; set; }

        /// <summary>
        /// Angir om kranen er tilgjengelig for operasjoner.
        /// </summary>
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// En liste som holder styr på perioder hvor kranen er opptatt.
        /// </summary>
        private List<(DateTime Start, DateTime End)> BusySchedule { get; set; } = new List<(DateTime, DateTime)>();

        public Crane(int craneId)
        {
            CraneId = craneId;
        }

        /// <summary>
        /// Laster en container på et transportmiddel ved et planlagt tidspunkt hvis kranen er tilgjengelig.
        /// </summary>
        /// <param name="container">Containeren som skal lastes.</param>
        /// <param name="vehicle">Transportmiddelet containeren skal lastes på.</param>
        /// <param name="scheduledTime">Det planlagte tidspunktet for lasteoperasjonen.</param>
        /// <returns>True hvis lasteoperasjonen ble utført, ellers false.</returns>
        public bool LoadContainerOnTransport(Container container, ITransportVehicle vehicle, DateTime scheduledTime)
        {
            if (IsCraneAvailable(scheduledTime))
            {
                vehicle.LoadContainer(container);
                Console.WriteLine($"Crane {CraneId} loaded container {container.ContainerId} onto vehicle.");
                MarkCraneAsBusy(scheduledTime);
                return true;
            }
            else
            {
                Console.WriteLine($"Crane {CraneId} is not available at the scheduled time.");
                return false;
            }
        }

        /// <summary>
        /// Sjekker om kranen er tilgjengelig på et gitt tidspunkt.
        /// </summary>
        /// <param name="time">Tidspunktet som skal sjekkes.</param>
        /// <returns>True hvis kranen er tilgjengelig, ellers false.</returns>
        public bool IsCraneAvailable(DateTime time)
        {
            return !BusySchedule.Any(interval => interval.Start <= time && interval.End >= time);
        }

        /// <summary>
        /// Markerer kranen som opptatt for et gitt tidsintervall.
        /// </summary>
        /// <param name="time">Starttidspunktet for den opptatte perioden.</param>
        private void MarkCraneAsBusy(DateTime time)
        {
            var busyPeriod = (Start: time, End: time.AddMinutes(30));
            BusySchedule.Add(busyPeriod);
        }
    }
}
