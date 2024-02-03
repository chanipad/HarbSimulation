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
        /// Validates the ship certificate.
        /// </summary>
        public static bool ValidateCertificate(ShipCertificate certificate)
        {
            // This check if the certificate is expired
            return certificate.ExpirationDate > DateTime.Now;
        }
    }
}
