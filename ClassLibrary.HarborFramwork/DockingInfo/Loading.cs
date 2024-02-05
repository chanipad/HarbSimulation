using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.HarborFramwork.Utilities;
using static ClassLibrary.HarborFramwork.ContainerYardInfo.Container;

namespace ClassLibrary.HarborFramwork.DockingInfo
{
    public class Loading
    {
        public object LoadingPlace { get; internal set; }
        private ContainerYards containerYards { get; set; }
        public TimeSlot timestamp { get; set; }
    }
}
