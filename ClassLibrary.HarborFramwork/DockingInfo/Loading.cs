using System;
using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramework.Utilities;
using static ClassLibrary.HarborFramework.ContainerYardInfo.Container;

namespace ClassLibrary.HarborFramework.DockingInfo
{
    public class Loading
    {
        public object LoadingPlace { get; private set; }
        public ContainerYards ContainerYards { get; private set; }
        public TimeSlot Timestamp { get; private set; }

        public Loading(ContainerYards containerYards, TimeSlot timeSlot)
        {
            ContainerYards = containerYards;
            Timestamp = timeSlot;
        }

        public void ScheduleLoading()
        {
            Console.WriteLine($"Loading scheduled at {ContainerYards.Location} on {Timestamp.startTime}");
        }
    }
}
