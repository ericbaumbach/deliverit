using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contas_a_pagar.Models
{
    public class Conta
    {
        [Key]
        public long ContaId { get; set; }
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal? ValorCorrigido { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public int? QuantidadeDiasAtraso { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Juros { get; set; }
    }
}
