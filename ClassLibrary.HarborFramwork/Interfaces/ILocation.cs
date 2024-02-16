using ClassLibrary.HarborFramework.DockingInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Interfaces
{
    public interface ILocation
    {
        public interface ILocation
        {
            string DockLocation { get; }
            DateTime Timestamp { get; }
            DockSpace DockSpace { get; }
            string NewLocation { get; }
        }
    }
}
