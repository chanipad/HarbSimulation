using ClassLibrary.HarborFramwork.Utilities;

namespace ClassLibrary.HarborFramwork.DockingInfo
{
    public class Location
    {
        internal Location location;

        //private TimeSlot Timestamp { get; set; }
        private String DockLocation { get; set; }
        public Location NewLocation { get; set; }
        public DateTime Timestamp { get; set; }

        /*public Location(int dockLocation, TimeSlot timeSlot)
        {
            DockLocation = dockLocation;
            TimeSlot = timeSlot;
        }
        */
        public Location(int dockLocation, DateTime timeSlot)
        {
            DockLocation = dockLocation;
            Timestamp = timeSlot;
        }

        public Location(string newLocation)
        {
            NewLocation = newLocation;

        }

        public Location()
        {
        }

        public static implicit operator Location(string v)
        {
            throw new NotImplementedException();
        }
    }
}
