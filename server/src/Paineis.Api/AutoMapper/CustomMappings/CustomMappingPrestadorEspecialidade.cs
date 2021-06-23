using HMV.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMV.PortalMedicoServices.Api.AutoMapper
{
    public static class CustomMappingPrestadorEspecialidade
    {
        public static PrestadorEspecialidade GetEspecialidadesSecundariasNumeroDois(IList<PrestadorEspecialidade> listaPrestadorEspecialidade)
        {
            return listaPrestadorEspecialidade.Count > 1 ? listaPrestadorEspecialidade[1] : null;
        }
    }
}