using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

namespace goDess
{
    public class Conj_Utilizadores
    {
        private static string connectionstr = "server=localhost;user id=root;database=mydb;persistsecurityinfo=True;allowuservariables=True";
        private MySqlConnection conn = new MySqlConnection(connectionstr);

        public Conj_Utilizadores()
        {
            
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
            Utilizador res = null;

            try {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Id",MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
                try
                {
                    conn.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "get_user";
                    cmd.Parameters.AddRange(pms);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    string nome = "", email = "", morada = "";
                    while (reader.Read())
                    {
                        nome = (string)reader["Nome"];
                        email = (string)reader["Email"];
                        morada = (string)reader["Morada"];
                    }

                    res = new Utilizador(id, nome, email, morada);
                    conn.Close();
                }
                catch (System.NotSupportedException) { }
          
           
                } catch(MySqlException){}
            return res;


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
