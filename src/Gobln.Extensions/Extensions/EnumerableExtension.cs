using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional extensions for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtension
    {
        #region Median

        /// <summary>
        /// Returns the most middle value
        /// </summary>
        /// <param name="source">The calculate the median.</param>
        /// <returns></returns>
        public static decimal Median(this IEnumerable<int> source)
        {
            var count = source.Count();

            if (count == 0)
            {
                return 0;
            }

            var list = source.OrderBy(c => c).ToArray();

            if (count % 2 != 0)
            {
                return list[(int)Math.Ceiling((double)count / 2) - 1];
            }

            var checkMax = count / 2;

            return (list[checkMax - 1] + list[checkMax]) / 2;
        }

        /// <summary>
        /// Returns the most middle value
        /// </summary>
        /// <param name="source">The calculate the median.</param>
        /// <returns></returns>
        public static decimal Median(this IEnumerable<decimal> source)
        {
            var count = source.Count();

            if (count == 0)
            {
                return 0;
            }

            var list = source.OrderBy(c => c).ToArray();

            if (count % 2 != 0)
            {
                return list[(int)Math.Ceiling((double)count / 2) - 1];
            }

            var checkMax = count / 2;

            return (list[checkMax - 1] + list[checkMax]) / 2;
        }

        /// <summary>
        /// Returns the most middle value
        /// </summary>
        /// <param name="source">The calculate the median.</param>
        /// <returns></returns>
        public static double Median(this IEnumerable<double> source)
        {
            var count = source.Count();

            if (count == 0)
            {
                return 0;
            }

            var list = source.OrderBy(c => c).ToArray();

            if (count % 2 != 0)
            {
                return list[(int)Math.Ceiling((double)count / 2) - 1];
            }

            var checkMax = count / 2;

            return (list[checkMax - 1] + list[checkMax]) / 2;
        }

        #endregion Median

        #region Standard deviation

        /// <summary>
        /// Calculate the normal standaard deviation
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Standaard deviation</returns>
        public static decimal StdDev(this IEnumerable<int> source)
        {
            return Convert.ToDecimal(StdDevLogic(source.Select(c => (double)c), 0));
        }

        /// <summary>
        /// Calculate the normal standaard deviation
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Standaard deviation</returns>
        public static decimal StdDev(this IEnumerable<decimal> source)
        {
            return Convert.ToDecimal(StdDevLogic(source.Select(c => (double)c), 0));
        }

        /// <summary>
        /// Calculate the normal standaard deviation
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Standaard deviation</returns>
        public static double StdDev(this IEnumerable<double> source)
        {
            return StdDevLogic(source, 0);
        }

        /// <summary>
        /// Calculate the normal standaard deviation
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Standaard deviation</returns>
        public static float StdDev(this IEnumerable<float> source)
        {
            return (float)StdDevLogic(source.Select(c => (double)c), 0);
        }

        /// <summary>
        /// Calculate the sample standaard deviation
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Standaard deviation</returns>
        public static decimal StdDevS(this IEnumerable<int> source)
        {
            return Convert.ToDecimal(StdDevLogic(source.Select(c => (double)c), 1));
        }

        /// <summary>
        /// Calculate the sample standaard deviation
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Standaard deviation</returns>
        public static decimal StdDevS(this IEnumerable<decimal> source)
        {
            return Convert.ToDecimal(StdDevLogic(source.Select(c => (double)c), 1));
        }

        /// <summary>
        /// Calculate the sample standaard deviation
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Standaard deviation</returns>
        public static double StdDevS(this IEnumerable<double> source)
        {
            return StdDevLogic(source, 1);
        }

        /// <summary>
        /// Calculate the sample standaard deviation
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Standaard deviation</returns>
        public static float StdDevS(this IEnumerable<float> source)
        {
            return (float)StdDevLogic(source.Select(c => (double)c), 1);
        }

        private static double StdDevLogic(this IEnumerable<double> source, int buffer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var average = source.Average();
            var differences = source.Sum(c => Math.Pow(average - c, 2.0));
            return Math.Sqrt(differences / (source.Count() - buffer));
        }

        #endregion Standard deviation

        #region Duplicates

        /// <summary>
        /// Check if the <see cref="IEnumerable{T}"/> contains an double.
        /// </summary>
        /// <remarks>
        /// For simple <see cref="IEnumerable{T}"/> (ie: list of string, or array of int, ....), and complex <see cref="IEnumerable{T}"/> with implementation of IEqualityComparer.
        /// If you do not get the result, change the function of Equals of IEqualityComparer.
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns>True if contains any doubles</returns>
        public static bool HasDuplicates<T>(this IEnumerable<T> source)
        {
            return HasDuplicates(source, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Check if the <see cref="IEnumerable{T}"/> contains an double.
        /// </summary>
        /// <remarks>
        /// For simple <see cref="IEnumerable{T}"/> (ie: list of string, or array of int, ....), and complex <see cref="IEnumerable{T}"/> with implementation of IEqualityComparer.
        /// If you do not get the result, change the function of Equals of IEqualityComparer.
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="comparer">Custom IEqualityComparer comparer</param>
        /// <returns>True if contains any doubles</returns>
        public static bool HasDuplicates<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            var set = new HashSet<T>(comparer);

            return source.Any(c => !set.Add(c));
        }

        /// <summary>
        /// Return an <see cref="IEnumerable{T}"/> with all double values.
        /// </summary>
        /// <remarks>
        /// For simple <see cref="IEnumerable{T}"/> (ie: list of string, or array of int, ....), and complex <see cref="IEnumerable{T}"/> with implementation of IEqualityComparer.
        /// If you do not get the result, change the function of Equals of IEqualityComparer.
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns>Returns all the duplicats</returns>
        public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> source)
        {
            return GetDuplicates(source, EqualityComparer<T>.Default);
        }

        /// <summary>
        /// Return an <see cref="IEnumerable{T}"/> with all double values.
        /// </summary>
        /// <remarks>
        /// For simple <see cref="IEnumerable{T}"/> (ie: list of string, or array of int, ....), and complex <see cref="IEnumerable{T}"/> with implementation of IEqualityComparer.
        /// If you do not get the result, change the function of Equals of IEqualityComparer.
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="comparer">Custom IEqualityComparer comparer</param>
        /// <returns>Returns all the duplicats</returns>
        public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            var compare = new HashSet<T>(comparer);

            return source.Where(c => !compare.Add(c)).Distinct();
        }

        #endregion Duplicates

        #region Batch

        /// <summary>
        /// Divides <see cref="IQueryable{T}"/> into batches
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IQueryable{T}"/></param>
        /// <param name="size">The max number of <typeparamref name="T"/> per batch</param>
        /// <returns>An IEnumerable of <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<IEnumerable<T>> ToBatch<T>(this IQueryable<T> source, int size)
        {
            return source.ToArray().ToBatch(size);
        }

        /// <summary>
        /// Divides <see cref="IEnumerable{T}"/> into batches
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/></param>
        /// <param name="size">The max number of <typeparamref name="T"/> per batch</param>
        /// <returns>An IEnumerable of <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<IEnumerable<T>> ToBatch<T>(this IEnumerable<T> source, int size)
        {
            var batch = new List<T>();

            if (size > 0)
            {
                foreach (var item in source)
                {
                    batch.Add(item);
                    if (batch.Count == size)
                    {
                        yield return batch;
                        batch = new List<T>();
                        //batch.Clear(); //// => Can create problems
                    }
                }
            }

            if (batch.Any())
            {
                yield return batch;
            }
        }

        /// <summary>
        /// Divides <see cref="IQueryable{T}"/> into <paramref name="amount"/> batchs of the same size
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IQueryable{T}"/></param>
        /// <param name="amount">Howmany batches must be created</param>
        /// <returns>IEnumerable of <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<IEnumerable<T>> ToBatchEvenly<T>(this IQueryable<T> source, int amount)
        {
            return source.ToArray().ToBatchEvenly(amount);
        }

        /// <summary>
        /// Divides <see cref="IEnumerable{T}"/> into <paramref name="amount"/> batchs of the same size
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/></param>
        /// <param name="amount">Howmany batches must be created</param>
        /// <returns>IEnumerable of <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<IEnumerable<T>> ToBatchEvenly<T>(this IEnumerable<T> source, int amount)
        {
            var size = 0;

            if (source.Any() && amount > 0)
            {
                size = Convert.ToInt32(Math.Ceiling(source.Count() / (decimal)amount));
            }

            return source.ToBatch(size);
        }

        #endregion Batch

        /// <summary>
        /// Create a Pivot table
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TFirstKey"></typeparam>
        /// <typeparam name="TSecondKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="firstKey"></param>
        /// <param name="secondKey"></param>
        /// <param name="aggregate"></param>
        /// <returns></returns>
        public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>> Pivot<TSource, TFirstKey, TSecondKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TFirstKey> firstKey, Func<TSource, TSecondKey> secondKey, Func<IEnumerable<TSource>, TValue> aggregate)
        {
            return source
                .ToLookup(firstKey)
                .ToDictionary(c => c.Key, c => c.ToLookup(secondKey)
                    .ToDictionary(d => d.Key, d => aggregate(d)));
        }

        /// <summary>
        /// Creates a <see cref="Collection{T}"/> from an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <returns>A <see cref="Collection{T}"/> that contains elements from the input sequence.</returns>
        public static Collection<T> ToCollection<T>(this IEnumerable<T> source)
        {
            var col = new Collection<T>();

            foreach (var item in source)
            {
                col.Add(item);
            }

            return col;
        }

        #region Random

        /// <summary>
        /// Return random item <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <returns>Random item of <typeparamref name="T"/></returns>
        public static T RandomItem<T>(this IEnumerable<T> source)
        {
            return source.RandomItem(new Random());
        }

        /// <summary>
        /// Return random item <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="random">Instance of <see cref="Random"/> by wich the item will be found</param>
        /// <returns>Random item of <typeparamref name="T"/></returns>
        public static T RandomItem<T>(this IEnumerable<T> source, Random random)
        {
            return source.ElementAt(random.Next(source.Count()));
        }

        /// <summary>
        /// Randomize the order of the IEnumerable
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <returns>Randomized <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            return source.Randomize(new Random());
        }

        /// <summary>
        /// Randomize the order of the IEnumerable
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="random">Instance of <see cref="Random"/> by wich the randomisation will happen</param>
        /// <returns>Randomized <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source, Random random)
        {
            return source.OrderBy(c => random.Next(source.Count()));
        }

        #endregion Random

        #region WhereIf

        /// <summary>
        /// Executes an where if statement.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> where)
        {
            return condition ? source.Where(where) : source;
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Collections.Generic.IEnumerable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, int, bool> where)
        {
            return condition ? source.Where(where) : source;
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Collections.Generic.IEnumerable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <param name="whereElse">The else statement to be execute if the condition is not metd.</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> where, Func<T, bool> whereElse)
        {
            return condition ? source.Where(where) : source.Where(whereElse);
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Collections.Generic.IEnumerable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <param name="whereElse">The else statement to be execute if the condition is not metd.</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, int, bool> where, Func<T, int, bool> whereElse)
        {
            return condition ? source.Where(where) : source.Where(whereElse);
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Collections.Generic.IEnumerable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <param name="whereElse">The else statement to be execute if the condition is not metd.</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> where, Func<T, int, bool> whereElse)
        {
            return condition ? source.Where(where) : source.Where(whereElse);
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Collections.Generic.IEnumerable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <param name="whereElse">The else statement to be execute if the condition is not metd.</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, int, bool> where, Func<T, bool> whereElse)
        {
            return condition ? source.Where(where) : source.Where(whereElse);
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Linq.IQueryable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <returns><see cref="IQueryable{T}"/></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return condition ? source.Where(where) : source;
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Linq.IQueryable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <returns><see cref="IQueryable{T}"/></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, System.Linq.Expressions.Expression<Func<T, int, bool>> where)
        {
            return condition ? source.Where(where) : source;
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Linq.IQueryable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <param name="whereElse">The else statement to be execute if the condition is not metd.</param>
        /// <returns><see cref="IQueryable{T}"/></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, System.Linq.Expressions.Expression<Func<T, bool>> where, System.Linq.Expressions.Expression<Func<T, bool>> whereElse)
        {
            return condition ? source.Where(where) : source.Where(whereElse);
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Linq.IQueryable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <param name="whereElse">The else statement to be execute if the condition is not metd.</param>
        /// <returns><see cref="IQueryable{T}"/></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, System.Linq.Expressions.Expression<Func<T, int, bool>> where, System.Linq.Expressions.Expression<Func<T, int, bool>> whereElse)
        {
            return condition ? source.Where(where) : source.Where(whereElse);
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Linq.IQueryable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <param name="whereElse">The else statement to be execute if the condition is not metd.</param>
        /// <returns><see cref="IQueryable{T}"/></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, System.Linq.Expressions.Expression<Func<T, bool>> where, System.Linq.Expressions.Expression<Func<T, int, bool>> whereElse)
        {
            return condition ? source.Where(where) : source.Where(whereElse);
        }

        /// <summary>
        /// Execute a where if a condition is metd for an System.Linq.IQueryable of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under which the Where will be executed.</param>
        /// <param name="where">The where statement to be execute if the condition is metd.</param>
        /// <param name="whereElse">The else statement to be execute if the condition is not metd.</param>
        /// <returns><see cref="IQueryable{T}"/></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, System.Linq.Expressions.Expression<Func<T, int, bool>> where, System.Linq.Expressions.Expression<Func<T, bool>> whereElse)
        {
            return condition ? source.Where(where) : source.Where(whereElse);
        }

        #endregion WhereIf

        #region AnyIf

        /// <summary>
        /// Execute a linq Any statement if a condition is metd.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under whith the Any will be executed.</param>
        /// <param name="any">The any statement to be execute if the condition is metd.</param>
        /// <returns>true if any elements in the source sequence pass the test; otherwise, false.</returns>
        public static bool AnyIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> any)
        {
            return condition ? source.Any(any) : source.Any();
        }

        /// <summary>
        /// Execute a linq Any statement if a condition is metd.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under whith the Any will be executed.</param>
        /// <param name="any">The any statement to be execute if the condition is metd.</param>
        /// <param name="anyElse">The else any statement to be execute if the condition is not metd.</param>
        /// <returns>true if any elements in the source sequence pass the test; otherwise, false.</returns>
        public static bool AnyIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> any, Func<T, bool> anyElse)
        {
            return condition ? source.Any(any) : source.Any(anyElse);
        }

        /// <summary>
        /// Execute a linq Any statement if a condition is metd.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under whith the Any will be executed.</param>
        /// <param name="any">The any statement to be execute if the condition is metd.</param>
        /// <returns>true if any elements in the source sequence pass the test; otherwise, false.</returns>
        public static bool AnyIf<T>(this IQueryable<T> source, bool condition, System.Linq.Expressions.Expression<Func<T, bool>> any)
        {
            return condition ? source.Any(any) : source.Any();
        }

        /// <summary>
        /// Execute a linq Any statement if a condition is metd.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source"></param>
        /// <param name="condition">The condition under whith the Any will be executed.</param>
        /// <param name="any">The any statement to be execute if the condition is metd.</param>
        /// <param name="anyElse">The else any statement to be execute if the condition is not metd.</param>
        /// <returns>true if any elements in the source sequence pass the test; otherwise, false.</returns>
        public static bool AnyIf<T>(this IQueryable<T> source, bool condition, System.Linq.Expressions.Expression<Func<T, bool>> any, System.Linq.Expressions.Expression<Func<T, bool>> anyElse)
        {
            return condition ? source.Any(any) : source.Any(anyElse);
        }

        #endregion AnyIf
    }
}