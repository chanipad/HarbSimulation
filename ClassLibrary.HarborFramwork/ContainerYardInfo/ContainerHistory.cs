using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.HarborFramwork.DockingInfo;

namespace ClassLibrary.HarborFramwork.ContainerYardInfo
{
    internal class ContainerHistory
    {
        private List<Location> locations { get; set; }
        public int getContainerHistory(int containerId) { return locations.Count; }
    }
}
