using System;
using System.Collections.Generic;

namespace APIdesafioFinal.DataModels;

public partial class Comissao
{
    public int Id { get; set; }

    public string Relatorio { get; set; } = null!;

    public string NotaFiscal { get; set; } = null!;

    public double Valor { get; set; }

    public DateTime DataRebimento { get; set; }

    public int? FkVenda { get; set; }

    public virtual Venda? FkVendaNavigation { get; set; }
}
