using System;
using System.Linq;
namespace VersionUpdater
{
    public class VersionStringParser
    {
        public ParsedVersionString Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new ParsedVersionString() {InvalidReason="Input is empty"};
            

            var versionParts = input.Split('.');
            if(versionParts.Length!=4)
                return new ParsedVersionString() {InvalidReason="Post split length is not 4"};

            if (!int.TryParse(versionParts[0],out var _))
                return new ParsedVersionString() {InvalidReason="Major version has to be Int"};
            
            var versionPartValidator = new VersionPartParser();
            var parsedVersionString = new ParsedVersionString() {}; 
            foreach (var versionPart in versionParts)
            {

                var parsedPart = versionPartValidator.Parse(versionPart);
                if (parsedPart ==null)
                {
                    parsedVersionString.IsValid = false;
                    parsedVersionString.InvalidReason = @"{versionPart} is invalid";
                    return parsedVersionString;
                }
                
                parsedVersionString.IsValid = true;
                parsedVersionString.VersionParts.Add(parsedPart);
            }

            return parsedVersionString;

        }
    }
}