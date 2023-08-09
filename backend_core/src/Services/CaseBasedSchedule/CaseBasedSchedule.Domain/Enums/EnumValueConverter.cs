using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CaseBasedSchedule.Domain.Enums
{
    public class EnumValueConverter
    {
        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            var thisType = GetEnumTypeByValue<T>(str);
            //return Enum.TryParse(str, true, out T val) ? val : default;
            return (T)thisType;
        }

        public static T GetEnumValue<T>(int intValue) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }

            return (T)Enum.ToObject(enumType, intValue);
        }
        private static T GetEnumTypeByValue<T>(string value)
        {
            var array = typeof(T).GetEnumValues();
            var result = Array.Find<T>((T[])array, sp => sp.ToString() == value);
            return result;

        }
    }
}
