using System;
using System.Collections.Generic;

namespace VersionUpdater
{
    public class VersionIncrementer
    {
        public List<ParsedPart> Increment(ParsedVersionString parsedVersionString, int indexToStart)
        {
            if (!parsedVersionString.IsValid)
                throw new ApplicationException("Can't Increment an invalid parsedVersion String");
            if(indexToStart>parsedVersionString.VersionParts.Count-1)
                throw new ApplicationException("Index out of Range of parsed version parts");
            var parsedParts = parsedVersionString.VersionParts;
            var indexToWorkOn = indexToStart;
            var startingPoint = parsedParts[indexToWorkOn];

            if (startingPoint.IsChar && (startingPoint.Value == 90 || startingPoint.Value == 122))
                return Increment(parsedVersionString, indexToStart - 1);

            var i = indexToWorkOn;
            parsedParts[i].Value = parsedParts[i].Value + 1;
            if (parsedParts[i].IsChar && parsedParts[i].Value == 91)
                parsedParts[i].Value = 65;
            if (parsedParts[i].IsChar && parsedParts[i].Value == 123)
                parsedParts[i].Value = 97;
            i += 1;
            while (i < parsedParts.Count)
            {
                var workOn = parsedParts[i];
                workOn.Value = workOn.IsChar ? IsCapitalCharacters(workOn.Value) ? 'A' : 'a' : 0;
                i++;
            }

            return parsedParts;
        }

        private bool IsCapitalCharacters(int value)
        {
            return value >= 65 && value <= 90;
        }
    }
}