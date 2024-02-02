using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.ShipInfo
{
    public class ShipCertificate
    {
        private int CertificateID { get; set; }
        private DateTime ExpirationDate { get; set; }

        public static void ValidateCertificate()
        {
            // Implementasjoner for sertifikatvalidering
        }
    }
}
