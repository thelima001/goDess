using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goDess
{
    public class Receita
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }

        public Receita(string nome, string categoria)
        {
            Nome = nome;
            Categoria = categoria;
        }
    }
}
