using ClassLibrary.HarborFramework.Utilities;
using ClassLibrary.HarborFramwork.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Interfaces
{
    public interface ISailing
    {
        List<TimeSlot> AvailableTimes { get; set; }
        List<SingleSailing> SingleSailings { get; set; }
        List<RecurringSailing> RecurringSailings { get; set; }
        void ConfigureSailingSchedule();
        void BookAvailableTime(TimeSlot timeSlot);
    }
}
