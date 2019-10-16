using AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAvaliacao.Core.RegraDeNegocio.Validacoes.Cadastro
{
    [TestClass]
    public class ValidadorNomeTeste
    {
        [TestMethod]
        public void dado_um_cadastro_sem_nome_deve_ser_invalido()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            var validador = new ValidadorNome();
            var resultado = validador.Validar(cadastro);

            Assert.IsFalse(resultado.Valido);
            StringAssert.Contains(resultado.Mensagem, "Nome Completo");
        }

        [TestMethod]
        public void dado_um_cadastro_com_apenas_um_nome_deve_ser_invalido()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.Nome = "Fulano";
            var validador = new ValidadorNome();
            var resultado = validador.Validar(cadastro);

            Assert.IsFalse(resultado.Valido);
            StringAssert.Contains(resultado.Mensagem, "Nome Completo");
        }

        [TestMethod]
        public void dado_um_cadastro_com_nome_completo_deve_ser_valido()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.Nome = "Fulano de tal";
            var validador = new ValidadorNome();
            var resultado = validador.Validar(cadastro);

            Assert.IsTrue(resultado.Valido);
        }
    }
}