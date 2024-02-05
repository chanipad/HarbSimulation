using System;
using System.Collections.Generic;
using ClassLibrary.HarborFramwork.ShipInfo;
using ClassLibrary.HarborFramwork.Utilities;


namespace ClassLibrary.HarborFramwork.DockingInfo
{
    public class DockSpace
    {
        public int DockSpaceNumber { get; set; }
        public DockSpaceType Type { get; set; }
        public List<ShipType> AllowedShipTypes { get; set; }
        public List<ScheduledShip> ScheduledShips { get; set; } = new List<ScheduledShip>();

        public DockSpace(int dockSpaceNumber)
        {
            DockSpaceNumber = dockSpaceNumber;
        }

        public void ConfigureDockSpace(DockSpaceType type, List<ShipType> allowedShipTypes)
        {
            Type = type;
            AllowedShipTypes = allowedShipTypes;
        }

        public bool ScheduleShip(Ship ship, TimeSlot timeSlot)
        {
            if (!AllowedShipTypes.Contains(ship.Type))
            {
                return false;
            }
            ScheduledShips.Add(new ScheduledShip { Ship = ship, TimeSlot = timeSlot });
            return true;
        }
    }

    internal class ScheduledShip
    {
        public Ship Ship { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}
