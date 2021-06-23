using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTO
{
    public class DetalhesCirurgiasConfirmadasDTO
    {
        public int CodigoAtendimento { get; set; }
        public string TipoAtendimento { get; set; }
        public string Paciente { get; set; }
        public int AvisoCirurgia { get; set; }
        public string CentroCirurgico { get; set; }
        public DateTime DataAtendimento { get; set; }
        public DateTime DataCirurgia { get; set; }
        public DateTime DataAlta { get; set; }
        public string Convenio { get; set; }
        public int QuantidadeDiasFim { get; set; }
    }
}
