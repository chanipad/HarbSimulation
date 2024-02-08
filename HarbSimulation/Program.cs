using System;
using ClassLibrary.HarborFramework.ShipInfo;

namespace HarbSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Harbor Simulation!");

            
            Ship cargoShip = new Ship(1, ShipType.CARGO_SHIP);

           
            cargoShip.GetHistory().AddDocking(new Docking { DockSpace = "First place", Timestamp = DateTime.Now });
            cargoShip.GetHistory().AddLoading(new Loading { Loading = "Cargo Area 1", Timestamp = DateTime.Now });

            
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
        }
    }
}
