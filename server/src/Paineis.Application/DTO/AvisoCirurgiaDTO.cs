using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTO
{
    public class AvisoCirurgiaDTO
    {
        public string TipoAtendimento { get; set; }
        public string NomePaciente { get; set; }
        public int IdConvenio { get; set; }
        public string Convenio { get; set; }
        public int AvisoCirurgia { get; set; }
        public string CentroCirurgico { get; set; }
        public DateTime DataAtendimento { get; set; }
        public DateTime DataCirurgia { get; set; }
        public DateTime DataAlta { get; set; }
        public string NomeUsuario { get; set; }
        public int Retornos { get; set; }
        public int DiasFim { get; set; }
        public int DiasLocalAtual { get; set; }
        public string PorteCirurgico { get; set; }
        public string CirurgiaoPrincipal { get; set; }
    }
}
