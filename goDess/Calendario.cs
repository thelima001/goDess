using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goDess
{
    public class Calendario
    {
        private Dictionary<DateTime, List<int>> calendario; // uma data para uma lista de id's de receitas para esse dia

        //limpar as receitas de um dia
        public void limparDia(DateTime d) 
        {
            calendario.Remove(d);
        }

        public void remove(DateTime d, Receita r) {

            if (calendario.ContainsKey(d)) {
                List<int> aux = calendario[d];
                aux.Remove(r.getid());
            }
        }

        //receitas num intervalo de datas, a ser usado para as receitas numa semana
        public List<int> receitasDatas(DateTime inicio, DateTime fim){
            List<int> res = new List<int>();
            for (DateTime d = inicio; d != fim; d.AddDays(1) ) {
                if(calendario.ContainsKey(d)) {
                    foreach (int x in calendario[d]) 
                        res.Add(x);
                }
            }
        }

        //use case de adicionar receita a um dia
        public void add(DateTime d, Receita r)
        {
            List<int> aux;
            if (calendario.ContainsKey(d)) aux = calendario[d];
            else aux = new List<int>();

            aux.Add(r.getid());
            calendario[d] = aux;
        }

        public Boolean contains(DateTime d,Receita r)
        {
            if (!calendario.ContainsKey(d)) return false;
            else List<int> aux = calendario[d];

            return aux.Contains(r.getid());
        }

        //consultar receita de um certo dia
        public List<int> get(DateTime d)
        {
            return calendario[d];
        }

    }
}
