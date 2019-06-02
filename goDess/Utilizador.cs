using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goDess
{
    public class Utilizador
    {
        private string Email { get; set; }
        private string Pass { get; set; }
        private string Morada { get; set; }
        private string Nome { get; set; }
        private int id {get; set;}
        private List<int> excluidos { get; set; }
        private List<int> favoritos { get; set; }
        private Calendario c {get; set;}
        private List<int> dietas {get; set;}
        private Calendario calendario;

        public Utilizador(int id, string nome, string email, string morada) {
            this.id = id;
            this.Nome = nome;
            this.Email = email;
            this.Morada = morada;
}                                                                 


        public Utilizador(string email, string pass, string morada, string nome, List<int> ingredientes, List<int> receitas, Calendario c,List<int> dietas)
        {
            Email = email;
            Pass = pass;
            Morada = morada;
            Nome = nome;
            this.excluidos = ingredientes;
            this.favoritos = receitas;
            this.dietas = dietas;
            this.c = c;
        }

        //adicionar uma receita aos favoritos
        public void addFavorito(int receita) {
            this.favoritos.Add(receita);
        }

        //remover receita dos favoritos
        public void removeFavorito(int receita) {
            this.favoritos.Remove(receita);
        }

        //adicionar um ingrediente aos excluidos
        public void addExcluido(int ingrediente) {
            this.excluidos.Add(ingrediente);
        }
        //remover ingrediente dos exluidos
        public void removeExcluido(int ingrediente) {
            this.excluidos.Remove(ingrediente);
        }

        //adicionar dieta
        public void addDieta(int dieta) {
            this.dietas.Add(dieta);
        }
        //remover uma dieta das dietas
        public void removeDieta(int dieta) {
            this.dietas.Remove(dieta);
        }


        public void limparExluidos() {
            this.excluidos = new List<int>();
        }
        public void limparFavoritos() {
            this.favoritos = new List<int>();
        }
        public void limpardietas() {
            this.dietas = new List<int>();
        }
        public int getid()
        {
            return this.id;
        }
        public string getnome()
        {
            return this.Nome;
        }
        public string getemail()
        {
            return this.Email;
        }
        public string getpass()
        {
            return this.Pass;
        }
        public string getmorada()
        {
            return this.Morada;
        }
    }
}
