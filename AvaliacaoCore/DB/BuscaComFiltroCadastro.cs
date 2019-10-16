using AvaliacaoCore.DB.Model;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoCore.DB
{
    public static class BuscaComFiltroCadastro
    {
        public static IBuscaComFiltro<Cadastro> NomeLike(this IBuscaComFiltro<Cadastro> that, string comparacao)
        {
            return that.Propriedade(x => EF.Functions.Like(x.Nome, "%" + comparacao + "%"));
        }
    }
}