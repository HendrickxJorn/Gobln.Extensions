using System;
using System.Collections.Specialized;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional extensions for NameValueCollection
    /// </summary>
    public static class NameValueCollectionExtension
    {
        #region GetValue && TryGetValue

        /// <summary>
        /// Get the specific value and convert it to <typeparamref name="T"/>, if not found return the default value of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameValuePairs"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValue<T>(this NameValueCollection nameValuePairs, string key) where T : IConvertible
        {
            return GetValue<T>(nameValuePairs, key, default(T));
        }

        /// <summary>
        /// Get the specific value and convert it to <typeparamref name="T"/>, if not found return <paramref name="defaultValue"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameValuePairs"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetValue<T>(this NameValueCollection nameValuePairs, string key, T defaultValue) where T : IConvertible
        {
            var tempVal = defaultValue;

            return TryGetValue(nameValuePairs, key, out tempVal)
                ? tempVal
                : defaultValue;
        }

        /// <summary>
        /// Try get the value and convert it to <typeparamref name="T"/>, if not found return the default value of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameValuePairs"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryGetValue<T>(this NameValueCollection nameValuePairs, string key, out T value) where T : IConvertible
        {
            var val = nameValuePairs[key] ?? string.Empty;

            if (!string.IsNullOrEmpty(val))
            {
                var typeDefault = default(T);

                if (typeof(T) == typeof(string))
                {
                    typeDefault = (T)(object)string.Empty;
                }

                try
                {
                    value = (T)Convert.ChangeType(val, typeDefault.GetTypeCode());
                }
                catch
                {
                    value = default(T);

                    return false;
                }

                return true;
            }

            value = default(T);

            return false;
        }

        #endregion GetValue && TryGetValue
    }
}