using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Exceptions
{
    public class InvalidSailingDateException : Exception
    {
        public InvalidSailingDateException(string message) 
            : base($"Invalid sailing date: {message}.") { }
        public InvalidSailingDateException(string message, Exception inner) 
            : base($"Invalid sailing date: {message}.", inner) { }
    }

    public class SailingScheduleConflictException : Exception
    {
        public SailingScheduleConflictException(string message) 
            : base($"Sailing schedule conflict: {message}.") { }
        public SailingScheduleConflictException(string message, Exception inner) 
            : base($"Sailing schedule conflict: {message}.", inner) { }
    }

    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message) 
            : base($"Unauthorized access: {message}.") { }
        public UnauthorizedAccessException(string message, Exception inner) 
            : base($"Unauthorized access: {message}.", inner) { }
    }

    public class InspectionFailureException : Exception
    {
        public InspectionFailureException(string message) 
            : base($"Inspection failure: {message}.") { }
        public InspectionFailureException(string message, Exception inner) 
            : base($"Inspection failure: {message}.", inner) { }
    }

    public class RegulationComplianceException : Exception
    {
        public RegulationComplianceException(string message) 
            : base($"Regulation compliance issue: {message}.") { }
        public RegulationComplianceException(string message, Exception inner) 
            : base($"Regulation compliance issue: {message}.", inner) { }
    }

}
