using Gobln.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class NameValueCollectionExtensionTest
    {
        [TestMethod]
        public void NameValueCollectionTestGetData()
        {
            var testBool1 = ConfigurationManager.AppSettings.GetValue("TestBool", true);

            var testBool2 = ConfigurationManager.AppSettings.GetValue<bool>("TestBool");

            if (testBool1 == testBool2)
            { }

            var testNumer = ConfigurationManager.AppSettings.GetValue("TestNumer", 0);

            testNumer = testNumer;

            var testBoolError = ConfigurationManager.AppSettings.GetValue("TestBoolError", 0);

            testBoolError = testBoolError;

            var testBool3 = false;
            if (ConfigurationManager.AppSettings.TryGetValue("TestBoolError", out testBool3))
            {
                testBool3 = testBool3;
            }
        }
    }
}
