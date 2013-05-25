using System;
using NUnit.Framework;
using INI;
using System.Collections.Generic;

namespace INITest.INIFileReaderTests
{
    [TestFixture]
    public class GetPropertiesTest
    {
        private INIFileReader fileReader;
        private Dictionary<string, string> FileExportFolderProperties;

        [SetUp]
        public void SetUp()
        {
            fileReader = new INIFileReader("Connections.INI");
            FileExportFolderProperties = new Dictionary<string, string>();
            FileExportFolderProperties.Add("Name", @"\\prodfile01\AppExport\Dev\");
            FileExportFolderProperties.Add("GPExtract", @"\\prodfin01\GPImportFiles\UAT_IMPORTS\");
            FileExportFolderProperties.Add("CreditRequests", @"\\prodfile01\AppExport\Dev\CreditRequests\");
            FileExportFolderProperties.Add("JetSchedule", @"\\PRODFIN01\Jet Source Folder\Tasks\");
        }

        [TearDown]
        public void TearDown()
        {
            fileReader.Dispose();
        }

        [Test]
        public void GetCorrectSectionPropertiesTest()
        {
            string sectionName = "[FileExportFolder]";
            var result = fileReader.GetProperties(sectionName);
            Assert.AreEqual(FileExportFolderProperties, result);
        }
    }
}
