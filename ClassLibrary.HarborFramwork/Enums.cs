﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework
{
    public class Enums
    {
        public enum EventType { 
            Arrival,
            Departure
        }
        public enum ContainerYardType
        {
            STANDARD,
            SPECIALIZED
        }

        public enum SailingConfigurationType
        {
            SINGLE,
            RECURRING
        }

        public enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public enum ShipType
        {
            CARGO_SHIP,
            CRUISE_SHIP,
            LEISURE_BOAT
        }

        public enum DockSpaceType
        {
            CARGO,
            CRUISE,
            BERTH
        }

        public enum TrafficConditions
        { Light, 
          Moderate,
          Heavy
        }

        public enum WeatherForecast 
        { 
            Sunny, 
            Rainy, 
            Cloudy,
            Wind,
            Thunderstorm,
            Snow
        }
        public enum Vehicle
        {
            Truck,
            AGV
        }
        public enum ContainerLength
        {
            HalfLength,
            FullLength
        }

    }
}
