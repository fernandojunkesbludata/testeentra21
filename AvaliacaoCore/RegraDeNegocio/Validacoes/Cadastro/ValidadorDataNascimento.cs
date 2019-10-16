using System;

namespace AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro
{
    public class ValidadorDataNascimento : IValidacao<DB.Model.Cadastro>
    {
        public ResultadoValidacao Validar(DB.Model.Cadastro model)
        {
            if (model.DataNascimento > DateTime.Now)
                return Invalido();
            if (model.DataNascimento < new DateTime(1900, 1, 1))
                return Invalido();
            return Valido();
        }

        private ResultadoValidacao Invalido()
        {
            return new ResultadoValidacao
            {
                Valido = false,
                Mensagem = "Data de nascimento inválida"
            };
        }

        private ResultadoValidacao Valido()
        {
            return new ResultadoValidacao { Valido = true };
        }
    }
}