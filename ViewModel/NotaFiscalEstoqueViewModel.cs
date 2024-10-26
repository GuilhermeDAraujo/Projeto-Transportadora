using System.ComponentModel.DataAnnotations;
using Projeto_Transportadora.Models;

namespace Projeto_Transportadora.ViewModel
{
    public class NotaFiscalEstoqueViewModel
    {
        public int NumeroNotaFiscal { get; set; }

        [Required(ErrorMessage = "Informe o nome do Cliente")]
        [StringLength(50, MinimumLength = 5)]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Informe o endereço do Cliente")]
        [StringLength(50, MinimumLength = 5)]
        public string EnderecoFaturado { get; set; }

        [Required(ErrorMessage = "Informe a data de faturamento da Nota Fiscal")]
        [DataType(DataType.Date)]
        public DateTime DataDoFaturamento { get; set; }

        [Required(ErrorMessage = "Informe o número da carga da Nota Fiscal")]
        public int NumeroDaCarga { get; set; }
        public int CaminhaoId { get; set; }


        [Required(ErrorMessage = "Informe a data de entrada no estoque")]
        [DataType(DataType.Date)]
        public DateTime DataDaEntrada { get; set; }
        public NotaFiscal NotaFiscal {get;set;}

    }
}