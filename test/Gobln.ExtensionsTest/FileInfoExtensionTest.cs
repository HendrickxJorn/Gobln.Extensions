using Gobln.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class FileInfoExtensionTest
    {
        [TestMethod]
        public void FileInfoTestIsReady()
        {
            var fileInfo = new FileInfo("c:\\temp\\Test.txt");

            if (!fileInfo.Exists)
                fileInfo.Create();

            var isReady = fileInfo.IsReady();
        }

        [TestMethod]
        public void FileInfoTestNameWithoutExtension()
        {
            var fileInfo = new FileInfo("c:\\temp\\Test.txt");

            if (!fileInfo.Exists)
                fileInfo.Create();

            var name = fileInfo.NameWithoutExtension();
        }

        [TestMethod]
        public void FileInfoTestRename()
        {
            var fileInfo = new FileInfo("c:\\temp\\Test.txt");

            if (!fileInfo.Exists)
                fileInfo.Create();

            fileInfo.Rename("TestTest.txt");
        }
    }
}
