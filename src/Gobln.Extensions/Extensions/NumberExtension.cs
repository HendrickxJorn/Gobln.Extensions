using Gobln.Extensions.Infrastructure;
using System;
using System.Linq;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional extensions on number types
    /// </summary>
    public static class NumberExtension
    {
        #region IsPrimeNumber

        /// <summary>
        /// Check if the value is a prime number
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if prime</returns>
        public static bool IsPrime(this short value)
        {
            return ((long)value).IsPrime();
        }

        /// <summary>
        /// Check if the value is a prime number
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if prime</returns>
        public static bool IsPrime(this int value)
        {
            return ((long)value).IsPrime();
        }

        /// <summary>
        /// Check if the value is a prime number
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if prime</returns>
        public static bool IsPrime(this long value)
        {
            //filter out everyting under 10 and even numbers

            //filter out 2 and 3 and 5 and 7
            if ((new long[] { 2, 3, 5, 7 }).Contains(value))
            {
                return true;
            }

            //filter out smaller then 2
            //and diviable by 2
            //and value 9
            if (value < 2 || value.IsEven() || value == 9)
            {
                return false;
            }

            for (var i = 3; i * i <= value; i += 2)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion IsPrimeNumber

        #region IsPalindrome

        /// <summary>
        /// Check if the value is a palindrome
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if is palindrome</returns>
        public static bool IsPalindrome(this short value)
        {
            return value.ToString().IsPalindrome();
        }

        /// <summary>
        /// Check if the value is a palindrome
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if is palindrome</returns>
        public static bool IsPalindrome(this int value)
        {
            return value.ToString().IsPalindrome();
        }

        /// <summary>
        /// Check if the value is a palindrome
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if is palindrome</returns>
        public static bool IsPalindrome(this long value)
        {
            return value.ToString().IsPalindrome();
        }

        #endregion IsPalindrome

        #region IsEven

        /// <summary>
        /// Checks whether value is an even number
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if is even</returns>
        public static bool IsEven(this short value)
        {
            return ((long)value).IsEven();
        }

        /// <summary>
        /// Checks whether value is an even number
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if is even</returns>
        public static bool IsEven(this int value)
        {
            return ((long)value).IsEven();
        }

        /// <summary>
        /// Checks whether value is an even number
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if is even</returns>
        public static bool IsEven(this long value)
        {
            return value % 2 == 0;
        }

        #endregion IsEven

        #region Reverse

        /// <summary>
        /// Reverse the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value reversed</returns>
        public static short Reverse(this short value)
        {
            var rev = ((long)value).Reverse();

            if (short.MaxValue < rev)
            {
                throw new OverflowException("Reverse value is greater then maximum value of short.");
            }

            if (rev < short.MinValue)
            {
                throw new OverflowException("Reverse value is smaller then minimum value of short.");
            }

            return (short)rev;
        }

        /// <summary>
        /// Reverse the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value reversed</returns>
        public static int Reverse(this int value)
        {
            var rev = ((long)value).Reverse();

            if (int.MaxValue < rev)
            {
                throw new OverflowException("Reverse value is greater then maximum value of integer.");
            }
            else if (rev < int.MinValue)
            {
                throw new OverflowException("Reverse value is smaller then minimum value of integer.");
            }
            else
            {
                return (int)rev;
            }
        }

        /// <summary>
        /// Reverse the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Value reversed</returns>
        public static long Reverse(this long value)
        {
            var isNegative = value < 0;
            long result = 0;

            try
            {
                while ((value > 0 && !isNegative) || (value < 0 && isNegative))
                {
                    result = result * 10 + value % 10;
                    value /= 10;
                }

                return result;
            }
            catch (OverflowException ex)
            {
                throw ex;
            }
        }

        #endregion Reverse

        #region Length

        /// <summary>
        /// Return the length of the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Length(this short value)
        {
            return LengthAbs(value) + (value < 0 ? 1 : 0);
        }

        /// <summary>
        /// Return the number of numbers used in the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int LengthAbs(this short value)
        {
            var tempVal = value;

            if (tempVal == 0)
            {
                return 1;
            }

            //Abs of MinValue => exception
            if (tempVal == short.MinValue)
            {
                return 5;
            }

            if (tempVal < 0)
            {
                tempVal = Math.Abs(tempVal);
            }

            return (int)Math.Floor(Math.Log10(tempVal) + 1);
        }

        /// <summary>
        /// Return the length of the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Length(this int value)
        {
            return LengthAbs(value) + (value < 0 ? 1 : 0);
        }

        /// <summary>
        /// Return the number of numbers used in the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int LengthAbs(this int value)
        {
            var tempVal = value;

            if (tempVal == 0)
            {
                return 1;
            }

            //Abs of MinValue => exception
            if (tempVal == int.MinValue)
            {
                return 10;
            }

            if (tempVal < 0)
            {
                tempVal = Math.Abs(tempVal);
            }

            return (int)Math.Floor(Math.Log10(tempVal) + 1);
        }

        /// <summary>
        /// Return the length of the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Length(this long value)
        {
            return LengthAbs(value) + (value < 0 ? 1 : 0);
        }

        /// <summary>
        /// Return the number of numbers used in the value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int LengthAbs(this long value)
        {
            var tempVal = value;

            if (tempVal == 0)
            {
                return 1;
            }

            //Abs of MinValue => exception
            if (tempVal == long.MinValue)
            {
                return 19;
            }

            if (tempVal < 0)
            {
                tempVal = Math.Abs(tempVal);
            }

            return (int)Math.Floor(Math.Log10(tempVal) + 1);
        }

        #endregion Length

        #region GetFirstNumber

        /// <summary>
        /// Get the first number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short GetFirstNumber(this short value)
        {
            return GetFirstNumber(value, 1);
        }

        /// <summary>
        /// Get the fist x numbers, where x is <paramref name="take"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="take">Amount numbers to taken</param>
        /// <returns></returns>
        public static short GetFirstNumber(this short value, int take)
        {
            if (take < 1)
            {
                throw new ArgumentException("May not be less then 1", "length");
            }

            var tempLength = value.LengthAbs();

            if (tempLength < take)
            {
                throw new ArgumentException("May not be greater then the absolute length of the short", "length");
            }

            var divider = (short)Math.Pow(10, (tempLength - take));

            return (short)Math.Abs(value / divider);
        }

        /// <summary>
        /// Get the first number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short GetFirstNumber(this int value)
        {
            return (short)GetFirstNumber(value, 1);
        }

        /// <summary>
        /// Get the fist x numbers, where x is <paramref name="take"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="take">Amount numbers to taken</param>
        /// <returns></returns>
        public static int GetFirstNumber(this int value, int take)
        {
            if (take < 1)
            {
                throw new ArgumentException("May not be less then 1", "length");
            }

            var tempLength = value.LengthAbs();

            if (tempLength < take)
            {
                throw new ArgumentException("May not be greater then the absolute length of the integer", "length");
            }

            var divider = (int)Math.Pow(10, (tempLength - take));

            return Math.Abs(value / divider);
        }

        /// <summary>
        /// Get the first number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static short GetFirstNumber(this long value)
        {
            return (short)GetFirstNumber(value, 1);
        }

        /// <summary>
        /// Get the fist x numbers, where x is <paramref name="take"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="take">Amount numbers to taken</param>
        /// <returns></returns>
        public static long GetFirstNumber(this long value, int take)
        {
            if (take < 1)
            {
                throw new ArgumentException("May not be less then 1", "length");
            }

            var tempLength = value.LengthAbs();

            if (tempLength < take)
            {
                throw new ArgumentException("May not be greater then the absolute length of the long", "length");
            }

            var divider = (long)Math.Pow(10, (tempLength - take));

            return Math.Abs(value / divider);
        }

        #endregion GetFirstNumber

        #region ToArray

        /// <summary>
        /// Creates an array from the value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>An array of <see cref="short"/>.</returns>
        public static short[] ToArray(this short value)
        {
            return InternalInteger.IntStringToArray(value.ToString(), value < 0);
        }

        /// <summary>
        /// Creates an array from the value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>An array of <see cref="short"/>.</returns>
        public static short[] ToArray(this int value)
        {
            return InternalInteger.IntStringToArray(value.ToString(), value < 0);
        }

        /// <summary>
        /// Creates an array from the value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>An array of <see cref="short"/>.</returns>
        public static short[] ToArray(this long value)
        {
            return InternalInteger.IntStringToArray(value.ToString(), value < 0);
        }

        #endregion ToArray
    }
}