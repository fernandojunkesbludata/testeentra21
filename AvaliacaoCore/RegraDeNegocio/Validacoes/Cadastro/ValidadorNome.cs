namespace AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro
{
    public class ValidadorNome : IValidacao<DB.Model.Cadastro>
    {
        public ResultadoValidacao Validar(DB.Model.Cadastro model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome))
                return Invalido();
            if (!model.Nome.Contains(" "))
                return Invalido();
            return Valido();
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
                Mensagem = "Esperado Nome Completo"
            };
        }
    }
}