using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goDess
{
    public class Ingrediente
    {
        public string Nome { get; set; }

        public int Id { get; set; }
        public Ingrediente(string nome, int id)
        {
            Nome = nome;
            Id = id;
        }


    }
}
