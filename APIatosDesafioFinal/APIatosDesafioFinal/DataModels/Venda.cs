namespace APIatosDesafioFinal.DataModels
{
    public class Venda
    {
        public int Id { get; set; }

        public DateTime DataVenda { get; set; }

        public string Operadora { get; set; } = null!;

        public string Cliente { get; set; } = null!;

        public string Apelido { get; set; } = null!;

        public string Tipo { get; set; } = null!;

        public double ValorContrato { get; set; }

        public double Comissao { get; set; }

        public int Parcela { get; set; }

        public List<Comissao>? comissoes { get; set; }
    }
}
