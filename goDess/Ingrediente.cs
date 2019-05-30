using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goDess
{
    public class Ingrediente
    {
        private string Nome { get; set; }

        private int Id { get; set; }
        private Ingrediente(string nome, int id)
        {
            Nome = nome;
            Id = id;
        }


    }
}
