using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Helpers
{
    public static class StringHelper
    {
        public static DateTime? ConvertToDateTimeOrNull(string item)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(item))
                {
                    return null;
                }
                return Convert.ToDateTime(item);
            }
            catch
            {
                return null;
            }
        }

        public static DateTime ConvertToDateTime(string item)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(item))
                {
                    return DateTime.MinValue;
                }
                return Convert.ToDateTime(item);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static T ConvertToEnum<T>(string value)
        {
            return (T)System.Enum.Parse(typeof(T), value, true);
        }
    }
}
