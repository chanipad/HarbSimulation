using ClassLibrary.HarborFramwork.Utilities;

namespace ClassLibrary.HarborFramwork.DockingInfo
{
    internal class Location
    {
        private TimeSlot timestamp { get; set; }
        private String DockLocation { get; set; }

        public Location(int dockLocation, TimeSlot timeSlot)
        {
            DockLocation = dockLocation;
            TimeSlot = timeSlot;
        }
    }
}
