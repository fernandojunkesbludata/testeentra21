using AvaliacaoCore.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoCore.DB.Map
{
    public class CadastroMap : IDatabaseMap
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadastro>().HasKey(x => x.Id);
            modelBuilder.Entity<Cadastro>().Property(x => x.CPF).IsRequired();
            modelBuilder.Entity<Cadastro>().Property(x => x.RG).IsRequired(false);
            modelBuilder.Entity<Cadastro>().Property(x => x.DataNascimento).IsRequired();
            modelBuilder.Entity<Cadastro>().Property(x => x.HoraCadastro).IsRequired();
            modelBuilder.Entity<Cadastro>().Property(x => x.Nome).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Cadastro>().Property(x => x.UF).IsRequired().HasMaxLength(2);
            modelBuilder.Entity<Cadastro>().HasMany(x => x.Telefones);
            
        }
    }
}