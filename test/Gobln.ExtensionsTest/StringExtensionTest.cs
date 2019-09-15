using Gobln.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class StringExtensionTest
    {
        [TestMethod]
        public void StringTestContains()
        {
            if ("Find the word or words in the string".Contains(new[] { "word", "words" }))
            {
                //Word or words found
            }
        }

        [TestMethod]
        public void StringTestContainsAll()
        {
            if ("Find the word or words in the string".ContainsAll(new[] { "word", "words" }))
            {
                //Word or words found
            }

            if ("Find the word or words in the string".ContainsAll(new[] { "word", "More word" }))
            {
                //Word or words found
            }
        }

        [TestMethod]
        public void StringTestFirstUpperRestLower()
        {
            if ("Find the word or words in the string" == "FIND THE WORD OR WORDS IN the string".FirstUpperRestLower())
            {
                //Is same string
            }
        }

        [TestMethod]
        public void StringTestFirstUpperRestLowerSplit()
        {
            if ("Find The Word Or Words In The String" == "FIND THE WORD OR WORDS IN the string".FirstUpperRestLower(' '))
            {
                //Is same string
            }
        }

        [TestMethod]
        public void StringTestGetLeftFrom()
        {
            var left = "Find The Word Or Words In The String".GetLeftFrom(5);
        }

        [TestMethod]
        public void StringTestGetRightFrom()
        {
            var right = "Find The Word Or Words In The String".GetRightFrom(5);
        }

        [TestMethod]
        public void StringTestIsNumeric()
        {
            var notNumb = "test".IsNumeric();

            var numb = "5448736".IsNumeric();
        }

        [TestMethod]
        public void StringTestIsPalindrome()
        {
            var notPalindrome = "test".IsPalindrome();

            var palindrome = "tacocat".IsPalindrome();

            palindrome = "Tacocat".IsPalindrome();
        }

        [TestMethod]
        public void StringTestRepeat()
        {
            var repeat = "Repeat this".Repeat(6);
        }

        [TestMethod]
        public void StringTestReverse()
        {
            var reverse = "Reverse".Reverse();
        }

        [TestMethod]
        public void StringTestReplace()
        {
            var replace = "Replace some text in this string".Replace(new[] { 's', 't' }, 'd');

            replace = "Replace some text in this string".Replace(new[] { "this", "some" }, "");
        }

        [TestMethod]
        public void StringTestSplitCapitalizedWords()
        {
            var capitalWords = "TheLazyFoxSleepsUnderTheThree".SplitCapitalizedWords();
        }

        [TestMethod]
        public void StringTestColor()
        {
            var color = "#FFFFFF".ToColor();

            color = "4cbb17".ToColor();
        }

        [TestMethod]
        public void StringTestsimularity()
        {
            var simularity = "The lazy fox sleeps under the three".Similarity("The lazy fox sleeps under the three");

            simularity = "The lazy fox sleeps under the three".Similarity("TheLazyFoxSleepsUnderTheThree");
        }

        [TestMethod]
        public void StringTestTrim()
        {
            var trim = "The lazy fox sleeps under the three".TrimEnd("three");

            trim = "The lazy fox sleeps under the three".TrimEnd("THREE", StringComparison.OrdinalIgnoreCase);

            trim = "The lazy fox sleeps under the three".TrimStart("The");

            trim = "The lazy fox sleeps under the three".TrimStart("the", StringComparison.OrdinalIgnoreCase);
        }
    }
}
