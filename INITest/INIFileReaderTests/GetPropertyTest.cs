using System;
using NUnit.Framework;
using INI;
using INI.CustomExceptions;

namespace INITest.INIFileReaderTests
{
    [TestFixture]
    public class GetPropertyTest
    {
        private INIFileReader fileReader;

        [SetUp]
        public void SetUp()
        {
            fileReader = new INIFileReader("Connections.INI");
        }

        [TearDown]
        public void TearDown()
        {
            fileReader.Dispose();
        }

        [Test]
        public void CorrectSectionAndCorrectPtyTest()
        {
            string sectionName = "[Environment]",
                ptyKey = "Name";
            var result = fileReader.GetProperty(sectionName, ptyKey);

            Assert.AreEqual("Development", result);
        }

        [Test]
        public void CorrectSectionAndInCorrectPtyTest()
        {
            string sectionName = "[Environment]",
                ptyKey = "Incorrect";

            Assert.Throws<INIPropertyNotFoundException>(() => fileReader.GetProperty(sectionName, ptyKey));
        }

        [Test]
        public void InCorrectSectionAndCorrectPtyTest()
        {
            string sectionName = "[SectionName]",
                ptyKey = "Incorrect";
            Assert.Throws<INIPropertyNotFoundException>(() => fileReader.GetProperty(sectionName, ptyKey));
        }
    }
}
