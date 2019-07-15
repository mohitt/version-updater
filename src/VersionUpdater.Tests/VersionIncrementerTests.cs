using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace VersionUpdater.Tests
{
    [TestFixture]
    public class VersionIncrementerTests
    {
        [Test]
        public void CanIncrementPureNumeric()
        {
            var versionIncrementer = new VersionIncrementer();
            var parsedVersionString = new ParsedVersionString()
            {
                IsValid = true,
                VersionParts = new List<ParsedPart>()
                {
                    new ParsedPart() {IsChar = false, Value = 1},
                    new ParsedPart() {IsChar = false, Value = 1},
                    new ParsedPart() {IsChar = false, Value = 1},
                    new ParsedPart() {IsChar = false, Value = 1},
                }
            };
            var incremented = versionIncrementer.Increment(parsedVersionString, 1);
            var incrementedVersion =
                incremented.Aggregate("",
                    (combined, part) => String.Concat(combined, ".",
                        part.IsChar ? ((char) part.Value).ToString() : part.Value.ToString()));
            Assert.AreEqual(incrementedVersion.TrimStart('.'), "1.2.0.0");
        }

        [Test]
        public void CanIncrementMixed()
        {
            var versionIncrementer = new VersionIncrementer();
            var parsedVersionString = new ParsedVersionString()
            {
                IsValid = true,
                VersionParts = new List<ParsedPart>()
                {
                    new ParsedPart() {IsChar = false, Value = 1},
                    new ParsedPart() {IsChar = true, Value = (int) 'a'},
                    new ParsedPart() {IsChar = false, Value = 1},
                    new ParsedPart() {IsChar = true, Value = (int) 'x'},
                }
            };
            var incremented = versionIncrementer.Increment(parsedVersionString, 1);
            var incrementedVersion =
                incremented.Aggregate("",
                    (combined, part) => String.Concat(combined, ".",
                        part.IsChar ? ((char) part.Value).ToString() : part.Value.ToString()));
            Assert.AreEqual(incrementedVersion.TrimStart('.'), "1.b.0.a");
        }

        [Test]
        public void WillThrowApplictionExcpetionIfIndexIsOutOfRange()
        {
            var versionIncrementer = new VersionIncrementer();
            var parsedVersionString = new ParsedVersionString()
            {
                IsValid = true,
                VersionParts = new List<ParsedPart>()
                {
                    new ParsedPart() {IsChar = false, Value = 1},
                    new ParsedPart() {IsChar = true, Value = (int) 'a'},
                    new ParsedPart() {IsChar = false, Value = 1},
                    new ParsedPart() {IsChar = true, Value = (int) 'x'},
                }
            };
            var ex = Assert.Throws<ApplicationException>(() =>
                {
                    var incremented = versionIncrementer.Increment(parsedVersionString, 10);
                }
            );
            Assert.AreEqual(ex.Message, "Index out of Range of parsed version parts");
        }
    }
}