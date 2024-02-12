using ClassLibrary.HarborFramework.Utilities;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    public class Location
    {
        public Location location;
        private Location parentLocation;
        internal object dockLocation;
        internal DateTime timestamp;

        public string DockLocation { get; private set; }
        public DateTime Timestamp { get; private set; }
        public DockSpace DockSpace { get; private set; }
        public string NewLocation { get; private set; }

        //private TimeSlot Timestamp { get; set; }
        /*private String DockLocation { get; set; }
        public Location NewLocation { get; set; }
        public DateTime Timestamp { get; set; }

        public Location(int dockLocation, TimeSlot timeSlot)
        {
            DockLocation = dockLocation;
            TimeSlot = timeSlot;
        }
        */
        public Location(string dockLocation, DateTime timeSlot, DockSpace dockSpace)
        {
            DockLocation = dockLocation;
            Timestamp = timeSlot;
            DockSpace = dockSpace;
        }

        public Location(string newLocation, DateTime timestamp)
        {
            NewLocation = newLocation;

        }

        public Location()
        {
        }


        public Location(string dockLocation, DateTime timestamp, Location parentLocation)
        : this(dockLocation, timestamp)
        {
            this.parentLocation = parentLocation;
        }

        public Location(int v, DateTime now)
        {
        }

        public static implicit operator Location(string newLocation)
        {
            throw new NotImplementedException();
        }


        /*public static implicit operator Location(string v)
        {
            return new Location(v);
        }*/

    }
}
