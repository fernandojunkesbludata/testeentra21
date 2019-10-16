using AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAvaliacao.Core.RegraDeNegocio.Validacoes.Cadastro
{
    [TestClass]
    public class ValidadorRGTeste
    {
        [TestMethod]
        public void dado_um_cadastro_sem_rg_deve_ser_invalido()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            var validador = new ValidadorRG();
            var resultado = validador.Validar(cadastro);
            Assert.IsFalse(resultado.Valido);
            StringAssert.Contains(resultado.Mensagem, "RG");
        }

        [TestMethod]
        public void dado_um_cadastro_com_rg_deve_ser_valido()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.RG = 5333222;
            var validador = new ValidadorRG();
            var resultado = validador.Validar(cadastro);
            Assert.IsTrue(resultado.Valido);
        }
    }
}