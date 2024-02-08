using ClassLibrary.HarborFramework;
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
            Docking docking = new Docking(dockSpace: new DockSpace(1), null);
            cargoShip.GetHistory().AddDocking(docking);

            Loading loading = new Loading(containerYards: new ContainerYards(), null);
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
        }
    }
}
