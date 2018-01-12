using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace FadingUtility.Helpers
{
    /// <summary>
    /// Enumeration utilities
    /// </summary>
    public class EnumUtil
    {
        // returns a collection of enum integer value & description pairs
        public static IEnumerable<object> GetEnum<T>()
        {
            var type = typeof(T);
            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type);

            List<object> descriptions = new List<object>();
            foreach (object value in values)
            {
                MemberInfo[] memInfo = type.GetMember(value.ToString());
                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attrs != null && attrs.Length > 0)
                        descriptions.Add(((DescriptionAttribute)attrs[0]).Description);
                }
            }
            var pairs =
                Enumerable.Range(0, values.Length)
                .Select(i => new
                {
                    Name = descriptions[i],
                    Value = (int)Convert.ChangeType(values.GetValue(i), typeof(int)) // typecast the enum to an int
                })
                .OrderBy(pair => pair.Value);
            return pairs;
        }

        // returns a collection of enum integer value & name pairs
        public static IEnumerable<object> GetEnumNameValuePairs<T>()
        {
            var type = typeof(T);
            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type);

            var pairs =
                Enumerable.Range(0, values.Length)
                .Select(i => new
                {
                    Name = names[i],
                    Value = (int)Convert.ChangeType(values.GetValue(i), typeof(int)) // typecast the enum to an int
                })
                .OrderBy(pair => pair.Value);
            return pairs;
        }

        /// <summary>
        /// This is a special case for the 3GPPMode type because it needs to convert the enum names directly into decimal strings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<object> GetEnumNameValuePairs3GPP<T>()
        {
            var type = typeof(T);
            var names = Enum.GetNames(type);
            var values = Enum.GetValues(type);
            
            // Convert the names to the decimal strings
            Dictionary<string, string> nameValuePairs = new Dictionary<string, string>();
            foreach(string enumName in names)
            {
                var memInfo = type.GetMember(enumName.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                nameValuePairs.Add(enumName, ((DescriptionAttribute)attributes[0]).Description);
            }

            var pairs = 
                Enumerable.Range(0, values.Length).
                Select(i => new
                  {
                      Name = nameValuePairs[names[i]],
                      Value = (int)Convert.ChangeType(values.GetValue(i), typeof(int))
                  })
                  .OrderBy(pair => pair.Value);

            return pairs;
        }
    }
}
