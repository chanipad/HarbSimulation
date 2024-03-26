using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramework;
using ClassLibrary.HarborFramework.DockingInfo;
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

    /// <summary>
    /// Initialiserer en ny instans av <see cref="Crane"/> klassen.
    /// </summary>
    /// <param name="craneId">Unik identifikator for kranen.</param>
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
    public bool LoadContainerOnTransport(Container container, Vehicle vehicle, DateTime scheduledTime)
    {
        if (IsCraneAvailable(scheduledTime))
        {
            vehicle.LoadContainer(container);
            Location lokasjon = new Location($"{vehicle.Type}");
            container.AddNewLocation(lokasjon);
            MarkCraneAsBusy(scheduledTime);
            OnContainerMoved(new ContainerMovedEventArgs(container.ContainerId, vehicle.Type));
            return true;
        }
        else
        {
            Console.WriteLine($"Crane {CraneId} is not available at the scheduled time.");
            return false;
        }
    }

    /// <summary>
    /// Overfører en container fra et kjøretøy til et skip ved et planlagt tidspunkt.
    /// </summary>
    /// <param name="vehicle">Kjøretøyet containeren skal fjernes fra.</param>
    /// <param name="ship">Skipet containeren skal plasseres på.</param>
    /// <param name="scheduledTime">Det planlagte tidspunktet for overføringen.</param>
    /// <returns>True hvis overføringen ble utført, ellers false.</returns>
    public bool TransferContainerFromVehicleToShip(Vehicle vehicle, Ship ship, DateTime scheduledTime)
    {
        if (IsCraneAvailable(scheduledTime))
        {
            var container = vehicle.UnloadContainer();
            if (container != null)
            {
                ship.AddContainerToShip(container);

                var newLocation = new Location($"Ship {ship.Id}"); 
                newLocation.Timestamp = DateTime.Now; 
                container.AddNewLocation(newLocation); 

                MarkCraneAsBusy(scheduledTime);
                OnContainerMoved(new ContainerMovedEventArgs(container.ContainerId, ship.ShipType));
                Console.WriteLine($"Container {container.ContainerId} was successfully transferred from {vehicle.Type} to Ship {ship.Id}.");
                return true;
            }
            else
            {
                Console.WriteLine("No container was available to transfer from the vehicle.");
                return false;
            }
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
    public void MarkCraneAsBusy(DateTime time)
    {
        var busyPeriod = (Start: time, End: time.AddMinutes(30));
        BusySchedule.Add(busyPeriod);
    }

    /// <summary>
    /// Event som utløses når en container blir lastet på et kjøretøy.
    /// </summary>
    public event EventHandler<ContainerMovedEventArgs> ContainerMoved;
    protected virtual void OnContainerMoved(ContainerMovedEventArgs e)
    {
        ContainerMoved?.Invoke(this, e);
    }

    /// <summary>
    /// Inneholder data for <see cref="ContainerMoved"/> eventet.
    /// </summary>
    public class ContainerMovedEventArgs : EventArgs
    {
        /// <summary>
        /// Containerens ID.
        /// </summary>
        public int ContainerId { get; private set; }

        /// <summary>
        /// Typen av kjøretøyet containeren ble lastet på.
        /// </summary>
        public Enums.Vehicle VehicleType { get; private set; }

        /// <summary>
        /// Får typen av skipet containeren ble lastet på, hvis aktuelt.
        /// </summary>
        public Enums.ShipType ShipType { get; private set; }

        /// <summary>
        /// Initialiserer en ny instans av <see cref="ContainerMovedEventArgs"/> klassen.
        /// </summary>
        /// <param name="containerId">ID til containeren som ble flyttet.</param>
        /// <param name="vehicleType">Typen av kjøretøyet containeren ble lastet på.</param>
        public ContainerMovedEventArgs(int containerId, Enums.Vehicle vehicleType)
        {
            ContainerId = containerId;
            VehicleType = vehicleType;
        }

        /// <summary>
        /// Initialiserer en ny instans av ContainerMovedEventArgs-klassen for et skip.
        /// </summary>
        /// <param name="containerId">ID til containeren som ble flyttet.</param>
        /// <param name="shipType">Typen av skipet containeren ble lastet på.</param>
        public ContainerMovedEventArgs(int containerId, Enums.ShipType shiptype)
        {
            ContainerId = containerId;
            ShipType = shiptype;
        }
    }
}