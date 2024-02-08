using ClassLibrary.HarborFramework.ShipInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Utilities
{
    internal class SailingRegulations
    {
        private AccessControlActions accessControl { get; set; }
        private List<ShipCertificate> shipCertificates { get; set; }
        private List<Inspection> inspectionHistory { get; set; }
    }
}
