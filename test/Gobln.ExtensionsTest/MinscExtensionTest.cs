using Gobln.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class MinscExtensionTest
    {
        [TestMethod]
        public void MinscTestUriBuilderAddPath()
        {
            var uri = new UriBuilder("https://stackoverflow.com/");

            uri.AddPath("question");
        }

        [TestMethod]
        public void MinscTestAttributeGetAttribute()
        {
            //Todo
        }

        [TestMethod]
        public void MinscTestAttributeHasAttribute()
        {
            //Todo
        }

        [TestMethod]
        public void MinscTestUriTypeGetCoreType()
        {
            var coreType = typeof(bool?).GetCoreType();

            coreType = typeof(int?).GetCoreType();
        }

        [TestMethod]
        public void MinscTestTypeIsNullableType()
        {
            var isNullable = typeof(bool?).IsNullableType();

            isNullable = typeof(int?).IsNullableType();
        }

        [TestMethod]
        public void MinscTestStringBuilderAppendLine()
        {
            var sb = new StringBuilder();

            // add line with formating
            sb.AppendLine("Adding line with formating => {0}", "formant the line");

            var testString = sb.ToString();

            //add 5 empty lines
            sb.AppendLine(5);

            testString = sb.ToString();

            //add array of lines
            sb.AppendLine(new string[] { "test", "info", "something" });

            testString = sb.ToString();
        }

        [TestMethod]
        public void MinscTestUriStringBuilderReplace()
        {
            var sb = new StringBuilder();

            sb.Append("this is an test for replacing charachers or strings");

            sb.Replace(new[] { 'e', 'a' }, 'o');

            var testString = sb.ToString();

            sb.Replace(new[] { "or", "is" }, "tt");

            testString = sb.ToString();
        }
    }
}
