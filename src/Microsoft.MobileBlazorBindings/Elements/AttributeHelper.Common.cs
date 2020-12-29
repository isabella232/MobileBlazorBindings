﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Microsoft.MobileBlazorBindings.Elements
{
    public static partial class AttributeHelper
    {
        public static bool GetBool(object value, bool defaultValueIfNull = default)
        {
            return (value == null)
                ? defaultValueIfNull
                : (string.Equals((string)value, "1", StringComparison.Ordinal));
        }

        public static int GetInt(object value, int defaultValueIfNull = default)
        {
            return (value == null)
                ? defaultValueIfNull
                : int.Parse((string)value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Helper method to serialize <see cref="double" /> objects.
        /// </summary>
        public static string DoubleToString(double value)
        {
            return value.ToString("R", CultureInfo.InvariantCulture); // "R" --> Round-trip format specifier guarantees fidelity when parsing
        }

        /// <summary>
        /// Helper method to deserialize <see cref="double" /> objects.
        /// </summary>
        public static double StringToDouble(string doubleString, double defaultValueIfNull = default)
        {
            if (doubleString is null)
            {
                return defaultValueIfNull;
            }
            return double.Parse(doubleString, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Helper method to serialize <see cref="float" /> objects.
        /// </summary>
        public static string SingleToString(float value)
        {
            return value.ToString("R", CultureInfo.InvariantCulture); // "R" --> Round-trip format specifier guarantees fidelity when parsing
        }

        /// <summary>
        /// Helper method to deserialize <see cref="float" /> objects.
        /// </summary>
        public static float StringToSingle(string singleString, float defaultValueIfNull = default)
        {
            if (singleString is null)
            {
                return defaultValueIfNull;
            }
            return float.Parse(singleString, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Helper method to serialize <see cref="uint" /> objects.
        /// </summary>
        public static string UInt32ToString(uint value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Helper method to deserialize <see cref="uint" /> objects.
        /// </summary>
        public static uint StringToUInt32(string uintString, uint defaultValueIfNull = default)
        {
            if (uintString is null)
            {
                return defaultValueIfNull;
            }
            return uint.Parse(uintString, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Helper method to serialize <see cref="int" /> objects.
        /// </summary>
        public static string IntToString(int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Parses the attribute value as a space-separated string. Entries are trimmed and empty entries are removed.
        /// </summary>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        public static IList<string> GetStringList(object attributeValue)
        {
            return ((string)attributeValue)?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
        }

        public static AttributeValueHolder ObjectToDelegate(object item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            return AttributeValueHolderFactory.FromObject(item);
        }

        public static object DelegateToObject(object item, object defaultValueIfNull = default)
        {
            return AttributeValueHolderFactory.ToValue(item, defaultValueIfNull);
        }

        public static T DelegateToObject<T>(object item, object defaultValueIfNull = default)
        {
            return (T)AttributeValueHolderFactory.ToValue(item, defaultValueIfNull);
        }
    }
}
