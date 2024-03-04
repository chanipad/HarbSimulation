using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Exceptions
{
    internal class DockingExceptions
    {
        public class InvalidContainerIdException : Exception
        {
            public InvalidContainerIdException(string message)
                : base($"Invalid container ID: {message}. Ensure the container ID is correct and try again.") { }
            public InvalidContainerIdException(string message, Exception inner)
                : base($"Invalid container ID: {message}. Ensure the container ID is correct and try again.", inner) { }
        }

        public class LocationAlreadyExistsException : Exception
        {
            public LocationAlreadyExistsException(string message)
                : base($"Location already exists: {message}. Duplicate locations are not allowed.") { }
            public LocationAlreadyExistsException(string message, Exception inner)
                : base($"Location already exists: {message}. Duplicate locations are not allowed.", inner) { }
        }

        public class NoLocationsFoundException : Exception
        {
            public NoLocationsFoundException(string message)
                : base($"No locations found: {message}. Ensure the container has recorded locations.") { }
            public NoLocationsFoundException(string message, Exception inner)
                : base($"No locations found: {message}. Ensure the container has recorded locations.", inner) { }
        }

        public class ContainerFullException : Exception
        {
            public ContainerFullException(string message)
                : base($"Container is full: {message}. No more locations can be added.") { }
            public ContainerFullException(string message, Exception inner)
                : base($"Container is full: {message}. No more locations can be added.", inner) { }
        }

        public class InvalidLocationException : Exception
        {
            public InvalidLocationException(string message)
                : base($"Invalid location: {message}. Check the location details and try again.") { }
            public InvalidLocationException(string message, Exception inner)
                : base($"Invalid location: {message}. Check the location details and try again.", inner) { }
        }

        public class DockingException : Exception
        {
            public DockingException(string message)
                : base($"Docking error: {message}. Review docking parameters and conditions.") { }
            public DockingException(string message, Exception inner)
                : base($"Docking error: {message}. Review docking parameters and conditions.", inner) { }
        }
    }
}
