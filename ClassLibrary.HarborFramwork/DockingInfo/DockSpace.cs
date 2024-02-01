using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.HarborFramwork.ShipInfo;

namespace ClassLibrary.HarborFramwork.DockingInfo
{
    internal class DockSpace
    {
        private int dockSpaceNumber { get; set; }
        private DockSpaceType type { get; set; }
        private List<ShipType> allowedShipTypes { get; set; }

        public void configuraDockSpace() { }
    }
}
