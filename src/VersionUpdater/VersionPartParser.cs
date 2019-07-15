namespace VersionUpdater
{
    public class VersionPartParser
    {
        public ParsedPart Parse(string versionPart)
        {
            
            if (string.IsNullOrWhiteSpace(versionPart))
                return null;
            
            //if it is a valid integer, just return that
            if (int.TryParse(versionPart, out var versionNumber))
                return new ParsedPart() {IsChar = false, Value = versionNumber};

            if (versionPart.Length != 1)
                return null;

            var oneChar = versionPart[0];
            var asciiChar = (int) oneChar;

            //if its a char within range return that
            if ((asciiChar < 65 || asciiChar > 90) && (asciiChar < 97 || asciiChar > 122))
                return null; 
            
            return new ParsedPart() {IsChar = true, Value = asciiChar};

        }
    }
}