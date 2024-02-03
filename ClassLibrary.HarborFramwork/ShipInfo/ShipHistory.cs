using ClassLibrary.HarborFramework.DockingInfo;
using System;
using System.Collections.Generic;

namespace ClassLibrary.HarborFramework.ShipInfo
{
    /// <summary>
    /// Represents the history of a ship, including dockings and loadings.
    /// </summary>
    public class ShipHistory
    {
        private List<Docking> Dockings { get; set; }
        private List<Loading> Loadings { get; set; }

        public ShipHistory()
        {
            Dockings = new List<Docking>();
            Loadings = new List<Loading>();
        }

        public void AddDocking(Docking docking)
        {
            Dockings.Add(docking);
        }

        public void AddLoading(Loading loading)
        {
            Loadings.Add(loading);
        }

        public void DisplayHistory()
        {
            Console.WriteLine("Docking History:");
            foreach (var docking in Dockings)
            {
                Console.WriteLine($"Docked at: {docking.DockingPlace}, Time: {docking.Timestamp}");
            }

            Console.WriteLine("\nLoading History:");
            foreach (var loading in Loadings)
            {
                Console.WriteLine($"Loaded at: {loading.LoadingPlace}, Time: {loading.Timestamp}");
            }
        }
    }
}
