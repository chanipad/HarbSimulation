using ClassLibrary.HarborFramework.MarineData;
using System;
using static ClassLibrary.HarborFramework.Enums;
using ClassLibrary.HarborFramework;
using ClassLibrary.HarborFramework.ContainerYardInfo;
using static ClassLibrary.HarborFramework.ContainerYardInfo.Container;

namespace HarbSimulation
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            TideInformation tideInfo = new TideInformation();
            // Set some tide levels
            tideInfo.SetTideLevel(new DateTime(2024, 2, 4), 5.2);
            tideInfo.SetTideLevel(new DateTime(2024, 2, 5), 3.8);
            // Get tide level for specific dates
            Console.WriteLine("Tide level on 2024-02-04: " + tideInfo.GetTideLevel(new DateTime(2024, 2, 4))); // Output: 5.2
            Console.WriteLine("Tide level on 2024-02-06: " + tideInfo.GetTideLevel(new DateTime(2024, 2, 6))); // Output: -1 (Tide information not available)

           
            
            
        }
    }
}
