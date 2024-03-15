using ClassLibrary.HarborFramework.ContainerYardInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Interfaces
{
    public interface ITransportVehicle
    {
        void LoadContainer(Container container);
        void DeliverContainer(string destination);
    }

    public class Truck : ITransportVehicle
    {
        public void LoadContainer(Container container)
        {
            Console.WriteLine($"Container {container.ContainerId} is loaded onto the truck.");
        }

        public void DeliverContainer(string destination)
        {
            Console.WriteLine($"Truck is delivering the container to {destination}.");
        }
    }

    public class AGV : ITransportVehicle
    {
        public void LoadContainer(Container container)
        {
            Console.WriteLine($"Container {container.ContainerId} is loaded onto the AGV.");
        }

        public void DeliverContainer(string destination)
        {
            Console.WriteLine($"AGV is moving the container to storage location {destination}.");
        }
    }

}
