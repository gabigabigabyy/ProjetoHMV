using HMV.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMV.PortalMedicoServices.Api.AutoMapper
{
    public static class CustomMappingUF
    {
        public static UF GetUFPorCidade(Cidade cidade)
        {
            return cidade != null ? cidade.Estado : null;
        }
    }
}