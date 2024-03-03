using ClassLibrary.HarborFramework.ShipInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.Interfaces
{
    public interface IInspection
    {
        DateTime InspectionDate { get; set; }
        Ship ShipUpForInspection { get; set; }
        void PerformInspection();
    }
}
