using Gobln.Extensions.Internals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional string extensions
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Returns a value indicating whether any the specified System.String objects occurs within this string.
        /// Exceptions: System.ArgumentNullException: value is null.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="values">The strings to seek.</param>
        /// <returns>true if the value parameter occurs within this string, or if value is the empty string (""); otherwise, false.</returns>
        public static bool Contains(this string value, params string[] values)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            return !string.IsNullOrWhiteSpace(value) && values.Any(c => value.Contains(c));
        }

        /// <summary>
        /// Returns a value indicating whether all the specified System.String objects occurs within this string.
        /// Exceptions: System.ArgumentNullException: value is null.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="values">The strings to seek.</param>
        /// <returns>true if the value parameter occurs within this string, or if value is the empty string (""); otherwise, false.</returns>
        public static bool ContainsAll(this string value, params string[] values)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            return !string.IsNullOrWhiteSpace(value) && values.All(c => value.Contains(c));
        }

        /// <summary>
        /// Set the first letter to uppercase, and the rest to lower
        /// </summary>
        /// <param name="value">String</param>
        /// <returns>String or empty string</returns>
        public static string FirstUpperRestLower(this string value)
        {
            return string.IsNullOrEmpty(value)
                       ? string.Empty
                       : value.Substring(0, 1).ToUpperInvariant() + (value.Length > 1 ? value.Substring(1).ToLowerInvariant() : string.Empty);
        }

        /// <summary>
        /// First upper rest lower for every item in split
        /// </summary>
        /// <param name="value"></param>
        /// <param name="splitter">Split character</param>
        /// <returns>String or empty string</returns>
        public static string FirstUpperRestLower(this string value, char splitter)
        {
            return string.IsNullOrWhiteSpace(value)
                ? string.Empty
                : string.Join(splitter.ToString(), value.Split(splitter).Select(c => c.FirstUpperRestLower()));
        }

        /// <summary>
        /// Returns characters from left of specified length
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from left</returns>
        public static string GetLeftFrom(this string value, int length)
        {
            return value != null && value.Length > length
                ? value.Substring(0, length)
                : value;
        }

        /// <summary>
        /// Returns characters from right of specified length
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from right</returns>
        public static string GetRightFrom(this string value, int length)
        {
            return value != null && value.Length > length
                ? value.Substring(value.Length - length)
                : value;
        }

 
        /// <summary>
        /// Returns if a string consist only out of numbers
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string value)
        {
            return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^\d+$");
        }

        /// <summary>
        /// Check if the string is an palindrome
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if string is palindrome</returns>
        public static bool IsPalindrome(this string value)
        {
            return value != null && value.Equals(value.Reverse(), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Repeat the string value X times
        /// "test" 5 times => "testtesttesttesttest"
        /// </summary>
        /// <param name="value"></param>
        /// <param name="times">Positive number</param>
        /// <returns></returns>
        public static string Repeat(this string value, int times)
        {
            if (value == null)
            {
                return null;
            }

            if (value == string.Empty)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            if (times < 1)
            {
                return string.Empty;
            }

            for (var i = 0; i < times; i++)
            {
                sb.Append(value);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Reverse a string
        /// "This is an example." will return ".elpmaxe na si sihT"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Reverse(this string value)
        {
            var chars = value.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldChars">The Unicode characters to be replaced.</param>
        /// <param name="newChar">The Unicode character to replace all occurrences of oldChars.</param>
        /// <returns>A string that is equivalent to this instance except that all instances of oldChars are replaced with newChar.</returns>
        public static string Replace(this string value, char[] oldChars, char newChar)
        {
            foreach (var oldChar in oldChars)
            {
                value = value.Replace(oldChar, newChar);
            }

            return value;
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified strings in the current instance are replaced with another specified string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldValues">The strings to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of oldValues.</param>
        /// <returns>A string that is equivalent to the current string except that all instances of oldValue are replaced with newValue.</returns>
        public static string Replace(this string value, string[] oldValues, string newValue)
        {
            foreach (var oldValue in oldValues)
            {
                value = value.Replace(oldValue, newValue);
            }

            return value;
        }

        /// <summary>
        /// Split a string on each occurrence of a capital (assumed to be a word)
        /// F. i. TheLazyFox returns "The Lazy Fox"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SplitCapitalizedWords(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            var newText = new StringBuilder(value.Length * 2);
            newText.Append(value[0]);

            for (var i = 1; i < value.Length; i++)
            {
                if (char.IsUpper(value[i]))
                {
                    newText.Append(' ');
                }

                newText.Append(value[i]);
            }

            return newText.ToString();
        }

        /// <summary>
        /// Convert hex string to Color
        /// </summary>
        /// <param name="value">Hex string: "FFFFFF", "#FFFFFF", "FFFFFFFF", "#FFFFFFFF"</param>
        /// <returns></returns>
        public static Color ToColor(this string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return Color.Empty;
                }

                value = value.Replace("#", "").Trim();

                if (value.Length != 6 && value.Length != 8)
                {
                    return Color.Empty;
                }

                int a = 0, pos = 0;

                if (value.Length == 8)
                {
                    a = int.Parse(value.Substring(pos, 2), System.Globalization.NumberStyles.HexNumber);
                    pos += 2;
                }

                var r = int.Parse(value.Substring(pos, 2), System.Globalization.NumberStyles.HexNumber);
                pos += 2;

                var g = int.Parse(value.Substring(pos, 2), System.Globalization.NumberStyles.HexNumber);
                pos += 2;

                var b = int.Parse(value.Substring(pos, 2), System.Globalization.NumberStyles.HexNumber);

                return value.Length == 8
                    ? Color.FromArgb(a, r, g, b)
                    : Color.FromArgb(r, g, b);
            }
            catch (Exception)
            {
                return Color.Empty;
            }
        }

        /// <summary>
        /// Calculate the simulatity between 2 strings
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target">String to compare to</param>
        /// <returns>Returns value form 0 to 1, where 1 is perfect match and 0 is total different</returns>
        public static double Similarity(this string source, string target)
        {
            if ((string.IsNullOrEmpty(source) && string.IsNullOrEmpty(target)) || (source == target))
            {
                return 1;
            }

            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
            {
                return 0;
            }

            return 1.0 - new Levenshtein().LevenshteinDistance(source, target) / (double)Math.Max(source.Length, target.Length);
        }

        #region Trim

        //Exist String.TrimEnd(params char[] trimChars)
        /// <summary>
        /// Trim the string if it end with a specific word
        /// </summary>
        /// <param name="value"></param>
        /// <param name="trim">Trim text</param>
        /// <returns></returns>
        public static string TrimEnd(this string value, string trim)
        {
            var result = value;

            while (result.EndsWith(trim))
            {
                result = result.Substring(0, result.Length - trim.Length);
            }

            return result;
        }

        //Exist String.TrimEnd(params char[] trimChars)
        /// <summary>
        /// Trim the string if it end with a specific word
        /// </summary>
        /// <param name="value"></param>
        /// <param name="trim">Trim text</param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static string TrimEnd(this string value, string trim, StringComparison stringComparison)
        {
            var result = value;

            while (result.EndsWith(trim, stringComparison))
            {
                result = result.Substring(0, result.Length - trim.Length);
            }

            return result;
        }

        //Exist String.TrimStart(params char[] trimChars)
        /// <summary>
        /// Trim the string if it start with a specific word
        /// </summary>
        /// <param name="value"></param>
        /// <param name="trim">Trim text</param>
        /// <returns></returns>
        public static string TrimStart(this string value, string trim)
        {
            var result = value;

            while (result.StartsWith(trim))
            {
                result = result.Substring(trim.Length);
            }

            return result;
        }

        //Exist String.TrimStart(params char[] trimChars)
        /// <summary>
        /// Trim the string if it start with a specific word
        /// </summary>
        /// <param name="value"></param>
        /// <param name="trim">Trim text</param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static string TrimStart(this string value, string trim, StringComparison stringComparison)
        {
            var result = value;

            while (result.StartsWith(trim, stringComparison))
            {
                result = result.Substring(trim.Length);
            }

            return result;
        }

        #endregion Trim

        #region Split

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by an regular expression patern.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regexPattern">Regural expresion</param>
        /// <returns>An array whose elements contain the substrings in this string.</returns>
        public static string[] Split(this string value, string regexPattern)
        {
            return value.Split(regexPattern, RegexOptions.None, StringSplitOptions.None);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by an regular expression patern.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regexPattern">Regural expresion</param>
        /// <param name="options">System.StringSplitOptions.RemoveEmptyEntries to omit empty array elements from the array returned; or System.StringSplitOptions.None to include empty array elements in the array returned.</param>
        /// <returns>An array whose elements contain the substrings in this string.</returns>
        public static string[] Split(this string value, string regexPattern, StringSplitOptions options)
        {
            return value.Split(regexPattern, RegexOptions.None, options);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by an regular expression patern.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regexPattern">Regural expresion</param>
        /// <param name="regexOptions"></param>
        /// <returns>An array whose elements contain the substrings in this string.</returns>
        public static string[] Split(this string value, string regexPattern, RegexOptions regexOptions)
        {
            return value.Split(regexPattern, regexOptions, StringSplitOptions.None);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by an regular expression patern.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regexPattern">Regural expresion</param>
        /// <param name="regexOptions"></param>
        /// <param name="options">System.StringSplitOptions.RemoveEmptyEntries to omit empty array elements from the array returned; or System.StringSplitOptions.None to include empty array elements in the array returned.</param>
        /// <returns>An array whose elements contain the substrings in this string.</returns>
        public static string[] Split(this string value, string regexPattern, RegexOptions regexOptions, StringSplitOptions options)
        {
            var temp = Regex.Split(value, regexPattern, regexOptions);

            return options == StringSplitOptions.RemoveEmptyEntries
                ? temp.Where(c => c != string.Empty).ToArray()
                : temp;
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are seperated a given fixed length.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length">Size of each substring.</param>
        /// <returns>An array whose elements contain the substrings in this string.</returns>
        public static string[] Split(this string value, int length)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException();
            }

            if (length < 1)
            {
                throw new ArgumentException();
            }

            return PrivateSplit(value, length).ToArray();
        }

        #region private

        private static IEnumerable<string> PrivateSplit(string value, int length)
        {
            for (var i = 0; i < value.Length; i += length)
            {
                yield return value.Substring(i, length + i > value.Length ? value.Length - i : length);
            }
        }

        #endregion private

        #endregion Split
    }
}