using System.ComponentModel.DataAnnotations;

namespace Projeto_Transportadora.Models
{
    public class Estoque
    {
        public int id {get;set;}
        [Required(ErrorMessage = "Informe a data de entrada da Nota Fiscal")]
        [DataType(DataType.Date)]
        public DateTime DataDaEntrada {get;set;}

        public int NotaFiscalId {get;set;}
        public NotaFiscal NotaFiscal {get;set;}
    }
}