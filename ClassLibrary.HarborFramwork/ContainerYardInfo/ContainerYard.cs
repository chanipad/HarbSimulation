using ClassLibrary.HarborFramework.DockingInfo;
using ClassLibrary.HarborFramwork.Exceptions;
using static ClassLibrary.HarborFramework.Enums;

namespace ClassLibrary.HarborFramework.ContainerYardInfo
{
    /// <summary>
    /// Representerer et containerområde med funksjonalitet for å administrere containere og planlegge lasteoperasjoner.
    /// </summary>
    public class ContainerYard
    {
        /// <summary>
        /// Får lokasjonen til containerområdet.
        /// </summary>
        public string Location { get; private set; }

        private List<StorageColumn> StorageColumns { get; set; } = new List<StorageColumn>();

        /// <summary>
        /// Setter start og slutt tid for en lasteopperasjon
        /// </summary>
        public class LasteOperasjon
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        private List<Container> Containers { get; set; } = new List<Container>();
        private List<LasteOperasjon> LasteOperasjoner { get; set; } = new List<LasteOperasjon>();

        /// <summary>
        /// Initialiserer en ny instans av <see cref="ContainerYard"/> klassen med en spesifikk lokasjon.
        /// </summary>
        /// <param name="location">Lokasjonen til containerområdet.</param>

        /// <summary>
        /// Legger til en container i containerområdet.
        /// </summary>
        /// <param name="container">Containeren som skal legges til.</param>
        /// 
        public ContainerYard(string location)
        {
            Location = location;
            Containers = new List<Container>();
            StorageColumns = new List<StorageColumn>();
        }

        public class ContainerSlot
        {
            public Container StoredContainer { get; private set; }
            public DateTime TimeStored { get; private set; }
            // Property to indicate the slot's designated container length type
            public ContainerLength Length { get; set; }

            // Constructor that initializes the slot with a specific container length type
            public ContainerSlot(ContainerLength length)
            {
                Length = length;
            }

            // Attempts to assign a container to this slot, checking length compatibility and whether the slot is already occupied
            public bool AssignContainer(Container container)
            {
                // Check if the slot is already occupied or if the container's length type doesn't match the slot's length type
                if (StoredContainer != null || Length != container.Length)
                {
                    return false; // Slot is occupied or container type mismatch
                }

                StoredContainer = container;
                TimeStored = DateTime.Now; // Track the time the container was stored
                return true; // Container successfully assigned
            }

            // Checks if the slot is valid for a new container placement based on occupancy and the time constraint
            public bool IsValidSlot()
            {
                // Slot is valid if it's empty
                if (StoredContainer == null) return true;

                // If a container is stored, check if it has exceeded the 4-day limit
                var storageDuration = (DateTime.Now - TimeStored).TotalDays;
                return storageDuration <= 4; // Slot is valid if the stored container hasn't exceeded the 4-day limit
            }

            // Provides information on the storage duration of the container in the slot
            public string StorageDurationInfo()
            {
                if (StoredContainer == null) return "No container is stored in this slot.";

                var daysStored = (DateTime.Now - TimeStored).TotalDays;
                var daysLeft = 4 - daysStored;

                if (daysStored <= 4)
                {
                    return $"Container has been stored for {daysStored:N2} days. {daysLeft:N2} days left before exceeding the 4-day limit.";
                }
                else
                {
                    return $"Container has exceeded the 4-day storage limit by {Math.Abs(daysLeft):N2} days.";
                }
            }
        }
        public class StorageColumn
        {
            public List<ContainerSlot> Slots { get; set; }
            public int Height { get; } = 4;
            public int Width { get; } = 6;
            // Indicates whether the column is designated for full-length or half-length containers
            public ContainerLength ColumnType { get; private set; }

            public StorageColumn(ContainerLength columnType)
            {
                ColumnType = columnType;
                Slots = new List<ContainerSlot>();
                // Initialize slots with the specified column type
                for (int i = 0; i < Width * Height; i++)
                {
                    Slots.Add(new ContainerSlot(columnType)); // Assuming ContainerSlot also uses ContainerLength
                }
            }

            // Attempt to place a container in this column
            public bool PlaceContainer(Container container)
            {
                // Check if the column type matches the container's type
                if (ColumnType != container.Length && !(container.Length == ContainerLength.HalfLength && CanConvertToHalfLength()))
                {
                    return false; // Container type does not match column type and conversion is not possible or necessary
                }

                foreach (var slot in Slots)
                {
                    // Check if the slot matches the container type and is valid for placement
                    if (slot.Length == container.Length && slot.IsValidSlot())
                    {
                        slot.AssignContainer(container);
                        return true; // Container successfully placed
                    }
                }

                // If no slot is available and the container is half-length, try converting the column to half-length
                if (container.Length == ContainerLength.HalfLength && CanConvertToHalfLength())
                {
                    ConvertToHalfLength();
                    return PlaceContainer(container); // Retry placing the container after conversion
                }

                return false; // No suitable slot found for the container
            }

            // Check if the column can be converted to half-length (only applicable for full-length columns)
            private bool CanConvertToHalfLength()
            {
                return ColumnType == ContainerLength.FullLength && Slots.All(slot => slot.StoredContainer == null);
            }

            // Convert the column to accommodate half-length containers
            private void ConvertToHalfLength()
            {
                ColumnType = ContainerLength.HalfLength;
                foreach (var slot in Slots)
                {
                    slot.Length = ContainerLength.HalfLength; // Assuming ContainerSlot also has a Length property of type ContainerLength
                }
            }
        }

        /// <summary>
        /// Henter en spesifikk container basert på container-ID.
        /// </summary>
        /// <param name="containerId">IDen til containeren som skal hentes.</param>
        /// <returns>Den funnete containeren, eller null hvis ingen container med den IDen ble funnet.</returns>
        public Container GetContainer(int containerId)
        {
            return Containers.Find(c => c.ContainerId == containerId);
        }

        /// <summary>
        /// Henter en liste over alle containere i containerområdet.
        /// </summary>
        /// <returns>En liste over alle containere.</returns>
        public List<Container> GetAllContainers()
        {
            return new List<Container>(Containers);
        }
    }
}
