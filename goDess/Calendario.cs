using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goDess
{
    public class Calendario
    {
        private DateTime data;


        public DateTime GetData()
        {
            return Data;
        }

        public Calendario(DateTime data)
        {
            this.data = data;
        }

        public void SetData(DateTime value)
        {
            Data = value;
        }
    }
}
