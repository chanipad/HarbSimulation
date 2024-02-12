using System;
using System.Collections.Generic;
using ClassLibrary.HarborFramework.DockingInfo;

/// <summary>
/// Representerer historikken til et skip, inkludert dokkinger og lastinger.
/// </summary>
public class ShipHistory
{
    /// <summary>
    /// Får eller setter listen over dokkinger knyttet til skipet.
    /// </summary>
    private List<Docking> Dockings { get; set; }

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
    public void DisplayHistory()
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
}
