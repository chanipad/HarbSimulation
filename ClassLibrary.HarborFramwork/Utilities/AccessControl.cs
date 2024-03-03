using ClassLibrary.HarborFramework.ShipInfo;
using System.Collections.Generic;

namespace ClassLibrary.HarborFramework.Utilities
{
    /// <summary>
    /// Administrerer tilgangskontroll for skip, som tillater å gi og fjerne tilgang.
    /// </summary>
    public class AccessControl
    {
        /// <summary>
        /// Initialiserer en ny instans av <see cref="AccessControl"/> klassen.
        /// </summary>
        public AccessControl()
        {
            accessList = new List<Ship>();
        }

        /// <summary>
        /// Får eller setter listen over skip som har blitt gitt tilgang.
        /// </summary>
        private List<Ship> accessList { get; set; } = new List<Ship>();

        /// <summary>
        /// Gir tilgang til det spesifiserte skipet, legger det til i tilgangslisten hvis det ikke allerede er til stede.
        /// </summary>
        /// <param name="ship">Skipet som skal gis tilgang.</param>
        /// <remarks>
        /// Hvis skipet allerede er i tilgangslisten, vil det ikke bli lagt til igjen.
        /// </remarks>
        public void GrantAccess(Ship ship)
        {
            if (!accessList.Contains(ship))
            {
                accessList.Add(ship);
            }
        }

        /// <summary>
        /// Fjerner tilgang fra det spesifiserte skipet, fjerner det fra tilgangslisten.
        /// </summary>
        /// <param name="ship">Skipet som tilgangen skal fjernes fra.</param>
        /// <remarks>
        /// Hvis skipet ikke finnes i tilgangslisten, tas ingen handling.
        /// </remarks>
        public void RevokeAccess(Ship ship)
        {
            accessList.Remove(ship);
        }

        /// <summary>
        /// Sjekker om det spesifiserte skipet har blitt gitt tilgang.
        /// </summary>
        /// <param name="ship">Skipet som det skal sjekkes tilgang for.</param>
        /// <returns><c>true</c> hvis skipet har tilgang; ellers, <c>false</c>.</returns>
        /// <remarks>
        /// Tilgang bestemmes av skipets tilstedeværelse i tilgangslisten.
        /// </remarks>
        public bool HasAccess(Ship ship)
        {
            return accessList.Contains(ship);
        }
    }
}
