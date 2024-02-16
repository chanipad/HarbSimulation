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
            /*
            // bruker test1
            // Opprett container med en unik ID
            var container = new Container(1);

            // Legg til noen lokasjoner i containerens historikk
            container.AddNewLocation(new Location("Dock C", DateTime.Now));
            container.AddNewLocation(new Location("Dock A", DateTime.Now.AddDays(1)));
            container.AddNewLocation(new Location("Dock B", DateTime.Now.AddDays(2)));

            // Hent og skriv ut containerens historikk til konsollen
            Console.WriteLine("Henter containerhistorikk og skriver ut til konsollen:");
            container.GetContainerHistory();
            */
            /*
            // bruker test2
            // Lag et dockspace
            var dockSpace = new DockSpace(1);

            // Konfigurer en DockSpace
            dockSpace.ConfigureDockSpace(DockSpaceType.CARGO, new List<ShipType> { ShipType.CARGO_SHIP });

            // Opprett et skip
            var ship = new Ship(1, ShipType.CARGO_SHIP);

            // Planlegg dokking
            var docking = new Docking(dockSpace, new TimeSlot { startTime = DateTime.Now, endTime = DateTime.Now.AddHours(2) });
            docking.ScheduleDocking(ship);
            */
            /*
            //bruker test3
            // Liste med skip
            var ships = new List<Ship>
            {
                new Ship(2, ShipType.CRUISE_SHIP),
                new Ship(3, ShipType.LEISURE_BOAT)
            };

            // Planlegg en tilfeldig inspeksjon av en liste med båter
            var inspection = new Inspection();
            inspection.ScheduleRandomInspection(ships);
            // utfør en tilfeldig inspeksjon
            inspection.PerformInspection();
            */

            //bruker test4
            // Initialiserer skipet med unik ID og skiptype
            Ship boat = new Ship(1, ShipType.CRUISE_SHIP);

            // Definerer en dokkplass som kan håndtere cruisefartøy
            DockSpace dockSpace1 = new DockSpace(101);
            dockSpace1.ConfigureDockSpace(DockSpaceType.CRUISE, new List<ShipType> { ShipType.CRUISE_SHIP });

            // Registrerer ankomst og avgang for skipet ved å benytte de nye direkte metodene
            boat.AddArrival(dockSpace1, new DateTime(2024, 2, 1, 12, 0, 0));
            boat.AddDeparture(dockSpace1, new DateTime(2024, 2, 1, 18, 0, 0));

            // Henter og viser hendelseshistorikken for skipet
            Console.WriteLine(boat.GetHistory());
        }
    }
}