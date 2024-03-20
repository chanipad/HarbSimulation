﻿using ClassLibrary.HarborFramework.Exceptions;
using static ClassLibrary.HarborFramework.Enums;
using System.Linq;
using ClassLibrary.HarborFramework.ContainerYardInfo;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    /// <summary>
    /// Representerer en dokkplass hvor skip kan planlegges for dokking.
    /// </summary>
    public class DockSpace
    {
        /// <summary>
        /// Nummeret til dokkplassen.
        /// </summary>
        public int DockSpaceNumber { get; set; }

        /// <summary>
        /// Typen av dokkplass.
        /// </summary>
        public DockSpaceType Type { get; set; }

        /// <summary>
        /// Listen over skipstyper som er tillatt i denne dokkplassen.
        /// </summary>
        public List<ShipType> AllowedShipTypes { get; set; } = new List<ShipType>();

        /// <summary>
        /// Listen over skip som er planlagt for dokking.
        /// </summary>
        public List<ScheduledShip> ScheduledShips { get; set; } = new List<ScheduledShip>();

        /// <summary>
        /// Listen over kraner tilgjengelig for lasteoperasjoner ved denne dokkplassen.
        /// </summary>
        public List<Crane> Cranes { get; set; } = new List<Crane>();

        /// <summary>
        /// Initialiserer en ny instans av DockSpace-klassen.
        /// </summary>
        /// <param name="dockSpaceNumber">Nummeret til dokkplassen.</param>
        public DockSpace(int dockSpaceNumber)
        {
            DockSpaceNumber = dockSpaceNumber;
            InitializeCranes();
        }

        /// <summary>
        /// Initialiserer kranene for dokkplassen.
        /// </summary>
        private void InitializeCranes()
        {
            for (int i = 0; i < 7; i++)
            {
                Cranes.Add(new Crane(i + 1));
            }
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
        /// Planlegger et skip for dokking ved dokkplassen, gitt at skipstypen er tillatt.
        /// </summary>
        /// <param name="ship">Skipet som skal planlegges for dokking.</param>
        /// <param name="dockingDateTime">Tidspunktet for når dokkingen skal finne sted.</param>
        /// <returns>True hvis skipet ble planlagt for dokking, ellers false.</returns>
        public bool ScheduleShip(Ship ship, DateTime dockingDateTime)
        {
            if (AllowedShipTypes.Contains(ship.ShipType))
            {
                ScheduledShips.Add(new ScheduledShip { Ship = ship, DockingDateTime = dockingDateTime });
                return true;
            }
            return false;
        }

        /// <summary>
        /// Utfører en lasteoperasjon ved å bruke en ledig kran til å laste en container på et transportmiddel.
        /// </summary>
        /// <param name="container">Containeren som skal lastes.</param>
        /// <param name="vehicle">Transportmiddelet containeren skal lastes på.</param>
        /// <param name="scheduledTime">Tidspunktet for når lasteoperasjonen skal finne sted.</param>
        /// <returns>True hvis operasjonen var vellykket, ellers false.</returns>
        public bool PerformLoadingOperation(Container container, Vehicle vehicle, DateTime scheduledTime)
        {
            var availableCrane = Cranes.FirstOrDefault(crane => crane.IsCraneAvailable(scheduledTime));
            if (availableCrane != null)
            {
                return availableCrane.LoadContainerOnTransport(container, vehicle, scheduledTime);
            }
            else
            {
                throw new DockingExceptions.NoAvailableCranesException("Ingen tilgjengelige kraner for det planlagte tidspunktet.");
            }
        }
    }

    /// <summary>
    /// Representerer et skip som er planlagt for dokking, med tilhørende tidspunkt for dokkingen.
    /// </summary>
    public class ScheduledShip
    {
        /// <summary>
        /// Skipet som er planlagt for dokking.
        /// </summary>
        public Ship Ship { get; set; }

        /// <summary>
        /// Tidspunktet for når skipet er planlagt for dokking.
        /// </summary>
        public DateTime DockingDateTime { get; set; }
    }
}
