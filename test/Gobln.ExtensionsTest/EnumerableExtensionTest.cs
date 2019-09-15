using Gobln.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class EnumerableExtensionTest
    {
        [TestMethod]
        public void EnumerableTestMedian()
        {
            var intArray = new int[] { 5, 84, 2, 6, 9, 4, 45, 26, 74, 11, 5, 3, 34, 2 };

            var median = intArray.Median();
        }

        [TestMethod]
        public void EnumerableTestStdDev()
        {
            var intArray = new int[] { 5, 84, 2, 6, 9, 4, 45, 26, 74, 11, 5, 3, 34, 2 };

            var stdDev = intArray.StdDev();

            var stdDevS = intArray.StdDevS();
        }

        [TestMethod]
        public void EnumerableTestDuplicates()
        {
            var intArray = new int[] { 5, 84, 2, 6, 9, 4, 45, 26, 74, 11, 5, 3, 34, 2 };

            if (intArray.HasDuplicates())
            {
                var duplicates = intArray.GetDuplicates().ToArray();
            }
        }

        [TestMethod]
        public void EnumerableTestBatch()
        {
            var intArray = new int[] { 5, 84, 2, 6, 9, 4, 45, 26, 74, 11, 5, 3, 34, 2 };

            var batch = intArray.ToBatch(5).ToArray();

            foreach (var item in batch)
            {
              
            }

            var batchevenly = intArray.ToBatchEvenly(3).ToArray();

            foreach (var item in batchevenly)
            {
               
            }
        }

        [TestMethod]
        public void EnumerableTestWhereIf()
        {
            var intArray = new int[] { 5, 84, 2, 6, 9, 4, 45, 26, 74, 11, 5, 3, 34, 2 };

            var newArray = intArray.WhereIf(1 == 0,
                                c => c > 40,
                                c => c < 40).ToArray();
        }

        [TestMethod]
        public void EnumerableTestAnyIf()
        {
            var intArray = new int[] { 5, 84, 2, 6, 9, 4, 45, 26, 74, 11, 5, 3, 34, 2 };

            var newArray = intArray.AnyIf(1 == 0,
                                c => c > 40,
                                c => c < 40);
        }
    }
}
