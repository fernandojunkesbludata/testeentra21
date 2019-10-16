using System.Collections.Generic;
using AvaliacaoCore.DB.Model;

namespace AvaliacaoWeb.Model
{
    public class ResultadoPesquisaCadastro
    {
        public IList<Cadastro> Cadastros { get; set; }
        public int TotalRegistros { get; set; }
    }
}