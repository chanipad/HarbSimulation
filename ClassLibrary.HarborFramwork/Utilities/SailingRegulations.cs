using ClassLibrary.HarborFramework.ShipInfo;
using ClassLibrary.HarborFramework.Utilities;
using System.Security.AccessControl;


namespace ClassLibrary.HarborFramework.Utilities
{
    public class SailingRegulations
    {
        private AccessControlActions accessControl { get; set; }
        private List<ShipCertificate>? shipCertificates { get; set; }
        private List<Inspection>? inspectionHistory { get; set; }
    }
}
