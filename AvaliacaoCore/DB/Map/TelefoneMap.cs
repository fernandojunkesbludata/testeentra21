using AvaliacaoCore.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoCore.DB.Map
{
    public class TelefoneMap : IDatabaseMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telefone>().HasKey(x => x.Id);
            modelBuilder.Entity<Telefone>().Property(x => x.DDD).IsRequired();
            modelBuilder.Entity<Telefone>().Property(x => x.Numero).IsRequired();
        }
    }
}