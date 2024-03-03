namespace ClassLibrary.HarborFramework.ShipInfo
{
    /// <summary>
    /// Representerer informasjon om et skips sertifikat.
    /// </summary>
    public class ShipCertificate
    {
        /// <summary>
        /// Får eller setter den unike identifikatoren til sertifikatet.
        /// </summary>
        public int CertificateID { get; set; }

        /// <summary>
        /// Får eller setter utløpsdatoen for sertifikatet.
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Får eller setter en indikator på om skipet har klarering for tilgangskontroll.
        /// </summary>
        public bool HasAccessControlClearance { get; set; }

        /// <summary>
        /// Får eller setter en indikator på om inspeksjon av last og skipsforsyninger har blitt utført.
        /// </summary>
        public bool IsInspectionPerformed { get; set; }

        /// <summary>
        /// Validerer skipsertifikatet.
        /// </summary>
        /// <param name="certificate">Sertifikatet som skal valideres.</param>
        /// <returns>Sann hvis sertifikatet er gyldig, ellers usann.</returns>
        public static bool ValidateCertificate(ShipCertificate certificate)
        {
            // Denne sjekken ser om sertifikatet er utløpt
            if (certificate.ExpirationDate <= DateTime.Now)
            {
                return false;
            }

            return certificate.HasAccessControlClearance && certificate.IsInspectionPerformed;
        }
    }
}
