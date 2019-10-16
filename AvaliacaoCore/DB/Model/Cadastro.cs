using System;
using System.Collections.Generic;

namespace AvaliacaoCore.DB.Model
{
    public class Cadastro
    {
        //TESTE: adicione um campo de e-mail
        public long Id { get; set; }
        public string UF { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public long? RG { get; set; }
        public DateTime HoraCadastro { get; set; }
        public DateTime DataNascimento { get; set; }
        public IList<Telefone> Telefones { get; set; }

        public Cadastro()
        {
            Telefones = new List<Telefone>();
        }
    }
}