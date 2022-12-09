using System.Text.Json.Serialization;

namespace APIatosDesafioFinal.DataModels
{
    public class Comissao
    {
        public int Id { get; set; }

        public string Relatorio { get; set; } = null!;

        public string NotaFiscal { get; set; } = null!;

        public double Valor { get; set; }

        public DateTime DataRebimento { get; set; }
        [JsonIgnore]
        public  Venda Venda { get; set; }
        public int VendaId { get; set; }
    }
}
