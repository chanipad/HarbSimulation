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
}