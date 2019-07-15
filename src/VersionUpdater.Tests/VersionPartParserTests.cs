using NUnit.Framework;

namespace VersionUpdater.Tests
{
    [TestFixture]
    public class VersionPartParserTests
    {
        [TestCase("a")]
        [TestCase("A")]
        public void CanParseAlphabets(string versionPart)
        {
            var versionPartValidator = new VersionPartParser();
            var parsedPart = versionPartValidator.Parse(versionPart); 
            Assert.IsNotNull(parsedPart);
            Assert.IsTrue(parsedPart.IsChar);
            Assert.AreEqual(parsedPart.Value,(int)versionPart[0]);
        }
        
        [TestCase("10")]
        [TestCase("97")]
        [TestCase("65")]
        public void CanParseNumbers(string versionPart)
        {
            var versionPartValidator = new VersionPartParser();
            var parsedPart = versionPartValidator.Parse(versionPart); 
            Assert.IsNotNull(parsedPart);
            Assert.IsFalse(parsedPart.IsChar);
            Assert.AreEqual(parsedPart.Value,int.Parse(versionPart));
        }
        
        [TestCase("")]
        [TestCase("*")]
        [TestCase("(")]
        public void WillNotParseInvalidParts(string versionPart)
        {
            var versionPartValidator = new VersionPartParser();
            var parsedPart = versionPartValidator.Parse(versionPart); 
            Assert.IsNull(parsedPart);
        }
        
    }
}