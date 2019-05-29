using System;
using System.Collections.Generic;

namespace goDess
{
    public class Conj_Dietas
    {
        private Dictionary<int, Dieta> dietas;

        public Conj_Dietas()
        {
            Dictionary<int, Dieta> dietas = new Dictionary<int, Dieta>();
        }

        public void add(Dieta d)
        {
            dietas.Add(d.getid(), d);
        }

        public Boolean contains(Dieta d)
        {
            return receitas.ContainsKey(d.getid());
        }

        public Dieta get(int id)
        {
            return dietas[id];
        }

    }
}