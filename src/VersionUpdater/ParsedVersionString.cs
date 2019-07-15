using System.Collections.Generic;

namespace VersionUpdater
{
    public class ParsedVersionString
    {
        public ParsedVersionString()
        {
            VersionParts = new List<ParsedPart>();
        }
        public bool IsValid { get; set; }
        public string InvalidReason { get; set; }
        public List<ParsedPart> VersionParts { get; set; }
    }
}