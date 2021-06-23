using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Paineis.Application.Helpers
{
    public static class UsuarioHelper
    {
        public static string IdUsuario
        {
            get
            {
                ClaimsPrincipal claims = Thread.CurrentPrincipal as ClaimsPrincipal;
                string id = claims.FindFirst(x => x.Type == "usuario_id").Value.ToString();
                return id;
            }
        }
    }
}
