using ClassLibrary.HarborFramework.ContainerYardInfo;

namespace ClassLibrary.HarborFramework
{
    public class Vehicle
    {
        public Enums.Vehicle Type { get; set; }

        public Vehicle(Enums.Vehicle type)
        {
            Type = type;
        }

        public void LoadContainer(Container container)
        {
            Console.WriteLine($"Container {container.ContainerId} is loaded onto the {Type}.");
        }

        public void DeliverContainer(string destination)
        {
            Console.WriteLine($"{Type} is delivering the container to {destination}.");
        }
    }
}
