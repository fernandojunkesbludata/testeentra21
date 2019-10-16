using System;

namespace AvaliacaoWeb.Model
{
    public class PesquisaCadastro
    {
        public int Pagina { get; set; }
        public string Nome { get; set; }
        public DateTime? NascimentoDe { get; set; }
        public DateTime? NascimentoAte { get; set; }
        public DateTime? CadastroDe { get; set; }
        public DateTime? CadastroAte { get; set; }

        //TESTE: Implemente: pesquisa por cpf, não há necessidade de fazer a implementação em tela.
        //PLUS: Faça a implementação em tela :D
    }
}