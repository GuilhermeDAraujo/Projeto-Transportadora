using System.ComponentModel.DataAnnotations;

namespace Projeto_Transportadora.Models
{
    public class NotaFiscal
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Informe o número da Nota Fiscal")]
        public int NumeroNotaFiscal { get; set; }

        [Required(ErrorMessage = "Informe o nome do Cliente")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "Informe o endereço do Cliente")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} deve conter entre {2} e {1} caracteres")]
        public string EnderecoFaturado { get; set; }

        [Required(ErrorMessage = "Informe a data de faturamento da Nota Fiscal")]
        [DataType(DataType.Date)]
        public DateTime DataDoFaturamento { get; set; }

        [Required(ErrorMessage = "Informe o número da carga da Nota Fiscal")]
        [Range(2,3)]
        public int NumeroDaCarga { get; set; }

        public int CaminhaoId { get; set; }
        public Caminhao Caminhao { get; set; }

        public ICollection<AcaoNotaFiscal> Acoes { get; set; } = new List<AcaoNotaFiscal>();
    }
}