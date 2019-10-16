using AvaliacaoCore;

namespace UnitTestAvaliacao.Core
{
    public class ConfiguracaoParaTeste : Configuracao
    {
        private ConfiguracaoParaTeste() : base("any")
        {}

        internal static void Reset()
        {
            instancia = null;
        }
    }
}