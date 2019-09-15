using System.Linq;

namespace Gobln.Extensions.Internals
{
    internal class Levenshtein
    {
        /// <summary>
        /// Return number of steps needed to transform source to target
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>Levenshtein distance</returns>
        internal int LevenshteinDistance(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
            {
                return string.IsNullOrEmpty(target)
                    ? 0
                    : target.Length;
            }

            if (string.IsNullOrEmpty(target))
            {
                return string.IsNullOrEmpty(source)
                    ? 0
                    : source.Length;
            }

            var sourceLen = source.Length;
            var targetLen = target.Length;

            var distance = new int[sourceLen + 1, targetLen + 1];

            for (var i = 0; i <= sourceLen; distance[i, 0] = i++) ;
            for (var j = 0; j <= targetLen; distance[0, j] = j++) ;

            for (var i = 1; i <= sourceLen; i++)
            {
                for (var j = 1; j <= targetLen; j++)
                {
                    var cost = target[j - 1] == source[i - 1]
                        ? 0
                        : 1;

                    distance[i, j] = new[]{ distance[i - 1, j] + 1,
                                            distance[i, j - 1] + 1,
                                            distance[i - 1, j - 1] + cost}.Min();
                }
            }

            return distance[sourceLen, targetLen];
        }
    }
}