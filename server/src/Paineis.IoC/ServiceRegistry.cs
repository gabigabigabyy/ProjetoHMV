using Paineis.Application.Interfaces;
using Paineis.Application.Services;
using StructureMap.Attributes;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.IoC
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            ForRequestedType<INucleoDeContasCirurgicasService>()
                .CacheBy(InstanceScope.PerRequest)
                .TheDefault.Is.OfConcreteType<NucleoDeContasCirurgicasService>();

            ForRequestedType<ICentralDeContaDePacientesService>()
                .CacheBy(InstanceScope.PerRequest)
                .TheDefault.Is.OfConcreteType<CentralDeContaDePacientesService>();
        }
    }
}
