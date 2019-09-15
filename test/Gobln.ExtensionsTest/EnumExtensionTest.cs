using Gobln.Extensions;
using Gobln.ExtensionsTest.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class EnumExtensionTest
    {
        [TestMethod]
        public void EnumTestGetDescriptionValue()
        {
            var value = TestEnum01.Info0.GetDescriptionValue();

            value = TestEnum01.Info1.GetDescriptionValue();

            value = TestEnum01.Info2.GetDescriptionValue();

            value = TestEnum01.Info3.GetDescriptionValue();

            value = TestEnum01.Info4.GetDescriptionValue();
        }

        [TestMethod]
        public void EnumTestGetDisplayValue()
        {
            var value = TestEnum01.Info0.GetDisplayName();

            value = TestEnum01.Info1.GetDisplayName();

            value = TestEnum01.Info2.GetDisplayName();

            value = TestEnum01.Info3.GetDisplayName();

            value = TestEnum01.Info4.GetDisplayName();
        }
    }
}
