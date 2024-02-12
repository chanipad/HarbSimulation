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

            Ship CRUISE_SHIP = new Ship(2, ShipType.CRUISE_SHIP, DateTime.Now);


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
        }
    }
}
