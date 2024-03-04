using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.Exceptions
{
    public class ContainerNotFoundException : Exception
    {
        public ContainerNotFoundException(string message) : base($"Container not found: {message}. Please verify the container ID.") { }
        public ContainerNotFoundException(string message, Exception inner) : base($"Container not found: {message}. Please verify the container ID.", inner) { }
    }

    public class LoadingScheduleConflictException : Exception
    {
        public LoadingScheduleConflictException(string message) : base($"Loading schedule conflict: {message}. Please review and adjust the loading schedule.") { }
        public LoadingScheduleConflictException(string message, Exception inner) : base($"Loading schedule conflict: {message}. Please review and adjust the loading schedule.", inner) { }
    }

    public class InvalidContainerOperationException : Exception
    {
        public InvalidContainerOperationException(string message) : base($"Invalid operation for container: {message}. Operation not permitted in the current state or with the given parameters.") { }
        public InvalidContainerOperationException(string message, Exception inner) : base($"Invalid operation for container: {message}. Operation not permitted in the current state or with the given parameters.", inner) { }
    }

    public class ContainerYardCapacityExceededException : Exception
    {
        public ContainerYardCapacityExceededException(string message) : base($"Container yard capacity exceeded: {message}. No additional containers can be accommodated.") { }
        public ContainerYardCapacityExceededException(string message, Exception inner) : base($"Container yard capacity exceeded: {message}. No additional containers can be accommodated.", inner) { }
    }

    public class InvalidLoadingOperationException : Exception
    {
        public InvalidLoadingOperationException(string message) : base($"Invalid loading operation: {message}. Check the parameters or state and try again.") { }
        public InvalidLoadingOperationException(string message, Exception inner) : base($"Invalid loading operation: {message}. Check the parameters or state and try again.", inner) { }
    }

}
