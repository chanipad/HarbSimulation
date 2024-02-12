using ClassLibrary.HarborFramework;
using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramework.DockingInfo;
using ClassLibrary.HarborFramework.ShipInfo;
using static ClassLibrary.HarborFramework.ContainerYardInfo.Container;
using static ClassLibrary.HarborFramework.Enums;

namespace HarbSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Harbor Simulation!");

            
            Ship cargoShip = new Ship(1, ShipType.CARGO_SHIP);


            // Opprett en ny dokking ved å bruke konstruktøren som tar imot DockSpace og TimeSlot som parametre
            Docking docking = new Docking(dockSpace: new DockSpace(1),new TimeSlot());
            cargoShip.GetHistory().AddDocking(docking);

            Loading loading = new Loading(containerYards: new ContainerYards(), new TimeSlot());
            cargoShip.GetHistory().AddLoading(loading);


            ShipCertificate certificate = new ShipCertificate
            {
                CertificateID = 544,
                ExpirationDate = DateTime.Now.AddDays(15),
                HasAccessControlClearance = true,
                IsInspectionPerformed = true
            };

            
            bool isValid = ShipCertificate.ValidateCertificate(certificate);

            
            Console.WriteLine($"This Certificate is valid: {isValid}");

      
            cargoShip.GetHistory().DisplayHistory();





            /* / Opprett en ny beholder med en ID
            Container container1 = new Container(1);

            // Legg til noen steder i beholderen
            container1.AddNewLocation(new Location(1, DateTime.Now));
            
            // Skriv ut informasjon om beholderen
            container1.Print();
            */
            // Opprett en ny dokkrom med et nummer
            DockSpace dockSpace = new DockSpace(1);

            // Opprett en ny lokasjon og koble den til dokkrommet
            Location location = new Location("Dock 1", DateTime.Now, dockSpace);

            // Opprett en ny beholder med en ID
            Container container1 = new Container(1);

            // Legg til noen steder i beholderen
            container1.AddNewLocation(new Location("Location 1", DateTime.Now, dockSpace),

            // Legg til noen steder i beholderen
            container1.GetTimestamp());
            container1.AddNewLocation(new Location("Location 2", DateTime.Now, dockSpace), container1.GetTimestamp());
            container1.AddNewLocation(new Location("Location 3", DateTime.Now, dockSpace), container1.GetTimestamp());

            // Skriv ut informasjon om beholderen
            //container1.Print();
          
         
            // Skriv ut informasjon om lokasjonen
            Console.WriteLine($"Location Dock: {location.DockLocation}");
            Console.WriteLine($"Timestamp: {location.Timestamp}");
            Console.WriteLine($"Associated DockSpace Number: {location.DockSpace.DockSpaceNumber}");
           
            

        }
    }
}
