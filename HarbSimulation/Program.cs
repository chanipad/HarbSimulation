using ClassLibrary.HarborFramework;
using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramework.DockingInfo;
using ClassLibrary.HarborFramework.ShipInfo;
using ClassLibrary.HarborFramework.Utilities;
using static ClassLibrary.HarborFramework.ContainerYardInfo.Container;
using static ClassLibrary.HarborFramework.Enums;

namespace HarbSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Harbor Simulation!");

            // Initialiserer skipet
            Ship ChanipaBoat = new Ship(1, ShipType.CRUISE_SHIP);

            // Definerer DockSpaces
            DockSpace dockSpace1 = new DockSpace(2);
            dockSpace1.ConfigureDockSpace(DockSpaceType.CRUISE, new List<ShipType> { ShipType.CRUISE_SHIP });

            // Kalkulerer reisetid (forenklet og eksempel)
            int distance = 500; // Avstand på 500 meter
            int travelTime = ShipSpeeds.TravelTime(ShipType.CRUISE_SHIP, distance); // Beregner reisetid

            // Registrerer ankomst og avgang
            ChanipaBoat.GetHistory().AddArrival(dockSpace1, new DateTime(2024, 2, 1, 12, 19, 10));
            ChanipaBoat.GetHistory().AddDeparture(dockSpace1, new DateTime(2024, 2, 1, 13, 22, 12));

            // Viser skipets historikk
            ChanipaBoat.GetHistory().DisplayEventHistory();

            // Viser beregnet reisetid
            Console.WriteLine($"Beregnet reisetid for HanjiBoat over {distance} meter: {travelTime} Minutter");
        }
    }
}