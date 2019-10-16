using System.Collections.Generic;
using AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAvaliacao.Core.RegraDeNegocio.Validacoes.Cadastro
{
    [TestClass]
    public class ValidadorCPFTeste
    {
        [TestMethod]
        public void dado_um_cpf_vazio_deve_retornar_invalido()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.CPF = 0;
            var validador = new ValidadorCPF();
            var resultado = validador.Validar(cadastro);
            Assert.IsFalse(resultado.Valido);
            StringAssert.Contains(resultado.Mensagem, "CPF");
            StringAssert.Contains(resultado.Mensagem, "inválido");
        }

        [TestMethod]
        [DataRow(13254681321)]
        [DataRow(64681621658)]
        [DataRow(03458138811)]
        [DataRow(777777777770)]
        public void dado_um_cpf_invalido_deve_retornar_invalido(long cpfInvalido)
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.CPF = cpfInvalido;
            var validador = new ValidadorCPF();
            var resultado = validador.Validar(cadastro);
            Assert.IsFalse(resultado.Valido);
            StringAssert.Contains(resultado.Mensagem, "CPF");
            StringAssert.Contains(resultado.Mensagem, "inválido");
        }

        
        [TestMethod]
        [DataRow(77777777777)]
        [DataRow(70264254120)]
        [DataRow(11236809068)]
        [DataRow(08575764888)]
        public void dado_um_cpf_valido_deve_retornar_valido(long cpfValido)
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.CPF = cpfValido;
            var validador = new ValidadorCPF();
            var resultado = validador.Validar(cadastro);
            Assert.IsTrue(resultado.Valido);
            Assert.IsNull(resultado.Mensagem);
        }
    }
}