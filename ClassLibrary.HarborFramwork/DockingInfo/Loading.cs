using ClassLibrary.HarborFramwork.ContainerYardInfo;
using ClassLibrary.HarborFramwork.Utilities;
using static ClassLibrary.HarborFramwork.ContainerYardInfo.Container;

namespace ClassLibrary.HarborFramwork.DockingInfo
{
    public class Loading
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
