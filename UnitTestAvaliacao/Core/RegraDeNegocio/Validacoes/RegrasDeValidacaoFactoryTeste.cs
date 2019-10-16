using System;
using System.Linq;
using AvaliacaoCore;
using AvaliacaoCore.RegraDeNegocio.Validacoes;
using AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAvaliacao.Core.RegraDeNegocio.Validacoes
{
    [TestClass]
    public class RegrasDeValidacaoFactoryTeste
    {
        [TestInitialize]
        public void Setup()
        {
            ConfiguracaoParaTeste.Reset();
        }

        [TestMethod]
        public void dado_uma_configuracao_qualquer_deve_ter_os_validadores_padroes_para_cadastro()
        {
            var config = DadoUmaConfiguracao("any");
            var factory = new RegrasDeValidacaoFactory();
            var validadores = factory.ObterValidadoresCadastro(config);
            Assert.AreEqual(validadores.Count(v => v.GetType() == typeof(ValidadorCPF)), 1);
            Assert.AreEqual(validadores.Count(v => v.GetType() == typeof(ValidadorNome)), 1);
            Assert.AreEqual(validadores.Count(v => v.GetType() == typeof(ValidadorDataNascimento)), 1);
            Assert.AreEqual(validadores.Count(v => v.GetType() == typeof(ValidadorTelefone)), 1);
        }

        [TestMethod]
        public void dado_uma_configuracao_do_pr_deve_ter_o_validador_de_idade_e_nao_rg()
        {
            var config = DadoUmaConfiguracao("PR");
            var factory = new RegrasDeValidacaoFactory();
            var validadores = factory.ObterValidadoresCadastro(config);
            Assert.AreEqual(validadores.Count(v => v.GetType() == typeof(ValidadorMaiorDezoito)), 1);
            Assert.AreEqual(validadores.Count(v => v.GetType() == typeof(ValidadorRG)), 0);
        }

        [TestMethod]
        public void dado_uma_configuracao_de_sc_deve_ter_o_validador_de_rg_e_nao_idade()
        {
            var config = DadoUmaConfiguracao("SC");
            var factory = new RegrasDeValidacaoFactory();
            var validadores = factory.ObterValidadoresCadastro(config);
            Assert.AreEqual(validadores.Count(v => v.GetType() == typeof(ValidadorRG)), 1);
            Assert.AreEqual(validadores.Count(v => v.GetType() == typeof(ValidadorMaiorDezoito)), 0);
        }

        private Configuracao DadoUmaConfiguracao(string uf)
        {
            ConfiguracaoParaTeste.Inicializar(uf);
            return ConfiguracaoParaTeste.Instancia;
        }
    }
}