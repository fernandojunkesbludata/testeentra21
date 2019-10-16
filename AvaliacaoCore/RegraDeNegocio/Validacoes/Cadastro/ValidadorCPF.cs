namespace AvaliacaoCore.RegraDeNegocio.Validacoes.Cadastro
{
    public class ValidadorCPF : IValidacao<DB.Model.Cadastro>
    {
        public ResultadoValidacao Validar(DB.Model.Cadastro model)
        {
            
            var cpf = model.CPF;
            if (cpf <= 0 || cpf > 99999999999) return Invalido();

            var numeros = cpf / 100;
            var digVerificador1 = ((cpf / 10) % 10);
            var digVerificador2 = (cpf % 10);
            var resto = Resto(numeros);
            if (resto != digVerificador1) return Invalido();
            numeros = cpf / 10;
            resto = Resto(numeros);
            if (resto != digVerificador2) return Invalido();
            return Valido();
        }


        private static long Resto(long numeros)
        {
            long soma = 0;
            var mul = 2;
            while (numeros > 0)
            {
                var dig = numeros % 10;
                soma += mul * dig;
                numeros = numeros / 10;
                mul++;
            }

            var resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;
            return resto;
        }

        private ResultadoValidacao Valido()
        {
            return new ResultadoValidacao { Valido = true };
        }

        private ResultadoValidacao Invalido()
        {
            return new ResultadoValidacao
            {
                Valido = false,
                Mensagem = "CPF informado é inválido"
            };
        }
    }

}