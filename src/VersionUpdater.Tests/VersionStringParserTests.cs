using NUnit.Framework;

namespace VersionUpdater.Tests
{
    [TestFixture]
    public class VersionStringParserTests
    {
        [TestCase("1.2.3.4")]
        public void CanParseOnlyNumbers(string version)
        {
            var versionStringParser = new VersionStringParser();
            var parsedVersion = versionStringParser.Parse(version);
            Assert.NotNull(parsedVersion);
            Assert.IsTrue(parsedVersion.IsValid);
            Assert.AreEqual(parsedVersion.VersionParts.Count,4);
            Assert.AreEqual(parsedVersion.VersionParts[0].Value,1);
            Assert.AreEqual(parsedVersion.VersionParts[0].IsChar,false);
            
            Assert.AreEqual(parsedVersion.VersionParts[1].Value,2);
            Assert.AreEqual(parsedVersion.VersionParts[1].IsChar,false);
            
            Assert.AreEqual(parsedVersion.VersionParts[2].Value,3);
            Assert.AreEqual(parsedVersion.VersionParts[2].IsChar,false);
            
            Assert.AreEqual(parsedVersion.VersionParts[3].Value,4);
            Assert.AreEqual(parsedVersion.VersionParts[3].IsChar,false);
        }
        
        [TestCase("1.A.a.4")]
        public void CanParseMixed(string version)
        {
            var versionStringParser = new VersionStringParser();
            var parsedVersion = versionStringParser.Parse(version);
            Assert.NotNull(parsedVersion);
            Assert.IsTrue(parsedVersion.IsValid);
            Assert.AreEqual(parsedVersion.VersionParts.Count,4);
            Assert.AreEqual(parsedVersion.VersionParts[0].Value,1);
            Assert.AreEqual(parsedVersion.VersionParts[0].IsChar,false);
            
            Assert.AreEqual(parsedVersion.VersionParts[1].Value,65);
            Assert.AreEqual(parsedVersion.VersionParts[1].IsChar,true);
            
            Assert.AreEqual(parsedVersion.VersionParts[2].Value,97);
            Assert.AreEqual(parsedVersion.VersionParts[2].IsChar,true);
            
            Assert.AreEqual(parsedVersion.VersionParts[3].Value,4);
            Assert.AreEqual(parsedVersion.VersionParts[3].IsChar,false);
        }
        
        
        [TestCase("1.A.")]
        public void WillReturnInvalid(string version)
        {
            var versionStringParser = new VersionStringParser();
            var parsedVersion = versionStringParser.Parse(version);
            Assert.NotNull(parsedVersion);
            Assert.IsFalse(parsedVersion.IsValid);
            Assert.AreEqual(parsedVersion.InvalidReason,"Post split length is not 4");
        }
        
        [TestCase("")]
        public void WillReturnNull(string version)
        {
            var versionStringParser = new VersionStringParser();
            var parsedVersion = versionStringParser.Parse(version);
            Assert.NotNull(parsedVersion);
            Assert.IsFalse(parsedVersion.IsValid);
            Assert.AreEqual(parsedVersion.InvalidReason,"Input is empty");
        }
        
        [TestCase("Z.0.0.0")]
        [TestCase("z.0.0.0")]
        public void MajorVersionHasToBeInt(string version)
        {
            var versionStringParser = new VersionStringParser();
            var parsedVersion = versionStringParser.Parse(version);
            Assert.NotNull(parsedVersion);
            Assert.IsFalse(parsedVersion.IsValid);
            Assert.AreEqual(parsedVersion.InvalidReason,"Major version has to be Int");
        }
        
    }
}