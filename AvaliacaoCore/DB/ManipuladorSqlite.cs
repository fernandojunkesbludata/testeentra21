
using AvaliacaoCore.DB.Map;
using AvaliacaoCore.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoCore.DB
{
    public class ManipuladorSqlite : DbContext, IManipuladorBancoDeDados
    {
        private DbSet<Cadastro> Cadastros { get; set; }

        public void CriarNovo()
        {
            Database.EnsureCreated();
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source="+ Constantes.NomeArquivoBanco);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new TelefoneMap().Map(modelBuilder);
            new CadastroMap().Map(modelBuilder);

        }

        public void AdicionarCadastro(Cadastro cadastro)
        {
            Cadastros.Add(cadastro);
            SaveChanges();
        }

        public IBuscaComFiltro<Cadastro> BuscarCadastrosCompletoOnde()
        {
            return new BuscaComFiltro<Cadastro>(Cadastros.Include(x => x.Telefones));
        }

        public IBuscaComFiltro<Cadastro> BuscarCadastrosOnde()
        {
            return new BuscaComFiltro<Cadastro>(Cadastros);
        }
        
    }
}