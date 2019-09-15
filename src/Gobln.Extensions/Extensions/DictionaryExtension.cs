using Gobln.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional extensions for <see cref="Dictionary{TKey, TValue}"/>
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// Adds the elements of the specified collection to the end of the <seealso cref="Dictionary{TKey, TValue}"/>.
        /// Duplicated keys will be Ignored.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="source">The <seealso cref="Dictionary{TKey, TValue}"/> to whitch the range will be added.</param>
        /// <param name="collection">The collection whose elements should be added to the end of the <seealso cref="Dictionary{TKey, TValue}"/>.
        /// The collection itself cannot be null, but it can contain elements that are null, if type <typeparamref name="TKey"/> is a reference type.</param>
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> source, Dictionary<TKey, TValue> collection)
        {
            source.AddRange(collection, AddRangesDuplicateInsertEnum.Ignore);
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <seealso cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="source">The <seealso cref="Dictionary{TKey, TValue}"/> to whitch the range will be added.</param>
        /// <param name="collection">The collection whose elements should be added to the end of the <seealso cref="Dictionary{TKey, TValue}"/>.
        /// The collection itself cannot be null, but it can contain elements that are null, if type <typeparamref name="TKey"/> is a reference type.</param>
        /// <param name="addRangesDuplicateInsert">How to handle duplicate keys.</param>
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> source, Dictionary<TKey, TValue> collection, AddRangesDuplicateInsertEnum addRangesDuplicateInsert)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            foreach (var item in collection)
            {
                if (!source.ContainsKey(item.Key))
                {
                    source.Add(item.Key, item.Value);
                }
                else
                {
                    switch (addRangesDuplicateInsert)
                    {
                        case AddRangesDuplicateInsertEnum.Replace:
                            source[item.Key] = item.Value;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a <seealso cref="IEnumerable{T}"/> of <seealso cref="KeyValuePair{TKey, TValue}"/> from an <seealso cref="IDictionary"/>
        /// </summary>
        /// <param name="source"></param>
        /// <returns><seealso cref="IEnumerable{T}"/> of <seealso cref="KeyValuePair{TKey, TValue}"/></returns>
        public static IEnumerable<KeyValuePair<TKey, TValue>> AsEnumerable<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            foreach (var item in source)
            {
                yield return new KeyValuePair<TKey, TValue>(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Creates a <seealso cref="List{T}"/> of <seealso cref="KeyValuePair{TKey, TValue}"/> from an <seealso cref="IDictionary"/>
        /// </summary>
        /// <param name="source"></param>
        /// <returns><seealso cref="List{T}"/> of <seealso cref="KeyValuePair{TKey, TValue}"/></returns>
        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            return source.AsEnumerable().ToList();
        }

        /// <summary>
        /// Creates a <seealso cref="Array"/> of <seealso cref="KeyValuePair{TKey, TValue}"/> from an <seealso cref="IDictionary"/>
        /// </summary>
        /// <param name="source"></param>
        /// <returns><seealso cref="Array"/> of <seealso cref="KeyValuePair{TKey, TValue}"/></returns>
        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            return source.AsEnumerable().ToArray();
        }

        /// <summary>
        /// Creates a non-generic Hashtable from the <seealso cref="Dictionary{TKey, TValue}"/>
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="source"></param>
        /// <returns><seealso cref="Hashtable"/></returns>
        public static Hashtable ToHashTable<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            var ht = new Hashtable();

            foreach (var item in source)
            {
                ht.Add(item.Key, item.Value);
            }

            return ht;
        }
    }
}