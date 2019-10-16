using System;
using AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAvaliacao.Core.RegraDeNegocio.Validacoes.Cadastro
{
    [TestClass]
    public class ValidadorDataNascimentoTeste
    {
        [TestMethod]
        public void dado_uma_data_antes_de_1900_deve_ser_invalida()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.DataNascimento = new DateTime(1899,12,31);
            var validador = new ValidadorDataNascimento();
            var resultado = validador.Validar(cadastro);
            
            Assert.IsFalse(resultado.Valido);
            StringAssert.Contains(resultado.Mensagem, "Data de nascimento");
        }

        [TestMethod]
        public void dado_uma_data_depois_da_atual_deve_ser_invalida()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.DataNascimento = DateTime.Now.AddDays(1);
            var validador = new ValidadorDataNascimento();
            var resultado = validador.Validar(cadastro);

            Assert.IsFalse(resultado.Valido);
            StringAssert.Contains(resultado.Mensagem, "Data de nascimento");
        }

        [TestMethod]
        public void dado_uma_data_possivel_deve_ser_valido()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.DataNascimento = DateTime.Now.AddYears(-10);
            var validador = new ValidadorDataNascimento();
            var resultado = validador.Validar(cadastro);

            Assert.IsTrue(resultado.Valido);
        }

    }
}