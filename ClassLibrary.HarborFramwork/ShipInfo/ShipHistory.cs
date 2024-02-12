using ClassLibrary.HarborFramework.DockingInfo;

/// <summary>
/// Represents the history of a ship, including dockings and loadings.
/// </summary>
public class ShipHistory
{
    /// <summary>
    /// Gets or sets the list of dockings associated with the ship.
    /// </summary>
    private List<Docking> Dockings { get; set; }

    /// <summary>
    /// Gets or sets the list of loadings associated with the ship.
    /// </summary>
    private List<Loading> Loadings { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ShipHistory"/> class.
    /// </summary>
    public ShipHistory()
    {
        Dockings = new List<Docking>();
        Loadings = new List<Loading>();
    }

    /// <summary>
    /// Adds a docking record to the ship's history.
    /// </summary>
    /// <param name="docking">The docking record to add.</param>
    public void AddDocking(Docking docking)
    {
        Dockings.Add(docking);
    }

    /// <summary>
    /// Adds a loading record to the ship's history.
    /// </summary>
    /// <param name="loading">The loading record to add.</param>
    public void AddLoading(Loading loading)
    {
        Loadings.Add(loading);
    }

    /// <summary>
    /// Displays the history of dockings and loadings associated with the ship.
    /// </summary>
    public void DisplayHistory()
    {
        Console.WriteLine("Docking History:");
        foreach (var docking in Dockings)
        {
            Console.WriteLine($"Docked at: {docking.dockSpace}, Time: {docking.timestamp}");
        }

        Console.WriteLine("\nLoading History:");
        foreach (var loading in Loadings)
        {
            Console.WriteLine($"Loaded at: {loading.LoadingPlace}, Time: {loading.Timestamp}");
        }
    }
}
