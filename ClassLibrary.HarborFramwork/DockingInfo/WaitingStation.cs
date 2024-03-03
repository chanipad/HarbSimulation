using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.HarborFramework.DockingInfo;
using static ClassLibrary.HarborFramework.Enums;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en ventestasjon for evaluering av dokkeringslokasjoner.
    /// </summary>
    public class WaitingStation
    {
        /// <summary>
        /// Får eller setter lokasjonsnummeret til ventestasjonen.
        /// </summary>
        public int LocationNumber { get; set; }

        /// <summary>
        /// Sjekker om en spesifisert dokk er egnet for en gitt skiptype.
        /// </summary>
        /// <param name="dockSpace">Dokken som skal sjekkes.</param>
        /// <param name="shipType">Skiptype som skal sjekkes egnet for.</param>
        /// <returns>Sant hvis dokken er egnet for skiptypen, ellers usant.</returns>
        public bool IsLocationSuitable(DockSpace dockSpace, ShipType shipType)
        {
            return dockSpace.DockSpaceNumber == LocationNumber && dockSpace.AllowedShipTypes.Contains(shipType);
        }

        /// <summary>
        /// Sjekker om noen av de spesifiserte dokkene er tilgjengelige for en gitt skiptype.
        /// </summary>
        /// <param name="dockSpaces">Listen over dokker som skal sjekkes.</param>
        /// <param name="shipType">Skiptype som skal sjekkes tilgjengelighet for.</param>
        /// <returns>Sant hvis noen av dokkene er tilgjengelige for skiptypen, ellers usant.</returns>
        public bool IsLocationAvailable(List<DockSpace> dockSpaces, ShipType shipType)
        {
            return dockSpaces.Any(d => d.DockSpaceNumber == LocationNumber && !d.ScheduledShips.Any(s => s.Ship.ShipType == shipType));
        }
    }
}
