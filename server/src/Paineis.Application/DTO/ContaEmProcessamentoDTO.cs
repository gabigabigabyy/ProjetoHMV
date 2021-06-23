using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paineis.Application.DTO
{
    public class ContaEmProcessamentoDTO
    {
        public int Tipo { get; set; }
        public string Local { get; set; }
        public int CdLocal { get; set; }
        public decimal Valor { get; set; }
        public int Qtd { get; set; }
        public decimal MediaDias { get; set; }
        public string Hint { get; set; }
    }
}
