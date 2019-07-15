using System;
using System.Linq;

namespace VersionUpdater 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter version number (e:g: '1.2.3.4') ");
            var versionString = Console.ReadLine();
            Console.WriteLine("Enter Index to increment, Major:0, Minor:1, Build:2 and Revision:3 ");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || !(result >= 0 && result <= 3))
            {
                Console.WriteLine(" Please make sure value is in between 0 and 4 ");
            }

            Console.WriteLine(IncrementVersion(versionString, result));

        }


        static string IncrementVersion(string versionString, int index)
        {
            var parsedVersionString = new VersionStringParser().Parse(versionString);
            if (!parsedVersionString.IsValid)
                return parsedVersionString.InvalidReason;
            var incremented = new VersionIncrementer().Increment(parsedVersionString, index);
            var incrementedVersion = 
            incremented.Aggregate("",
                (combined, part) => String.Concat(combined, ".",
                    part.IsChar ? ((char) part.Value).ToString() : part.Value.ToString()));
            return incrementedVersion.TrimStart('.');
        }

        

    }
}

