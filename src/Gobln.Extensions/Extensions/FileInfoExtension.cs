using System;
using System.IO;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional extensions for FileInfo
    /// </summary>
    public static class FileInfoExtension
    {
        /// <summary>
        /// Check if the file is ready and locked.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>True if the file is ready, else false</returns>
        public static bool IsReady(this FileInfo source)
        {
            if (source == null || string.IsNullOrWhiteSpace(source.Name))
            {
                throw new ArgumentNullException("source");
            }

            try
            {
                using (var stream = source.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return stream.Length > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get the name of the file without the extension.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Get the name of the file without the extension.</returns>
        public static string NameWithoutExtension(this FileInfo source)
        {
            if (source == null || string.IsNullOrWhiteSpace(source.Name))
            {
                throw new ArgumentNullException("source");
            }

            return Path.GetFileNameWithoutExtension(source.Name);
        }

        /// <summary>
        /// Rename directory
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name">New name of fileinfo</param>
        public static void Rename(this FileInfo source, string name)
        {
            if (source == null || string.IsNullOrWhiteSpace(source.Name))
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

            var path = Path.Combine(source.DirectoryName, name);

            //check if new name already exists
            if (new FileInfo(path).Exists)
            {
                throw new ArgumentException("Can not rename. There already exist an file with this name.", "name");
            }

            source.MoveTo(path);
        }
    }
}