using System.Xml;
using System.Xml.Linq;

namespace Gobln.Extensions
{
    /// <summary>
    ///  Additional extensions for Xml
    /// </summary>
    public static class XmlExtension
    {
        #region System.Xml

        /// <summary>
        /// Convert to <see cref="XmlElement"/>
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static XmlElement ToXmlElement(this XElement xElement)
        {
            if (xElement == null)
            {
                return null;
            }

            var doc = new XmlDocument();

            doc.Load(xElement.CreateReader());

            return doc.DocumentElement;
        }

        /// <summary>
        /// Convert to <see cref="XmlDocument"/>
        /// </summary>
        /// <param name="xDocument"></param>
        /// <returns></returns>
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            if (xDocument == null)
            {
                return null;
            }

            var doc = new XmlDocument();

            using (var xml = xDocument.CreateReader())
            {
                doc.Load(xml);
            }

            return doc;
        }

        #endregion System.Xml

        #region System.Xml.Linq

        /// <summary>
        /// Convert to <see cref="XElement"/>
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <returns></returns>
        public static XElement ToXElement(this XmlElement xmlElement)
        {
            return xmlElement == null ? null : XElement.Parse(xmlElement.OuterXml);
        }

        /// <summary>
        /// Convert to <see cref="XDocument"/>
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            if (xmlDocument == null)
            {
                return null;
            }

            using (var xml = new XmlNodeReader(xmlDocument))
            {
                xml.MoveToContent();
                return XDocument.Load(xml);
            }
        }

        #endregion System.Xml.Linq
    }
}