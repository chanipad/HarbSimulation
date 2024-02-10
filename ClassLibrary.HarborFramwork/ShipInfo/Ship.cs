﻿using static ClassLibrary.HarborFramwork.Enums;

namespace ClassLibrary.HarborFramework.ShipInfo
{
    /// <summary>
    /// Represents a ship in the harbor.
    /// </summary>
    public class Ship
    {
        public int Id { get; private set; }
        private ShipType ShipType { get; set; }
        private ShipHistory History { get; set; }
        private ShipCertificate Certificate { get; set; }
        public ShipType Type { get; internal set; }

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
