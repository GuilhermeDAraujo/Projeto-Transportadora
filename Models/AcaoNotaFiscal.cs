using System.ComponentModel.DataAnnotations;
using Projeto_Transportadora.Enums;

namespace Projeto_Transportadora.Models
{
    public class AcaoNotaFiscal
    {
        public int id {get;set;}
        [Required(ErrorMessage = "Obrigatório informar a ação da Nota Fiscal")]
        public TipoAcao TipoAcao {get;set;}

        [Required(ErrorMessage = "Informe a data da ação")]
        [DataType(DataType.Date)]
        public DateTime DataDaAcao {get;set;}

        [Required(ErrorMessage = "Descreva o motivo da devolução da nota")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres")]
        public string? Descriacao {get;set;}

        public int NotaFiscalId {get;set;}
        public NotaFiscal NotaFiscal{get;set;}
    }
}