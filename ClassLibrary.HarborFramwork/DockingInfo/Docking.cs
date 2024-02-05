using ClassLibrary.HarborFramwork.ShipInfo;
using ClassLibrary.HarborFramwork.Utilities;


namespace ClassLibrary.HarborFramwork.DockingInfo
{
    public class Docking
    {
        private DockSpace dockSpace { get; set; }
        private TimeSlot timestamp { get; set; }

        public Docking(DockSpace dockSpace, TimeSlot timestamp)
        {
            this.dockSpace = dockSpace;
            this.timestamp = timestamp;
        }

        public void ScheduleDocking(Ship ship)
        {
            if (!dockSpace.AllowedShipTypes.Contains(ship.Type))
            {
                throw new InvalidOperationException("Ship type not allowed in this dock space.");
            }
            dockSpace.ScheduleShip(ship, timestamp);

            Console.WriteLine($"Docking scheduled for {ship.Name} at dock space number {dockSpace.DockSpaceNumber} on {timestamp.StartTime}");
        }
    }
}
