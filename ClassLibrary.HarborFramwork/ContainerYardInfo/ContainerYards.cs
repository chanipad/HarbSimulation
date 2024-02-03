using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramwork.ContainerYardInfo
{
    public class ContainerYards
    {
        public int ContainerYardZone { get; set; }
        public List<Container> ContainersList { get; set; }

        public ContainerYards()
        {
            ContainersList = new List<Container>();
        }

        public void ConfigureContainer(Container container)
        {
            ContainersList.Add(container);
        }
    }
}
