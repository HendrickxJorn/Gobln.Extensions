using Gobln.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class DirectoryInfoExtensionTest
    {
        [TestMethod]
        public void DirectoryTestDirectorySize()
        {
            var dir = new DirectoryInfo("c:\\temp");

            var size = dir.DirectorySize();
        }

        [TestMethod]
        public void DirectoryTestGetFileExtensions()
        {
            var dir = new DirectoryInfo("c:\\temp");

            var extentions = dir.GetFileExtensions();
        }

        [TestMethod]
        public void DirectoryTestRename()
        {
            var dir = new DirectoryInfo("c:\\temp");

            dir.Rename("Temp3");
        }
    }
}