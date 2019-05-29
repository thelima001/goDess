using System;
using System.Collections.Generic;

namespace goDess
{
    public class Conj_Utilizadores
    {
        private Dictionary<int, Utilizadores> utilizadores;

        public Conj_Utilizadores()
        {
            Dictionary<int, Utilizador> receitas = new Dictionary<int, Utilizador>();
        }

        public void add(Utilizador u)
        {
            receitas.Add(u.getid(), u);
        }

        public Boolean contains(Utilizador u)
        {
            return receitas.ContainsKey(u.getid());
        }

        public Utilizador get(int id)
        {
            return utilizadores[id];
        }

    }
}
