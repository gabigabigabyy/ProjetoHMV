using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTO
{
    public class DetalhesContasEmProcessamentoDTO
    {
        public int Tipo { get; set; }
        public string UnidadeInternacao { get; set; }
        public int Atendimento { get; set; }
        public string Paciente { get; set; }
        public int Conta { get; set; }
        public int NroRetornos { get; set; }
        public int DiasLocalAtual { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime DataAlta { get; set; }
        public string QtdDiasFim { get; set; }
        public string Convenio { get; set; }
        public int CdConvenio { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public int Quantidade { get; set; }
        public string Local { get; set; }
        public string Hint { get; set; }
        public string AvisoCirurgia { get; set; }

    }
}
