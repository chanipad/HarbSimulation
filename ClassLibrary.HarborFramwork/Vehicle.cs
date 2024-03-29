﻿using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramework.Exceptions;

namespace ClassLibrary.HarborFramework
{
    public class Vehicle
    {
        public Enums.Vehicle Type { get; set; }
        public List<Container> Containers { get; set; } = new List<Container>();
        public int Capacity { get; set; }

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

        public Container UnloadContainer()
        {
            if (Containers.Count > 0)
            {
                var container = Containers[0];
                Containers.RemoveAt(0);
                return container;
            }
            return null;
        }
    }
}
