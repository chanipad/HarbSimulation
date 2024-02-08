using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.HarborFramwork.DockingInfo;

namespace ClassLibrary.HarborFramwork.ContainerYardInfo
{

    /// <summary>
    /// Represent container information.
    /// </summary>
    public class Container
    {
        private int containerId { get; set; }
        private List<Location> location { get; set; } = new List<Location>();


        // constructor
        public Container(int containId)
        { 
            containerId = containId;
        }





        /// <summary>
        /// Represent container yard zone 
        /// </summary>
        public class ContainerYards
        {
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


            /// <summary>
            /// Add new location and time to cantainer history
            /// </summary>
            /// <param name="newLocation"></param>
            public void AddNewLocation(Location newLocation)
            {
                Location loc = new()
                {
                    location = newLocation,
                    Timestamp = DateTime.Now
                };
                location.Add(loc);
            }


            /// <summary>
            /// Update location the last location history to container with new location
            /// </summary>
            /// <param name="newLocation"></param>
            public void UpdateLocation(Location newLocation)
            {
                if (location.Count > 0)
                {
                    Location loc = new Location();
                    loc.location = newLocation;
                    loc.Timestamp = DateTime.Now;
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
