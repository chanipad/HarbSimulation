using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Exceptions
{
    public class ContainerNotFoundException : Exception
    {
        public ContainerNotFoundException(string message)
            : base($"Container not found: {message}. Please verify the container ID.") { }
    }

    public class LoadingScheduleConflictException : Exception
    {
        public LoadingScheduleConflictException(string message)
            : base($"Loading schedule conflict: {message}. Please review and adjust the loading schedule.") { }
    }

    public class InvalidContainerOperationException : Exception
    {
        public InvalidContainerOperationException(string message)
            : base($"Invalid operation for container: {message}. Operation not permitted in the current state or with the given parameters.") { }
    }

    public class ContainerYardCapacityExceededException : Exception
    {
        public ContainerYardCapacityExceededException(string message)
            : base($"Container yard capacity exceeded: {message}. No additional containers can be accommodated.") { }
    }

    public class InvalidLoadingOperationException : Exception
    {
        public InvalidLoadingOperationException(string message)
            : base($"Invalid loading operation: {message}. Check the parameters or state and try again.") { }
    }

    public class NoAvailableCranesException : Exception
    {
        public NoAvailableCranesException()
            : base("No available cranes for the scheduled time.") { }
    }

    public class AGVUnavailableException : Exception
    {
        public AGVUnavailableException(string message)
            : base($"AGV unavailable: {message}. Please check the availability of AGVs and try again.") { }
    }

    public class InvalidStorageColumnOperationException : Exception
    {
        public InvalidStorageColumnOperationException(string message)
            : base($"Invalid storage column operation: {message}. Check the operation and try again.") { }
    }
}
