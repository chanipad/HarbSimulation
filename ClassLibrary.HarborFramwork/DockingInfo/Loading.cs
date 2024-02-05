using ClassLibrary.HarborFramwork.ContainerYardInfo;
using ClassLibrary.HarborFramwork.Utilities;

namespace ClassLibrary.HarborFramwork.DockingInfo
{
    internal class Loading
    {
        private ContainerYards containerYards { get; set; }
        private TimeSlot timestamp { get; set; }

        public Loading(ContainerYards containerYards, TimeSlot timeSlot)
        {
            ContainerYards = containerYards;
            TimeSlot = timeSlot;
        }

        public void ScheduleLoading()
        {
            Console.WriteLine($"Loading scheduled at {ContainerYards.Location} on {TimeSlot.StartTime}");
        }
    }
}
