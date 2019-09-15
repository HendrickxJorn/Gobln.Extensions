using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional extensions
    /// </summary>
    public static class MinscExtension
    {
        #region UriBuilder

        /// <summary>
        /// Add path or file to the end of <see cref="UriBuilder"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="path">Path or file to add</param>
        /// <returns><see cref="UriBuilder"/> with added path or file</returns>
        public static UriBuilder AddPath(this UriBuilder source, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return source;
            }

            if (!source.Path.EndsWith("/"))
            {
                source.Path += "/";
            }

            if (path.StartsWith("/"))
            {
                path = path.TrimStart('/');
            }

            source.Path += Uri.EscapeDataString(path);

            return source;
        }

        #endregion UriBuilder

        #region Attribute

        /// <summary>
        /// Get the first attribute from <see cref="Type"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>The first attribute or empty</returns>
        public static T GetAttribute<T>(this Type source, bool inherit = false) where T : Attribute
        {
            return source.GetCustomAttributes(typeof(T), inherit).FirstOrDefault() as T;
        }

        /// <summary>
        /// Get the first attribute from <see cref="PropertyInfo"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>The first attribute or empty</returns>
        public static T GetAttribute<T>(this PropertyInfo source, bool inherit = false) where T : Attribute
        {
            return source.GetCustomAttributes(typeof(T), inherit).FirstOrDefault() as T;
        }

        /// <summary>
        /// Get the first attribute from <see cref="FieldInfo"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>The first attribute or empty</returns>
        public static T GetAttribute<T>(this FieldInfo source, bool inherit = false) where T : Attribute
        {
            return source.GetCustomAttributes(typeof(T), inherit).FirstOrDefault() as T;
        }

        /// <summary>
        /// Get the first attribute from <see cref="MemberInfo"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>The first attribute or empty</returns>
        public static T GetAttribute<T>(this MemberInfo source, bool inherit = false) where T : Attribute
        {
            return source.GetCustomAttributes(typeof(T), inherit).FirstOrDefault() as T;
        }

        /// <summary>
        /// Check if an attribute exist for <see cref="Type"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <returns>Exist : true else false</returns>
        public static bool HasAttribute<T>(this Type source) where T : Attribute
        {
            return Attribute.IsDefined(source, typeof(T));
        }

        /// <summary>
        /// Check if an attribute exist for <see cref="Type"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>Exist : true else false</returns>
        public static bool HasAttribute<T>(this Type source, bool inherit) where T : Attribute
        {
            return Attribute.IsDefined(source, typeof(T), inherit);
        }

        /// <summary>
        /// Check if an attribute exist for <see cref="PropertyInfo"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <returns>Exist : true else false</returns>
        public static bool HasAttribute<T>(this PropertyInfo source) where T : Attribute
        {
            return Attribute.IsDefined(source, typeof(T));
        }

        /// <summary>
        /// Check if an attribute exist for <see cref="PropertyInfo"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>Exist : true else false</returns>
        public static bool HasAttribute<T>(this PropertyInfo source, bool inherit) where T : Attribute
        {
            return Attribute.IsDefined(source, typeof(T), inherit);
        }

        /// <summary>
        /// Check if an attribute exist for <see cref="FieldInfo"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <returns>Exist : true else false</returns>
        public static bool HasAttribute<T>(this FieldInfo source) where T : Attribute
        {
            return Attribute.IsDefined(source, typeof(T));
        }

        /// <summary>
        /// Check if an attribute exist for <see cref="FieldInfo"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>Exist : true else false</returns>
        public static bool HasAttribute<T>(this FieldInfo source, bool inherit) where T : Attribute
        {
            return Attribute.IsDefined(source, typeof(T), inherit);
        }

        /// <summary>
        /// Check if an attribute exist for <see cref="MemberInfo"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <returns>Exist : true else false</returns>
        public static bool HasAttribute<T>(this MemberInfo source) where T : Attribute
        {
            return Attribute.IsDefined(source, typeof(T));
        }

        /// <summary>
        /// Check if an attribute exist for <see cref="MemberInfo"/>
        /// </summary>
        /// <typeparam name="T">The attribute to get</typeparam>
        /// <param name="source"></param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>Exist : true else false</returns>
        public static bool HasAttribute<T>(this MemberInfo source, bool inherit) where T : Attribute
        {
            return Attribute.IsDefined(source, typeof(T), inherit);
        }

        #endregion Attribute

        #region Type

        /// <summary>
        /// Return the underlying <see cref="Type"/> if the type is Nullable otherwise return the <see cref="Type"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns><see cref="Type"/> or underlying type</returns>
        public static Type GetCoreType(this Type type)
        {
            return type != null && type.IsNullableType() && type.IsValueType
                    ? Nullable.GetUnderlyingType(type)
                    : type;
        }

        /// <summary>
        /// Determine if specified <see cref="Type"/> is nullable
        /// </summary>
        /// <param name="type"></param>
        /// <returns>True if Nullable, false if not Nullable</returns>
        public static bool IsNullableType(this Type type)
        {
            return !type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        #endregion Type

        #region StringBuilder

        /// <summary>
        /// Appends a copy of the specified format string followed by the default line terminator to the end of the current <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns></returns>
        public static StringBuilder AppendLine(this StringBuilder source, string format, params object[] args)
        {
            source.AppendLine(string.Format(format, args));
            return source;
        }

        /// <summary>
        /// Appends a copy of the specified format string followed by the default line terminator to the end of the <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns></returns>
        public static StringBuilder AppendLine(this StringBuilder source, IFormatProvider provider, string format, params object[] args)
        {
            source.AppendLine(string.Format(provider, format, args));
            return source;
        }

        /// <summary>
        /// Appends an number of empty lines to the StringBuilder
        /// </summary>
        /// <param name="source"></param>
        /// <param name="lines">Amount of line to add. May may not be a negative value.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="lines"/> may not be a negative value.</exception>
        public static StringBuilder AppendLine(this StringBuilder source, int lines)
        {
            if (lines < 0)
            {
                throw new ArgumentException("May may not be a negative value.", "lines");
            }

            if (lines > 0)
            {
                for (var i = 0; i < lines; i++)
                {
                    source.AppendLine();
                }
            }

            return source;
        }

        /// <summary>
        /// Append multiple lines to the StringBuilder
        /// </summary>
        /// <param name="source"></param>
        /// <param name="lines">Lines to add.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="lines"/> may not be null.</exception>
        public static StringBuilder AppendLine(this StringBuilder source, string[] lines)
        {
            if (lines == null)
            {
                throw new ArgumentNullException("lines");
            }

            foreach (var item in lines)
            {
                source.AppendLine(item);
            }

            return source;
        }

        /// <summary>
        /// Replaces all occurrences of a specified characters in this instance with another specified character.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldChars">The characters to replace.</param>
        /// <param name="newChar">The character that replaces oldChars.</param>
        /// <returns>A reference to this instance with oldChars replaced by newChar.</returns>
        public static StringBuilder Replace(this StringBuilder value, char[] oldChars, char newChar)
        {
            foreach (var oldChar in oldChars)
            {
                value = value.Replace(oldChar, newChar);
            }

            return value;
        }

        /// <summary>
        /// Replaces all occurrences of a specified text in this instance with another specified text.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldValues">The text to replace.</param>
        /// <param name="newValue">The text that replaces oldValue, or null.</param>
        /// <returns>A reference to this instance with all instances of oldValues replaced by newValue.</returns>
        /// <exception cref="ArgumentNullException">OldValues is null or contains null.</exception>
        /// <exception cref="ArgumentException">The length any of the oldValues is zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="StringBuilder.MaxCapacity"/>.</exception>
        public static StringBuilder Replace(this StringBuilder value, string[] oldValues, string newValue)
        {
            if (oldValues.Any(c => c == null))
            {
                throw new ArgumentNullException("oldValues");
            }

            if (oldValues.Any(c => c == string.Empty))
            {
                throw new ArgumentException("oldValues");
            }

            foreach (var oldValue in oldValues)
            {
                value = value.Replace(oldValue, newValue);
            }

            return value;
        }

        #endregion StringBuilder
    }
}