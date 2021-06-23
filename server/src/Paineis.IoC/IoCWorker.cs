using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.IoC
{
    public static class IoCWorker
    {
        public static void ConfigureWEB()
        {
            HMV.Core.IoC.IoCWorker.ConfigureWIN();
            ObjectFactory.Configure(i =>
            {
                i.AddRegistry<ServiceRegistry>();
            });
        }
    }
}
