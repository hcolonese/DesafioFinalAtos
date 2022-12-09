using APIatosDesafioFinal.DataModels;

namespace APIatosDesafioFinal.DTO
{
    public class CreateComissaoDTO
    {
        public string Relatorio { get; set; } = "Teste";

        public string NotaFiscal { get; set; } = "Teste";

        public double Valor { get; set; } = 0;

        public DateTime DataRebimento { get; set; }

        public int VendaId { get; set; } = 1;
    }
}
