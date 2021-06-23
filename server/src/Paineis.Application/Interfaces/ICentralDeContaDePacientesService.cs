using Paineis.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.Interfaces
{
    public interface ICentralDeContaDePacientesService
    {
        IList<ContaEmProcessamentoDTO> GetContasEmProcessamento();
        IEnumerable<DetalhesContasEmProcessamentoDTO> GetDetalhesContasEmProcessamento(string nomeDaConta);
        IList<ContaEmProcessamentoDTO> GetDemaisOrigens();
        IEnumerable<DetalhesContasEmProcessamentoDTO> GetDetalhesContasDemaisOrigens(string nomeDaConta);
        IEnumerable<ContaEmProcessamentoDTO> GetTotalDeContas();
        List<DetalhesContasEmProcessamentoDTO> GetDetalhesTotalContasProcessamento();
        List<DetalhesContasEmProcessamentoDTO> GetDetalhesTotalDemaisOrigens();
        List<DetalhesContasEmProcessamentoDTO> GetDetalhesTotal();
        IList<PortletDTO> GetCirurgiasConfirmadas();
        IEnumerable<DetalhesCirurgiasConfirmadasDTO> GetDetalhesCirurgiasConfirmadas(int codigoCentroCirurgico);
        IList<PortletDTO> GetAvisosEmAutorizacoesPendenciasDeCompras();
    }
}
