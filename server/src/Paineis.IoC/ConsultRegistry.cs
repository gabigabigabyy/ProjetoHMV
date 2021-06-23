using StructureMap.Attributes;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMV.PortalMedicoServices.IoC
{
    public class ConsultRegistry : Registry
    {
        public ConsultRegistry()
        {
            //ForRequestedType<IConsult>()
            //    .CacheBy(InstanceScope.PerRequest)
            //    .TheDefault.Is.OfConcreteType<Consult>();
        }
    }
}
