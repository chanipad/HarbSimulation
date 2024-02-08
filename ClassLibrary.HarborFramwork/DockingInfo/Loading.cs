using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramework.Utilities;
using static ClassLibrary.HarborFramework.ContainerYardInfo.Container;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    public class Loading
    {
        public object LoadingPlace { get; internal set; }
        private ContainerYards containerYards { get; set; }
        private TimeSlot timestamp { get; set; }
        public ContainerYards ContainerYards { get; }
        internal TimeSlot TimeSlot { get; }
        public object Timestamp { get; internal set; }

        public Loading(ContainerYards containerYards, TimeSlot timeSlot)
        {
            ContainerYards = containerYards;
            TimeSlot = timeSlot;
        }

        public void ScheduleLoading()
        {
            Console.WriteLine($"Loading scheduled at {ContainerYards.Location} on {TimeSlot.startTime}");
        }
    }
}
