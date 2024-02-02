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
                    return "shipSpeed" = 20;
                case ShipType.CRUISE_SHIP:
                    return "shipSpeed" = 30;
                case ShipType.LEISURE_BOAT:
                    return "shipSpeed" = 50;
                default:
                    return null;
            }
        }
    }

    public static int travelTime(ShipType shipType, int distance)
    {
        int speed = ShipSpeeds.GetSpeed(shipType);

        if (speed > 0)
        {
            int time = distance / speed;
            return time;
        }
        else
        {
            return "Speed error!"
        }
    }
}
