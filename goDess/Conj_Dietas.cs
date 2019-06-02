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








        //////////////////////////////geral dietas //////////////////////////////////////

        public int add(Dieta d)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("nnome", MySqlDbType.String);
            pms[0].Value = d.getnome();
        

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_dieta";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Open();

            cmd = new MySqlCommand("last_id", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read(); int res = reader.GetInt32(0);
            conn.Close();
            return res;
        }
        public void update(Dieta d)
        {
            if (contains(d.getid())) { remove(d.getid());add(d); }
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

        public void remove(int id)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("ndieta", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_dieta";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }









        //////////////////////////////receitas cumprem dieta //////////////////////////////////////

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
        public void remove_receitas(int idd, int idr)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("ndieta", MySqlDbType.Int24);
            pms[0].Value = idd;
            pms[1] = new MySqlParameter("nreceita", MySqlDbType.Int24);
            pms[1].Value = idr;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_receitas_dieta";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void add_receitas(int idd, int idr)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("ndieta", MySqlDbType.Int24);
            pms[0].Value = idd;
            pms[1] = new MySqlParameter("nreceita", MySqlDbType.Int24);
            pms[1].Value = idr;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "add_receitas_dieta";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}