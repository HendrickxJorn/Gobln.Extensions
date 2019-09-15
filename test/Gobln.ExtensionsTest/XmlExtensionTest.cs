using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Gobln.Extensions;
using System.IO;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class XmlExtensionTest
    {
        [TestMethod]
        public void XmlExtensionTestDocumentConvert()
        {
            var xmldoc = new XmlDocument();

            xmldoc.Load(new StringReader("<item><name>Test</name></item>"));

            var xdoc = xmldoc.ToXDocument();

            xmldoc = xdoc.ToXmlDocument();
        }

        [TestMethod]
        public void XmlExtensionTestElementConvert()
        {
            var xmldoc = new XmlDocument();

            var xmlElement = xmldoc.CreateElement("div");
            
            var xElement = xmlElement.ToXElement();

            xmlElement = xElement.ToXmlElement();
        }
    }
}
