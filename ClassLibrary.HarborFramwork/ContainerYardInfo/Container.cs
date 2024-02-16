using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.HarborFramework.DockingInfo;
using ClassLibrary.HarborFramework.Interfaces;
using ClassLibrary.HarborFramework.ShipInfo;

namespace ClassLibrary.HarborFramework.ContainerYardInfo
{

    /// <summary>
    /// Represent container information.
    /// </summary>
    public class Container : IHarb
    {
        
        private int containerId { get; set; }
        private List<Location> location { get; set; } = new List<Location>();
        public DateTime Timestamp { get; private set; }


        // constructor
        public Container(int containId)
        { 
            containerId = containId;
        }

        public Container()
        {
            this.location = new List<Location>();
        }



        

        /*

        public void Print()
        {
            Console.WriteLine($"Container ID: {containerId}");
            Console.WriteLine("Container Locations:");
            if (location != null)
            {
                foreach (var location in location)
                {
                    Console.WriteLine($" - Location Dock: {location.dockLocation}");
                    Console.WriteLine($" - Timestamp: {location.Timestamp}");

                    //Console.WriteLine($"   Associated DockSpace Number: {location.DockSpace.DockSpaceNumber}");


                }
            }
            else
            { Console.WriteLine("No locations found.");
            }
        }
        */


        public DateTime GetTimestamp()
        {
            return DateTime.UtcNow;
        }

        public void AddNewLocation(Location newLocation, DateTime timestamp)
        {
            Location loc = new()
            {
                location = newLocation,
                timestamp = DateTime.Now
            };
            location.Add(loc);
        }

        public void ConfigureHarbor()
        {
            throw new NotImplementedException();
        }

        public void ConfigureDockSpace()
        {
            throw new NotImplementedException();
        }

        public void ConfigureContainerYard()
        {
            throw new NotImplementedException();
        }

        public void SetSailingSchedule()
        {
            throw new NotImplementedException();
        }

        public void ConfigureShipType()
        {
            throw new NotImplementedException();
        }

        public ShipHistory GetShipHistory(int shipId)
        {
            throw new NotImplementedException();
        }

        public ContainerHistory GetContainerHistory(int containerId)
        {
            throw new NotImplementedException();
        }

        public void EvaluateTrafficWeatherSeaConditions()
        {
            throw new NotImplementedException();
        }

        public void HandleSecurityRegulations()
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// Represent container yard zone 
        /// </summary>
        public class ContainerYards
        {
            internal object Location;

            private string ContainerYardZone { get; set; }
            private List<Container> ContainersList { get; set; } = new List<Container>();


            // Constructor
            public ContainerYards()
            {
                ContainersList = new List<Container>();
            }


            public void ConfigureContainer(Container container)
            {
                ContainersList.Add(container);
            }
        }





        /// <summary>
        /// Represent container history location.
        /// </summary>
        public class ContainerHistory
        {
            public List<Location> location { get; set; }
            public DateTime Timestamp { get; private set; }


            /// <summary>
            /// Add new location and time to cantainer history
            /// </summary>
            /// <param name="newLocation"></param>
            public void AddNewLocation(Location newLocation)
            {
                location.Add(newLocation);
            }


            /// <summary>
            /// Update location the last location history to container with new location
            /// </summary>
            /// <param name="newLocation"></param>
            public void UpdateLocation(Location newLocation)
            {
                if (location.Count > 0)
                {
                    Location loc = new Location
                    {
                        location = newLocation,
                        //Timestamp = DateTime.Now
                    };
                    location[location.Count - 1] = loc;
                }
                else
                {
                    Console.WriteLine("History is empty. Please create new location");
                }
            }

            /// <summary>
            /// Return location from collection
            /// </summary>
            /// <param name="containerId">The ID of container you whan to get the location history</param>
            /// <returns></returns>
            public int getContainerHistory(int containerId)
            {
                return location.Count;
            }
        }

    }
}
