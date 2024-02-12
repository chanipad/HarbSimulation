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
    private ShipType ShipType { get; set; }

    /// <summary>
    /// Får historikken til skipet.
    /// </summary>
    private ShipHistory History { get; set; }


    private DateTime dateTime { get; set; }
    /// <summary>
    /// Får sertifikatet til skipet.
    /// </summary>
    private ShipCertificate Certificate { get; set; }


    /// <summary>
    /// Får eller setter typen til skipet.
    /// </summary>
    public ShipType Type { get; internal set; }

    /// <summary>
    /// Får eller setter en verdi som indikerer om skipet har blitt inspisert.
    /// </summary>
    public bool Inspected { get; internal set; }

    /// <summary>
    /// Initialiserer en ny instans av <see cref="Ship"/>-klassen med den spesifiserte ID-en og skiptypen.
    /// </summary>
    /// <param name="id">Den unike identifikatoren til skipet.</param>
    /// <param name="shipType">Typen til skipet.</param>
    public Ship(int id, ShipType shipType)
    {
        Id = id;
        ShipType = shipType;
        History = new ShipHistory();
        Certificate = new ShipCertificate();
    }

    /// <summary>
    /// Initialiserer en ny instans av <see cref="Ship"/>-klassen med den spesifiserte ID-en, skiptypen og dato/tid.
    /// </summary>
    /// <param name="id">Den unike identifikatoren til skipet.</param>
    /// <param name="shipType">Typen til skipet.</param>
    /// <param name="dateTime">Dato/tid for skipet.</param>
    public Ship(int id, ShipType shipType, DateTime dateTime)
    {
        Id = id;
        ShipType = shipType;
        History = new ShipHistory();
        Certificate = new ShipCertificate();
        this.dateTime = dateTime;
    }

    /// <summary>
    /// Henter historikken til skipet.
    /// </summary>
    /// <returns>Historikken til skipet.</returns>
    public ShipHistory GetHistory()
    {
        return History;
    }
}
