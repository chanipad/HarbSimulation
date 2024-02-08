using ClassLibrary.HarborFramework.ShipInfo;
using ClassLibrary.HarborFramework.Utilities;


namespace ClassLibrary.HarborFramework.DockingInfo
{
    public class Docking
    {
        private DockSpace dockSpace { get; set; }
        private TimeSlot timestamp { get; set; }
        public object DockSpace { get; internal set; }
        public object Timestamp { get; internal set; }

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

            Console.WriteLine($"Docking scheduled for {ship.Name} at dock space number {dockSpace.DockSpaceNumber} on {timestamp.startTime}");
        }
    }
}
