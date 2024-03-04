using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Exceptions
{
    public class InvalidTideLevelException : Exception
    {
        public InvalidTideLevelException()
            : base("The tide level provided is invalid.") { }

        public InvalidTideLevelException(string message)
            : base(message) { }

        public InvalidTideLevelException(string message, Exception inner)
            : base(message, inner) { }
    }

    public class TideInformationNotFoundException : Exception
    {
        public TideInformationNotFoundException()
            : base("Tide information for the specified date and time could not be found.") { }

        public TideInformationNotFoundException(string message)
            : base(message) { }

        public TideInformationNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
