using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goDess
{
    public class Instrucao
    {
        public string Designacao { get; set; }

        public Instrucao(string designacao)
        {
            Designacao = designacao;
        }
    }
}
