using AvaliacaoCore.DB.Model;

namespace AvaliacaoCore.DB
{
    public interface IManipuladorBancoDeDados
    {
        void CriarNovo();
        void AdicionarCadastro(Cadastro cadastro);
        IBuscaComFiltro<Cadastro> BuscarCadastrosOnde();
    }
}