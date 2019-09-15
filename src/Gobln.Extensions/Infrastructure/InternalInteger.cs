using System.Linq;

namespace Gobln.Extensions.Infrastructure
{
    internal static class InternalInteger
    {
        /// <summary>
        /// Convert <see cref="string"/> of integer to and array of shorts
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isNegative"></param>
        /// <returns></returns>
        internal static short[] IntStringToArray(string value, bool isNegative)
        {
            var result = value
                .ToCharArray()
                .Select(c => (short)char.GetNumericValue(c));

            //Remove the negative sign
            if (isNegative)
            {
                result = result.Skip(1);
            }

            return result.ToArray();
        }
    }
}