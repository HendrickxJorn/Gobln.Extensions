namespace Gobln.Domain
{
    /// <summary>
    /// How to handle duplicated keys
    /// </summary>
    public enum AddRangesDuplicateInsertEnum
    {
        /// <summary>
        /// Ignore duplicated key
        /// </summary>
        Ignore = 0,

        /// <summary>
        /// Add this duplicated key
        /// </summary>
        Replace = 1
    }
}