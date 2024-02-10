using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Interfaces
{
    public interface ILocation
    {
        DateTime Timestamp { get; set; }
        int Location { get; set; }
    }
}
