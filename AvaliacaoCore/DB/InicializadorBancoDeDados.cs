using System.IO;

namespace AvaliacaoCore.DB
{
    public class InicializadorBancoDeDados
    {
        private IManipuladorBancoDeDados manipuladorBancoDeDados;
        
        public InicializadorBancoDeDados(IManipuladorBancoDeDados manipuladorBancoDeDados)
        {
            this.manipuladorBancoDeDados = manipuladorBancoDeDados;
        }

        public void Iniciar()
        {
            if(!File.Exists(Constantes.NomeArquivoBanco))
                manipuladorBancoDeDados.CriarNovo();
        }
    }
}