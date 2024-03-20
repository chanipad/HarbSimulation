using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramwork.Exceptions;
using System.Linq;

namespace ClassLibrary.HarborFramework
{
    public class Vehicle
    {
        public Enums.Vehicle Type { get; set; }
        private List<Container> Containers { get; set; } = new List<Container>();
        public Vehicle(Enums.Vehicle type)
        {
            Type = type;
        }

        public void LoadContainer(Container container)
        {
            try
            {
                Containers.Add(container);
            }
            catch (Exception ex)
            {
                throw new ContainerYardCapacityExceededException($"Failed to load container on {Type}.", ex);
            }
            Console.WriteLine($"Container {container.ContainerId} is loaded onto the {Type}.");
        }

        public Container DeliverContainer(string destination)
        {
            Console.WriteLine($"{Type} is delivering the container to {destination}.");
            return Containers[0];
        }
    }
}
