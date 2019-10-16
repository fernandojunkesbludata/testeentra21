using System;
using System.Collections.Generic;

namespace AvaliacaoCore.DB
{
    public interface IBuscaComFiltro<T> where T:class
    {
        IBuscaComFiltro<T> Propriedade(Func<T, bool> condicao);
        int Contar();
        IList<T> Executar();
        IBuscaComFiltro<T> Pular(int pular);
        IBuscaComFiltro<T> Pegar(int quantidade);
    }
}