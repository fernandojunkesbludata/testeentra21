using AvaliacaoCore.DB.Model;
using AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAvaliacao.Core.RegraDeNegocio.Validacoes.Cadastro
{
    [TestClass]
    public class ValidadorTelefoneTeste
    {
        [TestMethod]
        public void nao_tem_o_que_validar_nos_telefones_pois_a_propria_classe_valida()
        {
            var cadastro = new AvaliacaoCore.DB.Model.Cadastro();
            cadastro.Telefones.Add(new Telefone("47999999999"));
            var validador = new ValidadorTelefone();
            var resultado = validador.Validar(cadastro);

            Assert.IsTrue(resultado.Valido);
        }
    }
}