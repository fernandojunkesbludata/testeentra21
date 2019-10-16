using System.Collections;
using System.Collections.Generic;
using AvaliacaoCore.DB.Model;
using AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro;

namespace AvaliacaoCore.RegraDeNegocio.Validacoes
{
    public class RegrasDeValidacaoFactory
    {
        public IList<IValidacao<DB.Model.Cadastro>> ObterValidadoresCadastro(Configuracao config)
        {
            var validacoes = new List<IValidacao<DB.Model.Cadastro>>
            {
                new ValidadorNome(),
                new ValidadorCPF(),
                new ValidadorDataNascimento(),
                new ValidadorTelefone()
            };

            //TESTE: Implemente: caso seja do rio grande do sul (rs), o cliente é obrigado a ter email cadastrado;
            //PLUS: Adicione a regra em tela também

            switch (config.UF)
            {
                case "pr":
                    validacoes.Add(new ValidadorMaiorDezoito());
                    break;
                case "sc":
                    validacoes.Add(new ValidadorRG());
                    break;
            }

            return validacoes;
        }
    }
}