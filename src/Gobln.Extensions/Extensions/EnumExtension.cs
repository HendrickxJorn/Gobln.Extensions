using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional extensions for Enums
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Get the description of the System.Enum
        /// using the System.ComponentModel.DescriptionAttribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescriptionValue(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name == null)
            {
                return string.Empty;
            }

            var field = type.GetField(name);

            if (field == null)
            {
                return string.Empty;
            }

            var attr2 = field.GetAttribute<DescriptionAttribute>();

            return attr2 == null
                ? string.Empty
                : attr2.Description;
        }

        /// <summary>
        /// Get the description of the System.Enum
        /// using the System.ComponentModel.DataAnnotations.DisplayAttribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ////// Todo: Change to GetDisplayName()
        public static string GetDisplayName(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name == null)
            {
                return string.Empty;
            }

            var field = type.GetField(name);

            if (field == null)
            {
                return string.Empty;
            }

            var attr = field.GetAttribute<DisplayAttribute>();

            return attr == null
                ? string.Empty
                : attr.Name;
        }
    }
}