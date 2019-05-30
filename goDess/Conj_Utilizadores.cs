using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace goDess
{
    public class Conj_Utilizadores
    {
        private string connectionstr = "server=localhost;user id=root;database=mydb;persistsecurityinfo=True;allowuservariables=True";
        private MySqlConnection conn = new MySqlConnection(connectionstr);

        public Conj_Utilizadores()
        {

        }

        public void add(Utilizador u)
        {
            
        }

        public Boolean contains(Utilizador u)
        {
            return receitas.ContainsKey(u.getid());
        }

        public Utilizador get(int id)
        {
            return utilizadores[id];
        }
        public List<int> getfavoritos (int id) {

            List<int> res = new List<int>();
            connection();
            MySqlCommand cmd = new MySqlCommand("FavoritosUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
 
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
 
            conn.Open();
            sd.Fill(dt);
            conn.Close();
 
            foreach(DataRow dr in dt.Rows)
            {
                res.Add(dr["Receita"]);
            }
            return res;
        }
    }
}
