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
        public Ingrediente(int id,string nome)
        {
            Nome = nome;
            Id = id;
        }


    }
}
