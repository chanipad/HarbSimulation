using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramework;
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
            Console.WriteLine($"Crane {CraneId} loaded container {container.ContainerId} onto {vehicle.Type}.");
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
        /// Initialiserer en ny instans av <see cref="ContainerMovedEventArgs"/> klassen.
        /// </summary>
        /// <param name="containerId">ID til containeren som ble flyttet.</param>
        /// <param name="vehicleType">Typen av kjøretøyet containeren ble lastet på.</param>
        public ContainerMovedEventArgs(int containerId, Enums.Vehicle vehicleType)
        {
            ContainerId = containerId;
            VehicleType = vehicleType;
        }
    }
}