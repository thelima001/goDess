using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goDess
{
    public class Utilizador
    {
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Morada { get; set; }
        public string Nome { get; set; }
        private int id {get; set;}
        private List<Ingrediente> ingredientes { get; set; }
        private List<Receita> receitas { get; set; }
        private Calendario c {get; set;}



        public Utilizador(string email, string pass, string morada, string nome, List<Ingrediente> ingredientes, List<Receita> receitas, Calendario c)
        {
            Email = email;
            Pass = pass;
            Morada = morada;
            Nome = nome;
            this.ingredientes = ingredientes;
            this.receitas = receitas;
            this.c = c;
        }
    }
}
