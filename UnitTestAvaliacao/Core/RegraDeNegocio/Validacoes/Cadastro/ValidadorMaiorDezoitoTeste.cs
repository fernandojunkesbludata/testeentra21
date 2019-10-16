using System;
using AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAvaliacao.Core.RegraDeNegocio.Validacoes.Cadastro
{
    [TestClass]
    public class ValidadorMaiorDezoitoTeste
    {
        [TestMethod]
        public void dado_um_cadastro_cuja_idade_menor_de_18_anos_deve_ser_invalida()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.DataNascimento = DateTime.Now.AddYears(-18).AddDays(1);
            var validador = new ValidadorMaiorDezoito();
            var resultado = validador.Validar(cadastro);

            Assert.IsFalse(resultado.Valido);
            StringAssert.Contains(resultado.Mensagem, "18 anos");
        }

        [TestMethod]
        public void dado_um_cadastro_cuja_idade_maior_de_18_anos_deve_ser_valida()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.DataNascimento = DateTime.Now.AddYears(-18);
            var validador = new ValidadorMaiorDezoito();
            var resultado = validador.Validar(cadastro);

            Assert.IsTrue(resultado.Valido);
        }
    }
}