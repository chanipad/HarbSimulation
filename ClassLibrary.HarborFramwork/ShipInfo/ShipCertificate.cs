namespace ClassLibrary.HarborFramework.ShipInfo
{
    /// <summary>
    /// Represents the certificate information of a ship.
    /// </summary>
    public class ShipCertificate
    {
        /// <summary>
        /// Gets or sets the unique identifier of the certificate.
        /// </summary>
        public int CertificateID { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the certificate.
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the ship has access control clearance.
        /// </summary>
        public bool HasAccessControlClearance { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the inspection of cargo and ship supplies has been performed.
        /// </summary>
        public bool IsInspectionPerformed { get; set; }

        /// <summary>
        /// Validates the ship certificate.
        /// </summary>
        public static bool ValidateCertificate(ShipCertificate certificate)
        {
            // This check if the certificate is expired
            if (certificate.ExpirationDate <= DateTime.Now)
            {
                return false;
            }

            return certificate.HasAccessControlClearance && certificate.IsInspectionPerformed;
        }
    }
}
