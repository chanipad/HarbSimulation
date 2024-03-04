using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.Exceptions
{
    internal class ContainerException : Exception
    {
        public ContainerException() { }
        public ContainerException(string message) : base(message) { }
        public ContainerException(string message, Exception inner) : base(message, inner) { }
    }
}
