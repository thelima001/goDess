using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace goDess
{
    public class Program
    {

        private static Conj_Utilizadores users = new Conj_Utilizadores();
        private static Conj_Receitas receitas = new Conj_Receitas();
        private static Conj_Dietas dietas = new Conj_Dietas();


        public static void Main(string[] args)
        {
            /*
            Utilizador u = users.get(2);
            if (u != null) Console.Write(u.Nome);
            else Console.Write("ola");
            
            List<int> lista = users.getfavoritos(5);
            foreach (int x in lista) Console.Write(x);*/

           
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
