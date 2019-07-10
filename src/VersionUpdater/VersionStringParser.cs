using System;
using System.Linq;
namespace VersionUpdater
{
    class VersionStringParser
    {
        public static bool TryParse(string input, out string versionString)
        {
            versionString = "";
            if (string.IsNullOrWhiteSpace(input))
                return false;

            var versionParts = input.Split(".");
            var versionPartValidator = new VersionPartValidator();
            return versionParts.Aggregate(, (isValid, versionPart) => versionPartValidator.IsValid(versionPart));

        }
    }

    internal class VersionPartValidator
    {
        public bool IsValid(string versionPart)
        {
            if (string.IsNullOrWhiteSpace(versionPart))
                return false;
            if (Int32.TryParse(versionPart, out int versionNumber))
                return true;

        }
    }
}