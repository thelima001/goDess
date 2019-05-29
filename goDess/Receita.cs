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
        private int id {get; set;}
        private List<Ingrediente> ingredientes {get; set;}
        private List<Instrucao> instrucoes {get; set;}

        public Receita (string nome, string categoria, List<Ingrediente> ingredientes, List<Instrucao> instrucoes)
        {
            Nome = nome;
            Categoria = categoria;
            this.ingredientes = ingredientes;
            this.instrucoes = instrucoes;   
        }

    }
}
