using Paineis.Application.DTO;
using Paineis.Application.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Paineis.Api.Controllers
{
    public class CentralDeContasDePacientesController : ApiController
    {
        /// <summary>
        /// Contas em Processamento Central de Contas (P.1050)
        /// </summary>
        [HttpGet, Route("api/centralDeContasDePacientes/contasEmProcessamento")]
        public Task<HttpResponseMessage> ContasEmProcessamento()
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<ContaEmProcessamentoDTO> lstContasEmProcessameneto = service.GetContasEmProcessamento();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstContasEmProcessameneto));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Detalhes da conta
        /// </summary>
        /// <param name="nomeDaConta">Nome da conta</param>
        [HttpGet, Route("api/centralDeContasDePacientes/detalhesContasEmProcessamento/{nomeDaConta}")]
        public Task<HttpResponseMessage> DetalhesContasEmProcessamento(string nomeDaConta)
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<DetalhesContasEmProcessamentoDTO> lstContasEmProcessamento = service.GetDetalhesContasEmProcessamento(nomeDaConta);
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstContasEmProcessamento));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Demais Origens: Posição das Contas (Mov Doc) (P.1052)
        /// </summary>
        [HttpGet, Route("api/centralDeContasDePacientes/demaisOrigens")]
        public Task<HttpResponseMessage> DemaisOrigens()
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<ContaEmProcessamentoDTO> lstDemaisOrigens = service.GetDemaisOrigens();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstDemaisOrigens));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Detalhes contas demais origens
        /// </summary>
        /// <param name="nomeDaConta">Nome da conta</param>
        [HttpGet, Route("api/centralDeContasDePacientes/detalhesDemaisOrigens/{nomeDaConta}")]
        public Task<HttpResponseMessage> DetalhesContasDemaisOrigens(string nomeDaConta)
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<DetalhesContasEmProcessamentoDTO> lstContasDemaisOrigens = service.GetDetalhesContasDemaisOrigens(nomeDaConta);
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstContasDemaisOrigens));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Total de Contas Abertas (P.1037)
        /// </summary>
        [HttpGet, Route("api/centralDeContasDePacientes/totalDeContas")]
        public Task<HttpResponseMessage> TotalDeContas()
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<ContaEmProcessamentoDTO> total = service.GetTotalDeContas();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, total));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Detalhes de todas as contas
        /// </summary>
        [HttpGet, Route("api/centralDeContasDePacientes/detalhesTotalContasProcessamento")]
        public Task<HttpResponseMessage> DetalhesTotalContasProcessamento()
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<DetalhesContasEmProcessamentoDTO> lstTotal = service.GetDetalhesTotalContasProcessamento();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstTotal));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Detalhes total demais origens
        /// </summary>
        [HttpGet, Route("api/centralDeContasDePacientes/detalhesTotalDemaisOrigens")]
        public Task<HttpResponseMessage> DetalhesTotalDemaisOrigens()
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<DetalhesContasEmProcessamentoDTO> lstContasDemaisOrigens = service.GetDetalhesTotalDemaisOrigens();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstContasDemaisOrigens));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Detalhes total contas processamento + demais origens
        /// </summary>
        [HttpGet, Route("api/centralDeContasDePacientes/detalhesTotal")]
        public Task<HttpResponseMessage> DetalhesTotal()
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<DetalhesContasEmProcessamentoDTO> lstTotal = service.GetDetalhesTotal();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstTotal));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Cirurgias Confirmadas (P.1056)
        /// </summary>
        [HttpGet, Route("api/centralDeContasDePacientes/cirurgiasConfirmadas")]
        public Task<HttpResponseMessage> CirurgiasConfirmadas()
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<PortletDTO> lstCirurgiasConfirmadas = service.GetCirurgiasConfirmadas();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstCirurgiasConfirmadas));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Detalhes Cirurgias Confirmadas (P.1057)
        /// </summary>
        /// <param name="codigoCentroCirurgico">Código do centro cirurgico</param>
        [HttpGet, Route("api/centralDeContasDePacientes/detalhamentoCirurgiasConfirmadas/{codigoCentroCirurgico}")]
        public Task<HttpResponseMessage> DetalhesCirurgiasConfirmadas(int codigoCentroCirurgico)
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<DetalhesCirurgiasConfirmadasDTO> lstCirurgiasConfirmadas = service.GetDetalhesCirurgiasConfirmadas(codigoCentroCirurgico);
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstCirurgiasConfirmadas));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        /// <summary>
        /// Avisos em Autorizacoes - Pendencias de Compras (P.1066)
        /// </summary>
        [HttpGet, Route("api/centralDeContasDePacientes/avisosEmAutorizacoesPendenciasDeCompras")]
        public Task<HttpResponseMessage> AvisosEmAutorizacoesPendenciasDeCompras()
        {
            try
            {
                ICentralDeContaDePacientesService service = ObjectFactory.GetInstance<ICentralDeContaDePacientesService>();
                IEnumerable<PortletDTO> lstAvisosEmAutorizacoesPendenciasDeCompras = service.GetAvisosEmAutorizacoesPendenciasDeCompras();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstAvisosEmAutorizacoesPendenciasDeCompras));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }
    }
}
