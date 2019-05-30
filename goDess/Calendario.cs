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

        
        }

        //receitas num intervalo de datas, a ser usado para as receitas numa semana
        public void receitasDatas(DateTime inicio, DateTime fim){
           
        }

        //use case de adicionar receita a um dia
        public void add(DateTime d, Receita r)
        {
           
        }

        public Boolean contains(DateTime d,Receita r)
        {
            return true;
        }

    }
}
