using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.HarborFramework.ContainerYardInfo.ContainerYard;

namespace ClassLibrary.HarborFramework.ContainerYardInfo
{
    public class StorageColumn
    {
        public List<ContainerSlot> Slots { get; set; }
        public int Height { get; } = 4; 
        public int Width { get; } = 6; 
        public int Length { get; set; }

        public StorageColumn(int length)
        {
            Length = length;
            Slots = Enumerable.Range(0, Width * Height * Length).Select(_ => new ContainerSlot(true)).ToList();
        }

        /// <summary>
        // Finner en ledig slot som matcher containerens størrelse
        /// </summary>
        public bool PlaceContainer(Container container, bool isFullLength)
        {
            foreach (var column in StorageColumns)
            {
                var slot = column.Slots.FirstOrDefault(s => s.IsFullLength == isFullLength && s.StoredContainer == null);
                if (slot != null)
                {
                    slot.AssignContainer(container);
                    return true;
                }
            }
            return false;
        }
        public void ConfigureSlotSize(int columnIndex, int slotIndex, bool isFullLength)
        {
            var column = StorageColumns[columnIndex];
            var slot = column.Slots[slotIndex];
            slot.IsFullLength = isFullLength;
        }
    }
}
