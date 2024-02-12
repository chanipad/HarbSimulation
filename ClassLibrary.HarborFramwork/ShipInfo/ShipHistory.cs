using System;
using System.Collections.Generic;
using ClassLibrary.HarborFramework;
using ClassLibrary.HarborFramework.DockingInfo;
using ClassLibrary.HarborFramework.ShipInfo;

/// <summary>
/// Representerer historikken til et skip, inkludert dokkinger og lastinger.
/// </summary>
public class ShipHistory
{
    /// <summary>
    /// Får eller setter listen over dokkinger knyttet til skipet.
    /// </summary>
    private List<Docking> Dockings { get; set; }
    private List<ShipEvent> Events { get; set; } = new List<ShipEvent>();


    /// <summary>
    /// Får eller setter listen over lastinger knyttet til skipet.
    /// </summary>
    private List<Loading> Loadings { get; set; }

    /// <summary>
    /// Initialiserer en ny forekomst av <see cref="ShipHistory"/>-klassen.
    /// </summary>
    public ShipHistory()
    {
        Dockings = new List<Docking>();
        Loadings = new List<Loading>();
    }

    /// <summary>
    /// Legger til en dokking i skipets historikk.
    /// </summary>
    /// <param name="docking">Dokkingen som skal legges til.</param>
    public void AddDocking(Docking docking)
    {
        Dockings.Add(docking);
    }

    /// <summary>
    /// Legger til en lasting i skipets historikk.
    /// </summary>
    /// <param name="loading">Lastingen som skal legges til.</param>
    public void AddLoading(Loading loading)
    {
        Loadings.Add(loading);
    }

    /// <summary>
    /// Viser historikken over dokkinger og lastinger knyttet til skipet.
    /// </summary>
    public void DisplayDockingHistory()
    {
        Console.WriteLine("Dokkinghistorikk:");
        foreach (var docking in Dockings)
        {
            Console.WriteLine($"Dokket ved: {docking.dockSpace}, Tidspunkt: {docking.timestamp}");
        }

        Console.WriteLine("\nLastehistorikk:");
        foreach (var loading in Loadings)
        {
            Console.WriteLine($"Lastet ved: {loading.LoadingPlace}, Tidspunkt: {loading.Timestamp}");
        }
    }

    /// <summary>
    /// Registrerer en ankomst ved en spesifikk DockSpace og tidspunkt.
    /// </summary>
    /// <param name="dockSpace">DockSpace hvor ankomsten skjedde.</param>
    /// <param name="arrivalTime">Tidspunktet for ankomsten.</param>
    public void AddArrival(DockSpace dockSpace, DateTime arrivalTime)
    {
        Events.Add(new ShipEvent(arrivalTime, dockSpace, Enums.EventType.Arrival));
    }

    /// <summary>
    /// Registrerer en avgang fra en spesifikk DockSpace og tidspunkt.
    /// </summary>
    /// <param name="dockSpace">DockSpace hvor avgangen skjedde.</param>
    /// <param name="departureTime">Tidspunktet for avgangen.</param>
    public void AddDeparture(DockSpace dockSpace, DateTime departureTime)
    {
        Events.Add(new ShipEvent(departureTime, dockSpace, Enums.EventType.Departure));
    }

    /// <summary>
    /// Viser en kronologisk historikk av alle ankomster og avganger.
    /// </summary>
    public void DisplayEventHistory()
    {
        foreach (var shipEvent in Events.OrderBy(e => e.EventTime))
        {
            string eventType = shipEvent.Type == Enums.EventType.Arrival ? "Ankomst" : "Avgang";
            Console.WriteLine($"{eventType} ved DockSpace {shipEvent.DockSpace.DockSpaceNumber} - Tid: {shipEvent.EventTime}");
        }
    }
}
