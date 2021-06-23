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
    public class NucleoDeContasCirurgicasController : ApiController
    {
        /// <summary>
        /// Avisos em conferência técnica (P.1058)
        /// </summary>
        [HttpGet, Route("api/nucleoDeContasCirurgicas/avisosConferenciaTecnica")]
        public Task<HttpResponseMessage> AvisosConferenciaTecnica()
        {
            try
            {
                INucleoDeContasCirurgicasService service = ObjectFactory.GetInstance<INucleoDeContasCirurgicasService>();
                IEnumerable<PortletDTO> lstAvisosConferencia = service.AvisosConferenciaTecnica();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstAvisosConferencia));
            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }

        [HttpGet, Route("api/nucleoDeContasCirurgicas/detalhesAvisosConferenciaTecnica")]
        public Task<HttpResponseMessage> DetalhesAvisosConferenciaTecnica()
        {
            try
            {
                INucleoDeContasCirurgicasService service = ObjectFactory.GetInstance<INucleoDeContasCirurgicasService>();
                IEnumerable<AvisoCirurgiaDTO> lstAvisoCirurgia = service.DetalhesAvisosConferenciaTecnica();
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, lstAvisoCirurgia));

            }
            catch (Exception error)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, error.Message));
            }
        }
    }
}
