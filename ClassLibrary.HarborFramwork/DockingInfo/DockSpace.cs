using System;
using System.Collections.Generic;
using ClassLibrary.HarborFramework.ShipInfo;
using ClassLibrary.HarborFramework.Utilities;
using static ClassLibrary.HarborFramework.Enums;


namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en dokkplass hvor skip kan planlegges for dokking.
    /// </summary>
    public class DockSpace
    {
        /// <summary>
        /// Får eller setter nummeret til dokkplassen.
        /// </summary>
        public int DockSpaceNumber { get; set; }

        /// <summary>
        /// Får eller setter typen av dokkplass.
        /// </summary>
        public DockSpaceType Type { get; set; }

        /// <summary>
        /// Får eller setter listen over skipstyper som er tillatt i denne dokkplassen.
        /// </summary>
        public List<ShipType> AllowedShipTypes { get; set; }

        /// <summary>
        /// Får eller setter listen over skip som er planlagt for dokking.
        /// </summary>
        public List<ScheduledShip> ScheduledShips { get; set; } = new List<ScheduledShip>();

        /// <summary>
        /// Initialiserer en ny instans av DockSpace-klassen med et spesifikt dokkplassnummer.
        /// </summary>
        /// <param name="dockSpaceNumber">Nummeret til dokkplassen.</param>
        public DockSpace(int dockSpaceNumber)
        {
            DockSpaceNumber = dockSpaceNumber;
        }

        /// <summary>
        /// Konfigurerer dokkplassen med en spesifikk type og tillatte skipstyper.
        /// </summary>
        /// <param name="type">Typen av dokkplass.</param>
        /// <param name="allowedShipTypes">Listen over skipstyper som er tillatt.</param>
        public void ConfigureDockSpace(DockSpaceType type, List<ShipType> allowedShipTypes)
        {
            Type = type;
            AllowedShipTypes = allowedShipTypes;
        }

        /// <summary>
        /// Planlegger et skip for dokking hvis skipstypen er tillatt.
        /// </summary>
        /// <param name="ship">Skipet som skal planlegges for dokking.</param>
        /// <param name="dockingDateTime">Tidspunktet for dokking.</param>
        /// <returns>True hvis skipet ble planlagt, ellers false.</returns>
        public bool ScheduleShip(Ship ship, DateTime dockingDateTime)
        {
            if (!AllowedShipTypes.Contains(ship.ShipType))
            {
                return false;
            }
            ScheduledShips.Add(new ScheduledShip { Ship = ship, DockingDateTime = dockingDateTime });
            return true;
        }
    }


    /// <summary>
    /// Representerer et planlagt skip for dokking med tilhørende tidspunkt.
    /// </summary>
    public class ScheduledShip
    {
        /// <summary>
        /// Får eller setter skipet som er planlagt for dokking.
        /// </summary>
        public Ship Ship { get; set; }

        /// <summary>
        /// Får eller setter tidspunktet for når skipet er planlagt for dokking.
        /// </summary>
        public DateTime DockingDateTime { get; set; }
    }

}
