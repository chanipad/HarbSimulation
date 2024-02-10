using ClassLibrary.HarborFramework.MarineData;
using System;
using static ClassLibrary.HarborFramework.Enums;
using ClassLibrary.HarborFramework;
using ClassLibrary.HarborFramework.ContainerYardInfo;
using static ClassLibrary.HarborFramework.ContainerYardInfo.Container;
using ClassLibrary.HarborFramework.DockingInfo;
using ClassLibrary.HarborFramework.ShipInfo;

namespace HarbSimulation
{
    public class Program
    {

        static void Main(string[] args)
        {


            Console.WriteLine("Welcome to the Harbor Simulation!");


            Ship cargoShip = new Ship(1, ShipType.CARGO_SHIP);


            //cargoShip.GetHistory().AddDocking(new Docking(DockSpace = "First place", Timestamp = DateTime.Now ));
            
            //cargoShip.GetHistory().AddLoading(new Loading { ContainerYards = "Cargo Area 1", Timestamp = DateTime.Now });
            
            cargoShip.GetHistory().AddDocking(new Docking("test1", DateTime.Now));



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

            
            
            TideInformation tideInfo = new TideInformation();
            // Set some tide levels
            tideInfo.SetTideLevel(new DateTime(2024, 2, 4), 5.2);
            tideInfo.SetTideLevel(new DateTime(2024, 2, 5), 3.8);
            // Get tide level for specific dates
            Console.WriteLine("Tide level on 2024-02-04: " + tideInfo.GetTideLevel(new DateTime(2024, 2, 4))); // Output: 5.2
            Console.WriteLine("Tide level on 2024-02-06: " + tideInfo.GetTideLevel(new DateTime(2024, 2, 6))); // Output: -1 (Tide information not available)

           
            
            
        }
    }
}
