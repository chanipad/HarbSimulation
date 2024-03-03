using ClassLibrary.HarborFramework.ContainerYardInfo;
using ClassLibrary.HarborFramework.DockingInfo;
using ClassLibrary.HarborFramework.ShipInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.HarborFramework.ContainerYardInfo.Container;

namespace ClassLibrary.HarborFramework.Interfaces
{
    public interface IHarb
    {
        void ConfigureHarbor();
        void ConfigureDockSpace();
        void ConfigureContainerYard();
        void SetSailingSchedule();
        void ConfigureShipType();
        ShipHistory GetShipHistory(int shipId);
        public List<Location> GetContainerHistory();
        void EvaluateTrafficWeatherSeaConditions();
        void HandleSecurityRegulations();

    }


}
