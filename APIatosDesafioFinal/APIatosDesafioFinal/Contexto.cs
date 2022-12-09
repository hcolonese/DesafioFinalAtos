using APIatosDesafioFinal.DataModels;
using Microsoft.EntityFrameworkCore;

namespace APIatosDesafioFinal
{
    public class Contexto :DbContext
    {
        public Contexto()
        {
        }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public  DbSet<Comissao> Comissao { get; set; }

        public  DbSet<Venda> Venda { get; set; }
    }
}
