using Gobln.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    class NumberExtensionTest
    {
        [TestMethod]
        public void NumberTestIsPrimeNumber()
        {
            //true
            var isPrime = 5.IsPrime();

            //false
            isPrime = 952.IsPrime();

            //true
            isPrime = 953.IsPrime();
        }

        [TestMethod]
        public void NumberTestIsPalindrome()
        {
            //true
            var isPalindrome = 5.IsPalindrome();

            //true
            isPalindrome = 555.IsPalindrome();

            //true
            isPalindrome = 9512332159.IsPalindrome();

            //false
            isPalindrome = 8886554.IsPalindrome();
        }

        [TestMethod]
        public void NumberTestIsEven()
        {
            //false
            var isEven = 5.IsEven();

            //true
            isEven = 2.IsEven();

            //true
            isEven = 1000000000.IsEven();

            //false
            isEven = 999999999.IsEven();
        }

        [TestMethod]
        public void NumberTestReverse()
        {
            long reverse = 50144.Reverse();

            reverse = 55648.Reverse();
            reverse = 2.Reverse();

            try
            {
                reverse = int.MaxValue.Reverse();
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void NumberTestLength()
        {
            //5
            long length = 50144.Length();

            //1
            length = 7.Length();

            //6
            length = (-55648).Length();

            //2
            length = (-2).Length();

            //5
            length = 50144.LengthAbs();

            //1
            length = 7.LengthAbs();

            //5
            length = (-55648).LengthAbs();

            //1
            length = (-2).LengthAbs();
        }

        [TestMethod]
        public void NumberTestGetFirstNumber()
        {
            //5
            long first = 50144.GetFirstNumber();

            //1
            first = 7.GetFirstNumber();

            //5
            first = (-55648).GetFirstNumber();

            //2
            first = (-2).GetFirstNumber();
        }

        [TestMethod]
        public void NumberTestToArray()
        {
            var arr = 50144.ToArray();
            arr = 7.ToArray();

            arr = (-55648).ToArray();
            arr = (-2).ToArray();
        }
    }
}
