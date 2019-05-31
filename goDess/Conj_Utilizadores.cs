using System;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

namespace goDess
{
    public class Conj_Utilizadores
    {
        private string connectionstr;
        private MySqlConnection conn = null;

        public Conj_Utilizadores()
        {
            connectionstr = string.Format("server=localhost;port=3306;user id=root;database=mydb;password=saxofone98", "mydb");
            conn = new MySqlConnection(connectionstr);
        }

        public void add(Utilizador u)
        {

            MySqlParameter[] pms = new MySqlParameter[5];
            pms[0] = new MySqlParameter("nidUser", MySqlDbType.Int24);
            pms[0].Value = u.getid();
            pms[1] = new MySqlParameter("nnome", MySqlDbType.String);
            pms[1].Value = u.getnome();
            pms[2] = new MySqlParameter("nemail", MySqlDbType.String);
            pms[2].Value = u.getemail();
            pms[3] = new MySqlParameter("nmorada", MySqlDbType.String);
            pms[3].Value = u.getmorada();
            pms[4] = new MySqlParameter("npasse", MySqlDbType.String);
            pms[4].Value = u.getpass();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_utilizador";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Boolean contains(int i)
        {
            return true;
        }

        public Utilizador get(int id) 
        {
            
            Utilizador res = null;

            
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Id",MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
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
           
                
            return res;


        }
        public List<int> getExcluidos(int id)
        {
            List<int> res = new List<int>();
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Id", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ExcluidosUser";
            cmd.Parameters.AddRange(pms);

            MySqlDataReader reader = cmd.ExecuteReader();
            int aux;
            while (reader.Read())
            {
                aux = (int)reader["Ingrediente"];
                res.Add(aux);
            }


            conn.Close();

            return res;

        }
        public List<int> getfavoritos (int id) {

            List<int> res = new List<int>();
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Util", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "FavoritosUser";
                cmd.Parameters.AddRange(pms);

                MySqlDataReader reader = cmd.ExecuteReader();
                int aux;
                while (reader.Read())
                {
                    aux = (int)reader["Receita"];
                    res.Add(aux);
                }

               
                conn.Close();

            return res;
        }
    }
}
