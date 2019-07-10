using System;

namespace VersionUpdater 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter version number (e:g: '1.2.3.4') ");
            var isVersionStringValid = false;
            while (!isVersionStringValid)
            {
                
            }
            var readVersionNumber = Console.ReadLine();
            var versionParser = new VersionStringParser(readVersionNumber);
            
            var versionString = "";
            while (VersionStringParser.TryParse(Console.ReadLine(), out versionString))
            {
                Console.WriteLine("Please enter a version Number in valid format");
            }

            Console.WriteLine("Enter Index to increment, Major:0, Minor:1, Build:2 and Revision:3 ");
            var result = -1;
            while (!Int32.TryParse(Console.ReadLine(), out result) && result >= 0 && result <= 3)
            {
                Console.WriteLine(" Please make sure value is in between 0 and 4 ");
            }

            Console.WriteLine(result);
            Console.WriteLine(IncrementVersion(readVersionNumber));
        }

        static string IncrementVersion(string inputVersion)
        {
            inputVersion.Split(".");

        }

    }
}

