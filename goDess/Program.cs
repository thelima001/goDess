﻿using System;
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
            
            Utilizador u = users.get(2);
            /*if (u != null) Console.Write(u.getnome());
            else Console.Write("ola");*/
            Receita r = new Receita("ola", "Mousse", null, "123");
            int x = receitas.add(r);
            Console.Write("DDDDDDD " + x);

           
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
