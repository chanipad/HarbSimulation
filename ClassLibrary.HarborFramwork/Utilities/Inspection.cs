using ClassLibrary.HarborFramework.ShipInfo;
using System;
using System.Collections.Generic;

namespace ClassLibrary.HarborFramework.Utilities
{
    /// <summary>
    /// Administrerer inspeksjoner av skip, inkludert planlegging og gjennomføring av tilfeldige inspeksjoner.
    /// </summary>
    public class Inspection
    {
        /// <summary>
        /// Datoen for den planlagte inspeksjonen.
        /// </summary>
        private DateTime InspectionDate { get; set; }

        /// <summary>
        /// Skipet som er valgt for inspeksjon.
        /// </summary>
        private Ship? ShipUpForInspection { get; set; }

        /// <summary>
        /// Planlegger en tilfeldig inspeksjon for ett av skipene i listen.
        /// </summary>
        /// <param name="ships">Listen over skip hvorav ett vil bli tilfeldig valgt for inspeksjon.</param>
        /// <exception cref="ArgumentException">Kastes når listen over skip er null eller tom.</exception>
        public void ScheduleRandomInspection(List<Ship> ships)
        {
            if (ships == null || ships.Count == 0)
            {
                throw new ArgumentException("Listen over skip kan ikke være null eller tom.", nameof(ships));
            }

            Random rnd = new Random();
            int index = rnd.Next(ships.Count);
            this.ShipUpForInspection = ships[index];
            this.InspectionDate = DateTime.Now;
        }

        /// <summary>
        /// Utfører en inspeksjon på skipet som er planlagt for inspeksjon.
        /// </summary>
        public void PerformInspection()
        {
            if (ShipUpForInspection == null)
            {
                throw new InvalidOperationException("Ingen skip er planlagt for inspeksjon.");
            }

            // Simulerer inspeksjonsprosessen
            Console.WriteLine($"Inspekterer {ShipUpForInspection.Id} den {InspectionDate.ToShortDateString()}.");

            // Merker skipet som inspisert
            ShipUpForInspection.Inspected = true;

            // Oppdaterer dato for inspeksjonen for å reflektere når inspeksjonen faktisk ble utført
            InspectionDate = DateTime.Now;
        }
    }
}
