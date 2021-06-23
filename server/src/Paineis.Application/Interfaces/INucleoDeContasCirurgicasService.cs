using Paineis.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface INucleoDeContasCirurgicasService
    {
        IEnumerable<PortletDTO> AvisosConferenciaTecnica();
        IEnumerable<AvisoCirurgiaDTO> DetalhesAvisosConferenciaTecnica();
    }
}
