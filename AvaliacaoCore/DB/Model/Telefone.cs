using System;
using System.Text.RegularExpressions;

namespace AvaliacaoCore.DB.Model
{
    public class Telefone
    {
        public long Id { get; set; }
        public byte DDD { get; set; }
        public long Numero { get; set; }

        public Telefone()
        {
        }

        public Telefone(string numeroString)
        {
            var removerTodosNaoDigitos = new Regex("\\D");
            var numeroDigitos = removerTodosNaoDigitos.Replace(numeroString, "");
            if (numeroDigitos.Length != 11 && numeroDigitos.Length != 10)
            {
                throw new InvalidCastException("Número de telefone deve conter entre 10 e 11 dígitos, contando com DDD");
            }

            DDD = byte.Parse(numeroDigitos.Substring(0, 2));
            Numero = long.Parse(numeroDigitos.Substring(2));
        }

        //PLUS: eiste uma maneira de fazer o código entender diretamente que uma string pode ser um número de Telefone, possibilitando algo como: Telefone tel = "9922223333";
        //implemente o código necessário para isso.

        public override string ToString()
        {
            //TESTE: Este ToString é bem ruim, e queremos que a string do telefone seja o formato (99) 9999-9999 OU (99) 99999-9999, encontre uma boa maneira, legível de fazer isto.
            return "" + DDD + " " + Numero;
        }
    }
}