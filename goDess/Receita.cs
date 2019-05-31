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
       // private List<Instrucao> instrucoes {get; set;}
       private string instrucoes;

        public Receita(int id, string nome, int categoria, string instrucoes)
        {
            this.id = id;
            this.Nome = nome;
            this.Categoria = categoria;
            this.instrucoes = instrucoes;
        }
        public Receita (string nome, string categoria, List<Ingrediente> ingredientes, string instrucoes)
        {
            Nome = nome;
            Categoria = categoria;
            this.ingredientes = ingredientes;
            this.instrucoes = instrucoes;   
        }
        public int getid()
        {
            return id;
        }
        public string getnome()
        {
            return Nome;
        }
        public string getinstrucoes()
        {
            return instrucoes;
        }
    }
}
