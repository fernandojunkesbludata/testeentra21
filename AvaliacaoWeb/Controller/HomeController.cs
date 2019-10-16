using System;
using System.Collections.Generic;
using System.Linq;
using AvaliacaoCore;
using AvaliacaoCore.DB;
using AvaliacaoCore.DB.Model;
using AvaliacaoCore.RegraDeNegocio.Validacoes;
using AvaliacaoWeb.Model;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoWeb.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        //PLUS: Ao executar os métodos do controller, existem muita lógica que talvez não seja responsabilidade do Controller, seria interessante que a regra de negócio sejá responsabilidade de outra classe.
        private ManipuladorSqlite manipulador;

        public HomeController()
        {
            manipulador = new ManipuladorSqlite();
        }
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult Cadastrar([FromBody]Cadastro novoCadastro)
        {
            var validadores = new RegrasDeValidacaoFactory().ObterValidadoresCadastro(Configuracao.Instancia);
            var mensagensDeErro = validadores.Select(v => v.Validar(novoCadastro)).Where(r => !r.Valido).Select(r => r.Mensagem).ToArray();
            if (mensagensDeErro.Length > 0)
            {
                var msg = String.Join(';', mensagensDeErro);
                return Json(msg);
            }

            novoCadastro.UF = Configuracao.Instancia.UF;
            novoCadastro.HoraCadastro = DateTime.Now;
            
            manipulador.AdicionarCadastro(novoCadastro);
            return Json("");
        }

        [HttpPost]
        public JsonResult Pesquisar([FromBody]PesquisaCadastro pesquisa)
        {
            const int registrosPorPagina = 25;
            var consulta = manipulador.BuscarCadastrosCompletoOnde();
            var contador = manipulador.BuscarCadastrosOnde();
            AplicarFiltro(consulta, pesquisa);
            AplicarFiltro(contador, pesquisa);
            consulta.Pular((pesquisa.Pagina - 1) * registrosPorPagina).Pegar(registrosPorPagina);
            var resultado = new ResultadoPesquisaCadastro();
            resultado.Cadastros = consulta.Executar().ToList();
            resultado.TotalRegistros = contador.Contar();

            //PLUS: formate o CPF em tela.
            return Json(resultado);
        }

        private void AplicarFiltro(IBuscaComFiltro<Cadastro> busca, PesquisaCadastro pesquisa)
        {
            //TESTE: aqui se utiliza desta constante, para permitir todos os horários do dia final da pesquisa. Isso não é a melhor maneira de fazer isso.
            //Além disso, existe um problema nas comparações feitas.
            //Faça as coreções e alterações que achar necessária.

            //Dica: há um outro TESTE que requer adicionar um filtro, então vai ser necessário adicionar aqui.
            const int de23h59m59s = 86399;
            if (!string.IsNullOrWhiteSpace(pesquisa.Nome))
            {
                busca.NomeLike(pesquisa.Nome);
            }

            if (pesquisa.CadastroDe.HasValue)
            {
                busca.Propriedade(x => x.HoraCadastro > pesquisa.CadastroDe);
            }
            if (pesquisa.CadastroAte.HasValue)
            {
                busca.Propriedade(x => x.HoraCadastro < pesquisa.CadastroAte.Value.AddSeconds(de23h59m59s));
            }

            if (pesquisa.NascimentoDe.HasValue)
            {
                busca.Propriedade(x => x.DataNascimento > pesquisa.NascimentoDe);
            }
            if (pesquisa.NascimentoAte.HasValue)
            {
                busca.Propriedade(x => x.DataNascimento < pesquisa.NascimentoAte.Value.AddSeconds(de23h59m59s));
            }
        }
        
        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }
    }
}