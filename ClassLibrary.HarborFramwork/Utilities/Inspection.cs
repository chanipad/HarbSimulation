using ClassLibrary.HarborFramework.ShipInfo;
using System;
using System.Collections.Generic;

namespace ClassLibrary.HarborFramework.Utilities
{
    public class Inspection
    {

        private DateTime InspectionDate { get; set; }

        private Ship? ShipUpForInspection { get; set; }

        /// <summary>
        /// Schedules a random inspection for one of the ships provided in the list.
        /// </summary>
        /// <param name="ships">The list of ships from which one will be randomly selected for inspection.</param>
        /// <exception cref="ArgumentException">Thrown when the list of ships is null or empty.</exception>
        public void ScheduleRandomInspection(List<Ship> ships)

        {
            if (ships == null || ships.Count == 0)
            {
                throw new ArgumentException("Ship list cannot be null or empty.", nameof(ships));
            }

            Random rnd = new Random();
            int index = rnd.Next(ships.Count);
            this.ShipUpForInspection = ships[index];
            this.InspectionDate = DateTime.Now;
        }

        /// <summary>
        /// Performs an inspection on the ship currently up for inspection.
        /// </summary>
        public void PerformInspection()
        {
            if (ShipUpForInspection == null)
            {
                throw new InvalidOperationException("No ship is scheduled for inspection.");
            }

            // Simulate the inspection process
            Console.WriteLine($"Inspecting {ShipUpForInspection.Id} on {InspectionDate.ToShortDateString()}.");

            // Mark the ship as inspected
            ShipUpForInspection.Inspected = true;

            // Update the inspection date to reflect when the inspection was actually performed
            InspectionDate = DateTime.Now;
        }
    }
}
