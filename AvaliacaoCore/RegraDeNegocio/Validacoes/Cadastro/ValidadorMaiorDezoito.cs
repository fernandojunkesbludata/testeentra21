using System;

namespace AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro
{
    public class ValidadorMaiorDezoito : IValidacao<DB.Model.Cadastro>
    {
        public ResultadoValidacao Validar(DB.Model.Cadastro model)
        {
            //TESTE: Esse código é péssimo, existem maneiras melhores de verificar se o cliente tem mais de 18 anos.
            //Reescreva este código de modo que ele seja "melhor".

            var anos = DateTime.Now.Year - model.DataNascimento.Year;
            if (anos > 18) return Valido();
            if (anos < 18) return Invalido();

            var meses = DateTime.Now.Month - model.DataNascimento.Month;
            if (meses > 0) return Valido();
            if (meses < 0) return Invalido();

            var dias = DateTime.Now.Day - model.DataNascimento.Day;
            if (dias >= 0) return Valido();
            return Invalido();
        }

        private ResultadoValidacao Valido()
        {
            return new ResultadoValidacao
            {
                Valido = true
            };
        }

        private ResultadoValidacao Invalido()
        {
            return new ResultadoValidacao
            {
                Valido = false,
                Mensagem = "É necessário ser maior de 18 anos"
            };
        }
    }
}