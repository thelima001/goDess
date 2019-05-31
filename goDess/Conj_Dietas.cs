using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace goDess
{
    public class Conj_Dietas
    {
        private string connectionstr;
        private MySqlConnection conn = null;

        public Conj_Dietas()
        {
            connectionstr = string.Format("server=localhost;port=3306;user id=root;database=mydb;password=saxofone98", "mydb");
            conn = new MySqlConnection(connectionstr);
        }

        public void add(Dieta d)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("nid", MySqlDbType.Int24);
            pms[0].Value = d.getid();
            pms[1] = new MySqlParameter("nnome", MySqlDbType.String);
            pms[1].Value = d.getnome();
        

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_dieta";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Boolean contains(int id)
        {
            Dieta d = get(id);
            if (d == null) return false;
            else return true;
        }

        public Dieta get(int id)
        {

            Dieta res = null;
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Id", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
           
                conn.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "get_dieta";
                cmd.Parameters.AddRange(pms);

                MySqlDataReader reader = cmd.ExecuteReader();
                string nome = "";
            
                while (reader.Read())
                {
                    nome = (string)reader["Nome"];
                }
            if (nome == "") res = null;
            else res = new Dieta(id, nome);
            conn.Close();
            return res;
        }

        public List<int> getReceitas(int id)
        {
            List<int> res = new List<int>();
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Id", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "ReceitasDieta";
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