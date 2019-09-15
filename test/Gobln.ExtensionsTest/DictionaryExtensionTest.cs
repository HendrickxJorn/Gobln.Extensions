using Gobln.Domain;
using Gobln.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class DictionaryExtensionTest
    {
        [TestMethod]
        public void DictionaryTestMethodAddRange()
        {
            var dic = new Dictionary<int, string>()
            {
                { 1, "Test1" },
                { 2, "Test2" },
                { 3, "Test3" },
                { 4, "Test4" }
            };

            var dicToAdd = new Dictionary<int, string>()
            {
                { 5, "Test5" },
                { 6, "Test6" },
                { 7, "Test7" },
                { 8, "Test8" }
            };

            dic.AddRange(dicToAdd);
        }

        [TestMethod]
        public void DictionaryTestMethodAddRangeDuplicateInsertIgnore()
        {
            var dic = new Dictionary<int, string>()
            {
                { 1, "Test1" },
                { 2, "Test2" },
                { 3, "Test3" },
                { 4, "Test4" }
            };

            var dicToAdd = new Dictionary<int, string>()
            {
                { 3, "Test333" },
                { 4, "Test444" },
                { 5, "Test5" },
                { 6, "Test6" },
                { 7, "Test7" },
                { 8, "Test8" }
            };

            dic.AddRange(dicToAdd, AddRangesDuplicateInsertEnum.Ignore);
        }

        [TestMethod]
        public void DictionaryTestMethodAddRangeDuplicateInsertReplace()
        {
            var dic = new Dictionary<int, string>()
            {
                { 1, "Test1" },
                { 2, "Test2" },
                { 3, "Test3" },
                { 4, "Test4" }
            };

            var dicToAdd = new Dictionary<int, string>()
            {
                { 3, "Test333" },
                { 4, "Test444" },
                { 5, "Test5" },
                { 6, "Test6" },
                { 7, "Test7" },
                { 8, "Test8" }
            };

            dic.AddRange(dicToAdd, AddRangesDuplicateInsertEnum.Replace);
        }

        [TestMethod]
        public void DictionaryTestMethodAsEnumerable()
        {
            var e = new Dictionary<int, string>()
            {
                { 1, "Test1" },
                { 2, "Test2" },
                { 3, "Test3" },
                { 4, "Test4" },
                { 5, "Test333" },
                { 6, "Test444" },
                { 7, "Test5" },
                { 8, "Test6" },
                { 9, "Test7" },
                { 10, "Test8" }
            }.AsEnumerable();
        }


        [TestMethod]
        public void DictionaryTestMethodToList()
        {
            var l = new Dictionary<int, string>()
            {
                { 1, "Test1" },
                { 2, "Test2" },
                { 3, "Test3" },
                { 4, "Test4" },
                { 5, "Test5" },
                { 6, "Test6" },
                { 7, "Test7" },
                { 8, "Test8" }
            }.ToList();
        }

        [TestMethod]
        public void DictionaryTestMethodToArray()
        {
            var a = new Dictionary<int, string>()
            {
                { 1, "Test1" },
                { 2, "Test2" },
                { 3, "Test3" },
                { 4, "Test4" },
                { 5, "Test5" },
                { 6, "Test6" },
                { 7, "Test7" },
                { 8, "Test8" }
            }.ToArray();
        }

        [TestMethod]
        public void DictionaryTestMethodToHashTable()
        {
            var dic = new Dictionary<int, string>()
            {
                { 1, "Test1" },
                { 2, "Test2" },
                { 3, "Test3" },
                { 4, "Test4" }
            };

            var hash = dic.ToHashTable();
        }
    }
}