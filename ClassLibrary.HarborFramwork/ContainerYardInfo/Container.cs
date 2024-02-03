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
        /// Return location from collection
        /// </summary>
        /// <param name="containerId">The ID of container you whan to get the location history</param>
        /// <returns></returns>
        public int getContainerHistory(int containerId)
        {
            return location.Count;
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
            private List<Location> location { get; set; }

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
