using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoCore.DB
{
    public class BuscaComFiltro<T> : IBuscaComFiltro<T> where T:class
    {
        private IEnumerable<T> colecao;

        internal BuscaComFiltro(IEnumerable<T> colecao)
        {
            this.colecao = colecao;
        }

        public IBuscaComFiltro<T> Propriedade(Func<T, bool> condicao)
        {
            colecao = colecao.Where(condicao);
            return this;
        }
        

        public int Contar()
        {
            return colecao.Count();
        }


        public IList<T> Executar()
        {
            return colecao.ToList();
        }
        
        public IBuscaComFiltro<T> Pular(int pular)
        {
            colecao = colecao.Skip(pular);
            return this;
        }

        public IBuscaComFiltro<T> Pegar(int quantidade)
        {
            colecao = colecao.Take(quantidade);
            return this;
        }
    }
}