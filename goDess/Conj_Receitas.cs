using System;
using System.Collections.Generic;

namespace goDess
{
    public class Conj_Receitas
    {
        private Dictionary<int, Receitas> receitas;

        public Conj_Receitas()
        {
            Dictionary<int, Receita> receitas = new Dictionary<int, Receita> ();
        }

        public void add (Receita r)
        {
            receitas.Add(r.getid(), r);
        }

        public Boolean contains (Receita r)
        {
            return receitas.ContainsKey(r.getid());
        }

        public Receita get (int id)
        {
            return receitas[id];
        }

    }
}
