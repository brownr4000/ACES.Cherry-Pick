using System.IO;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    /// TestFixture class provides methods to help with Unit Tests
    /// </summary>
    [SetUpFixture]
    public class TestFixture
    {

        /// <summary>
        /// The RunBeforeAnyTests method executes methods before any tests are performed
        /// </summary>
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // Run this code once when the test harness starts up.
            // This will copy over the latest version of the database files

            var DataWebPath = "../../../../src/wwwroot/data";
            var DataUTDirectory = "wwwroot";
            var DataUTPath = DataUTDirectory + "/data";

            // Delete the Detination folder
            if (Directory.Exists(DataUTDirectory))
            {
                Directory.Delete(DataUTDirectory, true);
            }

            // Make the directory
            Directory.CreateDirectory(DataUTPath);

            // Copy over all data files
            var filePaths = Directory.GetFiles(DataWebPath);
            foreach (var filename in filePaths)
            {
                string OriginalFilePathName = filename.ToString();
                var newFilePathName = OriginalFilePathName.Replace(DataWebPath, DataUTPath);

                File.Copy(OriginalFilePathName, newFilePathName);
            }
        }

        /// <summary>
        /// The RunAfterAnyTest method executes methods after any tests are performed
        /// </summary>
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}