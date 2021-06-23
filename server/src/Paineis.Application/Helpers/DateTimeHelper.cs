using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Helpers
{
    public static class DateTimeHelper
    {
        public static string ConvertToString(DateTime data)
        {
            string dataRetorno = string.Format("{0:dd/MM/yyyy}", data);
            return dataRetorno.Equals("01/01/0001") ? null : dataRetorno;
        }

        public static string ConvertToString(DateTime? data)
        {
            return string.Format("{0:dd/MM/yyyy}", data);
        }
    }
}
