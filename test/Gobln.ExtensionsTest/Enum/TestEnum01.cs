using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gobln.ExtensionsTest.Enum
{
    public enum TestEnum01
    {
        Info0 = 0,
        [Description("Enum test item 1")]
        Info1 = 1,
        [Display(Name = "Enum test item 2")]
        [Description("Enum test item 2")]
        Info2 = 2,
        [Display(Name = "Enum test item 3")]
        Info3 = 3,
        Info4 = 4,
    }
}
