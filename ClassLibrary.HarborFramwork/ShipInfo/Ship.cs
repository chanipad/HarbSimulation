using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.ShipInfo
{
    public class Ship
    {
        private int Id { get; set; }
        private ShipType ShipType { get; set; }
        private ShipHistory History { get; set; }
        private ShipCertificate Certificate { get; set; }

        public Ship(int id, ShipType shipType)
        {
            Id = id;
            ShipType = shipType;
            History = new ShipHistory();
            Certificate = new ShipCertificate();
        }

        public ShipHistory GetHistory()
        {
            return History;
        }
    }
}
