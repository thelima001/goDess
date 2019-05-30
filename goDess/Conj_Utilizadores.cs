using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

namespace goDess
{
    public class Conj_Utilizadores
    {
        private string connectionstr = "server=localhost;user id=root;database=mydb;persistsecurityinfo=True;allowuservariables=True";
        private MySqlConnection conn;

        public Conj_Utilizadores()
        {
            conn = new MySqlConnection(connectionstr);
        }

        public void add(Utilizador u)
        {
            
        }

        public Boolean contains(Utilizador u)
        {
            return true;
        }

        public Utilizador get(int id)
        {
            return null;
        }
        public List<int> getfavoritos (int id) {

            List<int> res = new List<int>();
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            
            cmd.CommandText = "CREATE PROCEDURE `FavoritosUser`(Util int(11)) " +
                "BEGIN select favoritos.receita from favoritos join utilizador on favoritos.utilizador = Utilizador.IdUtilizador" +
                "where favoritos.utilizador = Util;" +
                "END";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("Util", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                res.Add(Convert.ToInt32(reader["Receita"]));
            }

            return res;
        }
    }
}
