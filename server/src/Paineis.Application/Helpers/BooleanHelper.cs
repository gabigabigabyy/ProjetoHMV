using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Helpers
{
    public static class BooleanHelper
    {
        public static string ConvertToStringS(bool item)
        {
            return item ? "S" : "";
        }
    }
}
