using HMV.Paineis.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMV.Paineis.Application.Interfaces
{
    public interface IAvisosDeCirurgiaEmConferenciaTecnicaService
    {
        IEnumerable<PortletDTO> CirurgiasConfirmadas();
        IEnumerable<PortletDTO> ConferenciaTecnica();
        IEnumerable<PortletDTO> PendenciasDeCompras();
        IEnumerable<PortletDTO> ConferenciaAdministrativa();
        IEnumerable<PortletDTO> PendenciasCentroCirurgico();
        IEnumerable<PortletDTO> PendenciasAngiografia();

    }
}
