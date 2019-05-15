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

        public Utilizador(string email, string pass, string morada, string nome)
        {
            Email = email;
            Pass = pass;
            Morada = morada;
            Nome = nome;
        }
    }
}
