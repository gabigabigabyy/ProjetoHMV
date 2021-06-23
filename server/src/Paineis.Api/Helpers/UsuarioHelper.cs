using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace HMV.PortalMedicoServices.Api.Helpers
{
    public static class UsuarioHelper
    {
        public static int IdUsuario
        {
            get
            {
                ClaimsPrincipal claims = Thread.CurrentPrincipal as ClaimsPrincipal;
                string id = claims.FindFirst(x => x.Type == "usuario_id").Value.ToString();
                return Convert.ToInt32(id);
            }
        }
    }
}