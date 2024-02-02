using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.ShipInfo
{
    public enum ShipType
    {
        CARGO_SHIP,
        CRUISE_SHIP,
        LEISURE_BOAT
    }

    public class ShipSpeeds
    {
        public static int GetSpeed(ShipType shipType)
        {
            switch (shipType)
            {
                case ShipType.CARGO_SHIP:
                    return 20;
                case ShipType.CRUISE_SHIP:
                    return 30;
                case ShipType.LEISURE_BOAT:
                    return 50;
                default:
                    throw new ArgumentException("Invalid ship type");
            }
        }

        public static int TravelTime(ShipType shipType, int distance)
        {
            int speed = GetSpeed(shipType);

            if (speed > 0)
            {
                int time = distance / speed;
                return time;
            }
            else
            {
                throw new InvalidOperationException("Speed error!");
            }
        }
    }
}
