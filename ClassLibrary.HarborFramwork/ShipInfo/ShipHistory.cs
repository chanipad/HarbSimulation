using ClassLibrary.HarborFramwork.DockingInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.ShipInfo
{
    internal class ShipHistory
    {
        private List<Docking> docking { get; set; }
        private List<Loading> loading { get; set; }
    }
}
