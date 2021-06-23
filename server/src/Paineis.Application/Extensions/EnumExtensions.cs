using HMV.Core.Framework.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescriptionAttribute<T>(string value)
        {
            string description = string.Empty;

            if (String.IsNullOrWhiteSpace(value))
            {
                return description;
            }

            var type = typeof(T);
            var memInfo = type.GetMember(value);
            DescriptionAttribute[] descriptionAttribute = (DescriptionAttribute[])memInfo[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttribute != null && descriptionAttribute.Length > 0)
            {
                description = descriptionAttribute[0].Description;
            }

            return description;
        }

        public static string GetCustomDisplayAttribute<T>(string value)
        {
            string description = string.Empty;

            if (String.IsNullOrWhiteSpace(value))
            {
                return description;
            }

            var type = typeof(T);
            var memInfo = type.GetMember(value);
            CustomDisplay[] descriptionAttribute = (CustomDisplay[])memInfo[0]
                .GetCustomAttributes(typeof(CustomDisplay), false);

            if (descriptionAttribute != null && descriptionAttribute.Length > 0)
            {
                description = descriptionAttribute[0].ToString();
            }

            return description;
        }
    }
}
