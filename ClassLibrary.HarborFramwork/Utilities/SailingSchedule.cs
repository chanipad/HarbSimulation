using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.Utilities
{
    internal class SailingSchedule
    {
        private List<TimeSlot> availableTimes { get; set; }
        private List<SingleSailing> singleSailings { get; set; }
        private List<RecurringSailing> recurringSailing { get; set; }
    }
}
