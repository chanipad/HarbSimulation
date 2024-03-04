using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Exceptions
{
    public class InvalidShipIdException : Exception
    {
        public InvalidShipIdException(string message) 
            : base($"Invalid ship ID: {message}.") { }
        public InvalidShipIdException(string message, Exception inner) 
            : base($"Invalid ship ID: {message}.", inner) { }
    }

    public class CertificateValidationException : Exception
    {
        public CertificateValidationException(string message) 
            : base($"Certificate validation failed: {message}.") { }
        public CertificateValidationException(string message, Exception inner) 
            : base($"Certificate validation failed: {message}.", inner) { }
    }

    public class EventSchedulingException : Exception
    {
        public EventSchedulingException(string message) 
            : base($"Event scheduling issue: {message}.") { }
        public EventSchedulingException(string message, Exception inner) 
            : base($"Event scheduling issue: {message}.", inner) { }
    }

    public class HistoricalDataNotFoundException : Exception
    {
        public HistoricalDataNotFoundException(string message) 
            : base($"Historical data not found: {message}.") { }
        public HistoricalDataNotFoundException(string message, Exception inner) 
            : base($"Historical data not found: {message}.", inner) { }
    }

    public class UnrecognizedShipTypeException : Exception
    {
        public UnrecognizedShipTypeException(string message) 
            : base($"Unrecognized ship type: {message}.") { }
        public UnrecognizedShipTypeException(string message, Exception inner) 
            : base($"Unrecognized ship type: {message}.", inner) { }
    }

    public class SpeedCalculationException : Exception
    {
        public SpeedCalculationException(string message) 
            : base($"Speed calculation error: {message}.") { }
        public SpeedCalculationException(string message, Exception inner) 
            : base($"Speed calculation error: {message}.", inner) { }
    }

}
