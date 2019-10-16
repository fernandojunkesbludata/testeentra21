namespace AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro
{
    public class ValidadorRG : IValidacao<DB.Model.Cadastro>
    {
        public ResultadoValidacao Validar(DB.Model.Cadastro model)
        {
            if (model.RG > 0)
            {
                return new ResultadoValidacao {Valido = true};
            }
            return new ResultadoValidacao
            {
                Valido = false,
                Mensagem = "Campo RG não preenchido"
            };
        }
    }
}