using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.HarborFramework.ContainerYardInfo
{
    public class ContainerSlot
    {
        public Container StoredContainer { get; private set; }
        public bool IsFullLength { get; set; } = true;

        public ContainerSlot(bool isFullLength)
        {
            IsFullLength = isFullLength;
        }

        public bool AssignContainer(Container container)
        {
            if (StoredContainer == null)
            {
                StoredContainer = container;
                return true;
            }
            return false;
        }
    }
}
