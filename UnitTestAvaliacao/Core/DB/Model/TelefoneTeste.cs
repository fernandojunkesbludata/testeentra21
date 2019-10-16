using System;
using AvaliacaoCore.DB.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAvaliacao.Core.DB.Model
{
    [TestClass]
    public class TelefoneTeste
    {
        [TestMethod]
        public void dado_uma_string_de_telefone_so_com_numeros_deve_gerar_o_telefone()
        {
            var stringTelefone = "47987654321";
            var tel = new Telefone(stringTelefone);
            Assert.AreEqual(tel.DDD, 47);
            Assert.AreEqual(tel.Numero, 987654321);
            Assert.AreEqual(tel.ToString(), "(47) 98765-4321");
        }

        [TestMethod]
        public void dado_uma_string_de_telefone_formatada_deve_gerar_o_telefone()
        {
            var stringTelefone = "(47)98765-4321";
            var tel = new Telefone(stringTelefone);
            Assert.AreEqual(tel.DDD, 47);
            Assert.AreEqual(tel.Numero, 987654321);
            Assert.AreEqual(tel.ToString(), "(47) 98765-4321");
        }

        [TestMethod]
        public void dado_uma_string_que_nao_tem_10_ou_11_digitos_deve_lancar_excecao()
        {
            var stringTelefone = "(47)98765-43210";

            Assert.ThrowsException<InvalidCastException>(() =>
            {
                var tel = new Telefone(stringTelefone);
            });
        }

        [TestMethod]
        public void dado_uma_string_de_telefone_fazer_implicit_cast()
        {
            Telefone tel = new Telefone("47987654321");
            Assert.AreEqual(tel.DDD, 47);
            Assert.AreEqual(tel.Numero, 987654321);
            Assert.AreEqual(tel.ToString(), "(47) 98765-4321");
        }

        [TestMethod]
        public void dado_um_telefone_com_10_digitos_deve_funcionar()
        {
            Telefone tel = new Telefone("4787654321");
            Assert.AreEqual(tel.DDD, 47);
            Assert.AreEqual(tel.Numero, 87654321);
            Assert.AreEqual(tel.ToString(), "(47) 8765-4321");
        }

        [TestMethod]
        public void dado_um_telefone_com_zeros_deve_ser_valido()
        {
            Telefone tel = new Telefone("47900000000");
            Assert.AreEqual(tel.DDD, 47);
            Assert.AreEqual(tel.Numero, 900000000);
            Assert.AreEqual(tel.ToString(), "(47) 90000-0000");
        }
    }
}