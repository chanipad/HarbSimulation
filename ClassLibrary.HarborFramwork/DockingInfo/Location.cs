using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.HarborFramwork.Utilities;

namespace ClassLibrary.HarborFramwork.DockingInfo
{
    public class Location
    {
        public required TimeSlot timestamp { get; set; }
        public int location { get; set; }
    }
}
