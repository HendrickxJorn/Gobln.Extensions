using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional extensions for <see cref="DirectoryInfo"/>
    /// </summary>
    public static class DirectoryInfoExtension
    {
        #region DirectorySize

        /// <summary>
        /// Get the size in bytes, of the current folder.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Size in bytes</returns>
        public static long DirectorySize(this DirectoryInfo source)
        {
            return source.DirectorySize(SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Get the size in bytes, of the current folder.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="searchOption">Specifies whether to search the current directory, or the current directory and all subdirectories.</param>
        /// <returns>Size in bytes</returns>
        public static long DirectorySize(this DirectoryInfo source, SearchOption searchOption)
        {
            return source
                .EnumerateFiles("*.*", searchOption)
                .Sum(c => c.Length);
        }

        /// <summary>
        /// Get the size in bytes, from all files with the given extensions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fileExtensions">File extensions</param>
        /// <returns>Size, in bytes</returns>
        public static long DirectorySize(this DirectoryInfo source, string[] fileExtensions)
        {
            return source.DirectorySize(fileExtensions, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Get the size, in bytes, from all files with the given extensions.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fileExtensions">File extensions</param>
        /// <param name="searchOption">Specifies whether to search the current directory, or the current directory and all subdirectories.</param>
        /// <returns>Size, in bytes</returns>
        public static long DirectorySize(this DirectoryInfo source, string[] fileExtensions, SearchOption searchOption)
        {
            return source
                .EnumerateFiles("*.*", searchOption)
                .Where(c => fileExtensions.Contains(c.Extension))
                .Sum(c => c.Length);
        }

        #endregion DirectorySize

        #region GetFileExtensions

        /// <summary>
        /// Get <seealso cref="IEnumerable{String}"/> of all avaible extensions from the current directory
        /// </summary>
        /// <param name="source"></param>
        /// <returns><seealso cref="IEnumerable{String}"/></returns>
        public static IEnumerable<string> GetFileExtensions(this DirectoryInfo source)
        {
            return source.GetFileExtensions(SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Get <seealso cref="IEnumerable{String}"/> of all avaible extensions from the current directory
        /// </summary>
        /// <param name="source"></param>
        /// <param name="searchOption">Specifies whether to search the current directory, or the current directory and all subdirectories.</param>
        /// <returns><seealso cref="IEnumerable{String}"/></returns>
        public static IEnumerable<string> GetFileExtensions(this DirectoryInfo source, SearchOption searchOption)
        {
            return source
                .EnumerateFiles("*.*", searchOption)
                .Select(c => c.Extension)
                .Distinct();
        }

        /// <summary>
        /// Get <seealso cref="IEnumerable{FileInfo}"/> by file extensions from the current directory
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fileExtensions">list of file extensions</param>
        /// <returns><seealso cref="IEnumerable{FileInfo}"/></returns>
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo source, string[] fileExtensions)
        {
            return source.GetFilesByExtensions(fileExtensions, SearchOption.TopDirectoryOnly);
        }

        /// <summary>
        /// Get <seealso cref="IEnumerable{FileInfo}"/> by file extensions from the current directory
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fileExtensions">list of file extensions</param>
        /// <param name="searchOption">Specifies whether to search the current directory, or the current directory and all subdirectories.</param>
        /// <returns><seealso cref="IEnumerable{FileInfo}"/></returns>
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo source, string[] fileExtensions, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var exten = new HashSet<string>(fileExtensions, StringComparer.OrdinalIgnoreCase);

            return source
                .EnumerateFiles("*.*", searchOption)
                .Where(c => exten.Contains(c.Extension));
        }

        #endregion GetFileExtensions

        /// <summary>
        /// Rename directory
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name">Name of new directory</param>
        public static void Rename(this DirectoryInfo source, string name)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (name.Length == 0)
            {
                throw new ArgumentException("The name is empty.", "name");
            }

            if (name.IndexOf(Path.DirectorySeparatorChar) >= 0 || name.IndexOf(Path.AltDirectorySeparatorChar) >= 0)
            {
                throw new ArgumentException("Can not rename. The name contains pathseparator charaters.", "name");
            }

            var path = Path.Combine(source.Parent.FullName, name);

            if (new FileInfo(path).Exists)
            {
                throw new ArgumentException("Can not rename. There already exist an directory with this name.", "name");
            }

            source.MoveTo(path);
        }
    }
}