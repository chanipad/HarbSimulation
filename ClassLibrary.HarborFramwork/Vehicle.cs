using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramwork.Exceptions;

namespace ClassLibrary.HarborFramework
{
    public class Vehicle
    {
        public Enums.Vehicle Type { get; set; }
        private List<Container> Containers { get; set; } = new List<Container>();
        private int Capacity { get; set; }

        public Vehicle(Enums.Vehicle type, int ContainerCapacity)
        {
            Type = type;
            Capacity = ContainerCapacity;
        }

        public void LoadContainer(Container container)
        {
            if (Containers.Count >= Capacity)
            {
                throw new ContainerYardCapacityExceededException($"Cannot load container. {Type} has reached its maximum capacity of {Capacity} containers.");
            }
            if (Containers.Any(c => c.ContainerId == container.ContainerId))
            {
                Console.WriteLine($"Container {container.ContainerId} is already loaded onto the {Type}.");
                return;
            }
            try
            {
                Containers.Add(container);
                Console.WriteLine($"Container {container.ContainerId} is loaded onto the {Type}.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load container on {Type}.", ex);
            }
        }

        public Container DeliverContainer(string destination)
        {
            Console.WriteLine($"{Type} is delivering the container to {destination}.");
            return Containers[0];
        }
    }
}
