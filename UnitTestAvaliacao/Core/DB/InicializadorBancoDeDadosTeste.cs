using System.IO;
using System.Linq;
using AvaliacaoCore.DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTestAvaliacao.Core.DB
{
    [TestClass]
    public class InicializadorBancoDeDadosTeste
    {
        private IManipuladorBancoDeDados manipuladorBancoDeDados;

        [TestInitialize]
        public void Setup()
        {
            manipuladorBancoDeDados = Substitute.For<IManipuladorBancoDeDados>();
        }

        [TestMethod]
        public void dado_que_nao_existe_um_banco_de_dados_na_raiz_deve_criar()
        {
            var inicializador = new InicializadorBancoDeDados(manipuladorBancoDeDados);
            inicializador.Iniciar();

            manipuladorBancoDeDados.Received().CriarNovo();
        }

        [TestMethod]
        public void dado_que_exista_um_banco_de_dados_na_raiz_nao_deve_criar_novo()
        {
            File.Create(Constantes.NomeArquivoBanco).Dispose();
            var inicializador = new InicializadorBancoDeDados(manipuladorBancoDeDados);
            inicializador.Iniciar();

            manipuladorBancoDeDados.DidNotReceive().CriarNovo();
        }

        [TestCleanup]
        public void Teardown()
        {
            Directory.GetFiles(".").Select(f => new FileInfo(f)).FirstOrDefault(f => f.Name.Equals(Constantes.NomeArquivoBanco))?.Delete();
        }
    }
}