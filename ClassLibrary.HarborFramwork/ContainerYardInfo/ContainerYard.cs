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


        private List<Container> Containers { get; set; } = new List<Container>();



        /// <summary>
        /// Initialiserer en ny instans av ContainerYard klassen med et bestemt antall kolonner for full-lengde og halv-lengde containere.
        /// </summary>
        /// <param name="fullLengthColumns">Antall kolonner designet for full-lengde containere.</param>
        /// <param name="halfLengthColumns">Antall kolonner designet for halv-lengde containere.</param>
        public ContainerYard(int fullLengthColumns, int halfLengthColumns)
        {
            Containers = new List<Container>();
            StorageColumns = new List<StorageColumn>();

            for (int i = 0; i < fullLengthColumns; i++)
            {
                StorageColumns.Add(new StorageColumn(ContainerLength.FullLength));
            }

            for (int j = 0; j < halfLengthColumns; j++)
            {
                StorageColumns.Add(new StorageColumn(ContainerLength.HalfLength));
            }
        }
        /// <summary>
        /// Laster av en kjøretøy og lagrer containere i et passende lagringssted ved bruk av en kran.
        /// </summary>
        /// <param name="crane">Kranen som brukes for å laste av containere.</param>
        /// <param name="vehicle">Kjøretøyet som inneholder containerne.</param>
        /// <param name="scheduledTime">Planlagt tidspunkt for avlasting.</param>
        /// <returns>True hvis alle containere ble vellykket lastet av og lagret, ellers false.</returns>
        public bool UnloadVehicleAndStoreContainer(Crane crane, Vehicle vehicle, DateTime scheduledTime)
        {
            if (!crane.IsCraneAvailable(scheduledTime))
            {
                Console.WriteLine($"Crane {crane.CraneId} is not available at the scheduled time.");
                return false;
            }

            while (vehicle.Containers.Any())
            {
                var container = vehicle.UnloadContainer();
                if (container == null)
                {
                    Console.WriteLine("No containers to unload from the vehicle.");
                    break;
                }
                if (AddContainerToYard(container))
                {
                    Containers.Add(container);
                    crane.MarkCraneAsBusy(scheduledTime);
                    Console.WriteLine($"Successfully stored container {container.ContainerId} from vehicle into yard.");
                }
                else
                {
                    Console.WriteLine($"Failed to store container {container.ContainerId} into yard.");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Fjerner en container fra en kolonne basert på containerens ID.
        /// </summary>
        /// <param name="containerId">IDen til containeren som skal fjernes.</param>
        /// <returns>Returnerer true hvis containeren ble vellykket fjernet fra kolonnen, ellers false.</returns>
        public bool LoadContainerOntoVehicle(Crane crane, Vehicle vehicle, int containerId, DateTime scheduledTime)
        {
            if (!crane.IsCraneAvailable(scheduledTime))
            {
                Console.WriteLine($"Crane {crane.CraneId} is not available at the scheduled time.");
                return false;
            }

            Container container = Containers.FirstOrDefault(c => c.ContainerId == containerId);
            if (container == null)
            {
                Console.WriteLine($"Container with ID {containerId} was not found in the yard.");
                return false;
            }

            if (vehicle.Containers.Count >= vehicle.Capacity)
            {
                Console.WriteLine($"Vehicle has reached its maximum capacity of {vehicle.Capacity} containers.");
                return false;
            }

            bool removedFromColumn = RemoveContainerFromColumn(containerId);
            if (!removedFromColumn)
            {
                Console.WriteLine($"Failed to remove container {containerId} from its storage location.");
                return false;
            }

            Containers.Remove(container);

            crane.LoadContainerOnTransport(container, vehicle, scheduledTime);
            Console.WriteLine($"Container {containerId} successfully loaded onto the vehicle using crane {crane.CraneId}.");
            return true;
        }

        /// <summary>
        /// Legger til en container i verftet ved å finne en passende kolonne for lagring.
        /// </summary>
        /// <param name="container">Containeren som skal legges til i verftet.</param>
        /// <returns>Returnerer true hvis containeren ble vellykket plassert i en av kolonnene. Hvis det ikke finnes en egnet kolonne, eller alle kolonner er fulle, returneres false.</returns>
        public bool AddContainerToYard(Container container)
        {
            foreach (var column in StorageColumns)
            {
                if (column.PlaceContainer(container))
                {
                    return true;
                }
            }

            if (container.Length == ContainerLength.HalfLength)
            {
                foreach (var column in StorageColumns)
                {
                    if (column.CanConvertToHalfLength())
                    {
                        column.ConvertToHalfLength();
                        if (column.PlaceContainer(container))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Fjerner en spesifikk container fra kolonnen den er plassert i, basert på containerens ID.
        /// </summary>
        /// <param name="containerId">IDen til containeren som skal fjernes.</param>
        /// <returns>Returnerer true hvis containeren ble vellykket fjernet, ellers false.</returns>
        private bool RemoveContainerFromColumn(int containerId)
        {
            foreach (StorageColumn column in StorageColumns)
            {
                foreach (ContainerSlot slot in column.Slots)
                {
                    if (slot.StoredContainer != null && slot.StoredContainer.ContainerId == containerId)
                    {
                        slot.RemoveContainer();
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Representerer en enkelt lagerplass for en container innenfor en kolonne i containerområdet.
        /// </summary>
        public class ContainerSlot
        {
            /// <summary>
            /// Containeren som er lagret i denne plassen.
            /// </summary>
            public Container StoredContainer { get; private set; }

            /// <summary>
            /// Tidspunktet da containeren ble lagret.
            /// </summary>
            public DateTime TimeStored { get; private set; }

            /// <summary>
            /// Lengden på containeren som kan lagres i denne plassen.
            /// </summary>
            public ContainerLength Length { get; set; }

            /// <summary>
            /// Initialiserer en ny instans av ContainerSlot med en spesifisert containerlengde.
            /// </summary>
            /// <param name="length">Lengden på containeren som kan lagres.</param>
            public ContainerSlot(ContainerLength length)
            {
                Length = length;
            }

            /// <summary>
            /// Tildeler en container til denne plassen hvis lengden passer og plassen ikke allerede er opptatt.
            /// </summary>
            /// <param name="container">Containeren som skal lagres.</param>
            /// <returns>True hvis containeren ble vellykket tildelt, ellers false.</returns>
            public bool AssignContainer(Container container)
            {
                if (StoredContainer != null || Length != container.Length)
                {
                    return false;
                }

                StoredContainer = container;
                TimeStored = DateTime.Now;
                return true;
            }

            /// <summary>
            /// Fjerner containeren fra denne lagerplassen og tilbakestiller lagringstidspunktet.
            /// </summary>
            public void RemoveContainer()
            {
                StoredContainer = null;
                TimeStored = DateTime.MinValue; // Reset the time stored to its default value
            }

            /// <summary>
            /// Sjekker om plassen er gyldig for ny container basert på opptatthet og tidsbegrensning.
            /// </summary>
            /// <returns>True hvis plassen er gyldig, ellers false.</returns>
            public bool IsValidSlot()
            {
                if (StoredContainer == null) return true;

                var storageDuration = (DateTime.Now - TimeStored).TotalDays;
                return storageDuration <= 4;
            }

            /// <summary>
            /// Gir informasjon om lagringsvarigheten for containeren i denne plassen.
            /// </summary>
            /// <returns>En streng som beskriver hvor lenge containeren har vært lagret og hvor mye tid som gjenstår før 4-dagers grensen overskrides.</returns>
            public string StorageDurationInfo()
            {
                if (StoredContainer == null) return "Ingen container er lagret på denne plassen.";

                var daysStored = (DateTime.Now - TimeStored).TotalDays;
                var daysLeft = 4 - daysStored;

                if (daysStored <= 4)
                {
                    return $"Containeren har vært lagret i {daysStored:N2} dager. {daysLeft:N2} dager gjenstår før 4-dagers grensen overskrides.";
                }
                else
                {
                    return $"Containeren har overskredet 4-dagers lagringsgrensen med {Math.Abs(daysLeft):N2} dager.";
                }
            }
        }

        /// <summary>
        /// Representerer en kolonne i containerområdet, bestående av flere lagerplasser for containere.
        /// </summary>
        public class StorageColumn
        {
            /// <summary>
            /// Lagerplassene i denne kolonnen.
            /// </summary>
            public List<ContainerSlot> Slots { get; set; }

            /// <summary>
            /// Høyden på kolonnen, som definerer antall lagernivåer.
            /// </summary>
            public int Height { get; } = 4;

            /// <summary>
            /// Bredden på kolonnen, som definerer antall lagerplasser i hvert nivå.
            /// </summary>
            public int Width { get; } = 6;

            /// <summary>
            /// Indikerer om kolonnen er designet for full-lengde eller halv-lengde containere.
            /// </summary>
            public ContainerLength ColumnType { get; private set; }

            /// <summary>
            /// Initialiserer en ny instans av StorageColumn for en spesifisert type container.
            /// </summary>
            /// <param name="columnType">Typen container kolonnen er designet for.</param>
            public StorageColumn(ContainerLength columnType)
            {
                ColumnType = columnType;
                Slots = new List<ContainerSlot>();
                for (int i = 0; i < Width * Height; i++)
                {
                    Slots.Add(new ContainerSlot(columnType));
                }
            }

            /// <summary>
            /// Forsøker å plassere en container i denne kolonnen.
            /// </summary>
            /// <param name="container">Containeren som skal plasseres.</param>
            /// <returns>True hvis containeren ble vellykket plassert, ellers false.</returns>
            public bool PlaceContainer(Container container)
            {
                if (ColumnType != container.Length && !(container.Length == ContainerLength.HalfLength && CanConvertToHalfLength()))
                {
                    return false;
                }

                foreach (var slot in Slots)
                {
                    if (slot.Length == container.Length && slot.IsValidSlot())
                    {
                        slot.AssignContainer(container);
                        return true;
                    }
                }

                if (container.Length == ContainerLength.HalfLength && CanConvertToHalfLength())
                {
                    ConvertToHalfLength();
                    return PlaceContainer(container);
                }

                return false;
            }

            /// <summary>
            /// Sjekker om kolonnen kan konverteres til å akseptere halv-lengde containere.
            /// </summary>
            /// <returns>True hvis konvertering er mulig, ellers false.</returns>
            public bool CanConvertToHalfLength()
            {
                return ColumnType == ContainerLength.FullLength && Slots.All(slot => slot.StoredContainer == null);
            }

            /// <summary>
            /// Konverterer kolonnen for å akseptere halv-lengde containere.
            /// </summary>
            public void ConvertToHalfLength()
            {
                ColumnType = ContainerLength.HalfLength;
                foreach (var slot in Slots)
                {
                    slot.Length = ContainerLength.HalfLength;
                }
            }
        }


        /// <summary>
        /// Henter en spesifikk container basert på container-ID.
        /// </summary>
        /// <param name="containerId">IDen til containeren som skal hentes.</param>
        /// <returns>Den funnede containeren, eller null hvis ingen container med den IDen ble funnet.</returns>
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
