﻿using ClassLibrary.HarborFramework.ShipInfo;
using ClassLibrary.HarborFramework.Utilities;


namespace ClassLibrary.HarborFramework.DockingInfo
{
    public class Docking
    {

        public DockSpace dockSpace { get; private set; }
        public TimeSlot timestamp { get; set; }

        public Docking(DockSpace dockSpace, TimeSlot timeSlot)
        {
            this.dockSpace = dockSpace;
            timestamp = timeSlot;
        }

        public void ScheduleDocking(Ship ship)
        {
            if (!dockSpace.AllowedShipTypes.Contains(ship.Type))
            {
                throw new InvalidOperationException("Ship type not allowed in this dock space.");
            }
            dockSpace.ScheduleShip(ship, timestamp);

            Console.WriteLine($"Docking scheduled for {ship.Name} at dock space number {dockSpace.DockSpaceNumber} on {timestamp.startTime}");
        }
    }
}
