using ClassLibrary.HarborFramework.ShipInfo;

using static ClassLibrary.HarborFramework.Enums;

/// <summary>
/// Represents a ship in the harbor.
/// </summary>
public class Ship
{
    /// <summary>
    /// Gets the unique identifier of the ship.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets or sets the name of the ship.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the type of the ship.
    /// </summary>
    private ShipType ShipType { get; set; }

    /// <summary>
    /// Gets the history of the ship.
    /// </summary>
    private ShipHistory History { get; set; }

    /// <summary>
    /// Gets the certificate of the ship.
    /// </summary>
    private ShipCertificate Certificate { get; set; }

    private DateTime dateTime { get; set; }

    /// <summary>
    /// Gets or sets the type of the ship.
    /// </summary>
    public ShipType Type { get; internal set; }

    /// <summary>
    /// Gets or sets a value indicating whether the ship has been inspected.
    /// </summary>
    public bool Inspected { get; internal set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Ship"/> class with the specified ID and ship type.
    /// </summary>
    /// <param name="id">The unique identifier of the ship.</param>
    /// <param name="shipType">The type of the ship.</param>
    public Ship(int id, ShipType shipType)
    {
        Id = id;
        ShipType = shipType;
        History = new ShipHistory();
        Certificate = new ShipCertificate();
    }

    public Ship(int id, ShipType shipType, DateTime dateTime)
    {
        Id = id;
        ShipType = shipType;
        History = new ShipHistory();
        Certificate = new ShipCertificate();
        this.dateTime = dateTime;
    }

    /// <summary>
    /// Gets the history of the ship.
    /// </summary>
    /// <returns>The history of the ship.</returns>
    public ShipHistory GetHistory()
    {
        return History;
    }
}
