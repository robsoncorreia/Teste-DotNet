using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace TESTE
{
    [DelimitedRecord(",")]
    class Cotacao
    {
        [DisplayName("Código da ação")]
        public int NegociacaoID { get; set; }
        [DisplayName("Data do pregão")]
        [FieldConverter(ConverterKind.Date, "dd-MM-yyyy")]
        public DateTime DataPregao { get; set; }
        [DisplayName("Preço de abertura")]
        public decimal PrecoAbertura { get; set; }
        [DisplayName("Preço de fechamento")]
        public decimal PrecoFechamento { get; set; }

    }
}
