using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.HarborFramework.DockingInfo;
using ClassLibrary.HarborFramework.ShipInfo;
using static ClassLibrary.HarborFramework.Enums;

/// <summary>
/// Representerer et skip i havnen.
/// </summary>
public class Ship
{
    /// <summary>
    /// Får den unike identifikatoren til skipet.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Får eller setter navnet på skipet.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Får typen til skipet.
    /// </summary>
    public ShipType ShipType { get; private set; }

    private ShipHistory History { get; set; }
    private ShipCertificate Certificate { get; set; }

    /// <summary>
    /// Får eller setter datoen og tiden for skipet. Brukes for demonstrasjonsformål.
    /// </summary>
    public DateTime dateTime { get; internal set; }

    /// <summary>
    /// Får eller setter en verdi som indikerer om skipet har blitt inspisert.
    /// </summary>
    public bool Inspected { get; internal set; }

    /// <summary>
    /// Initialiserer en ny instans av <see cref="Ship"/>-klassen med spesifisert ID og skiptype.
    /// </summary>
    /// <param name="id">Den unike identifikatoren til skipet.</param>
    /// <param name="shipType">Typen til skipet.</param>
    public Ship(int id, ShipType shipType)
    {
        Id = id;
        ShipType = shipType;
        History = new ShipHistory();
        Certificate = new ShipCertificate();
        dateTime = DateTime.Now; // Setter en standardverdi for demonstrasjon
    }

    /// <summary>
    /// Registrerer en ankomst for skipet ved en spesifisert DockSpace og tidspunkt.
    /// </summary>
    /// <param name="dockSpace">DockSpace hvor ankomsten skjedde.</param>
    /// <param name="arrivalTime">Tidspunktet for ankomsten.</param>
    public void AddArrival(DockSpace dockSpace, DateTime arrivalTime)
    {
        History.AddArrival(dockSpace, arrivalTime);
    }

    /// <summary>
    /// Registrerer en avgang for skipet fra en spesifisert DockSpace og tidspunkt.
    /// </summary>
    /// <param name="dockSpace">DockSpace hvor avgangen skjedde.</param>
    /// <param name="departureTime">Tidspunktet for avgangen.</param>
    public void AddDeparture(DockSpace dockSpace, DateTime departureTime)
    {
        History.AddDeparture(dockSpace, departureTime);
    }

    /// <summary>
    /// Henter historikken til skipet som en streng.
    /// </summary>
    /// <returns>En streng som representerer historikken til skipet med alle registrerte ankomster og avganger.</returns>
    public string GetHistory()
    {
        var eventHistory = new System.Text.StringBuilder();
        eventHistory.AppendLine("Hendelseshistorikk:");

        foreach (var shipEvent in History.Events.OrderBy(e => e.EventTime))
        {
            string eventType = shipEvent.Type == EventType.Arrival ? "Ankomst" : "Avgang";
            eventHistory.AppendLine($"{eventType} ved DockSpace {shipEvent.DockSpace.DockSpaceNumber} - Tid: {shipEvent.EventTime}");
        }

        return eventHistory.ToString();
    }
}
