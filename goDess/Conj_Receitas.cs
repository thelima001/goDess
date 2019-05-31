using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace goDess
{
    public class Conj_Receitas
    {
        private string connectionstr;
        private MySqlConnection conn = null;

        public Conj_Receitas()
        {
            connectionstr = string.Format("server=localhost;port=3306;user id=root;database=mydb;password=saxofone98", "mydb");
            conn = new MySqlConnection(connectionstr);
        }

        public void add (Receita r)
        {/*
            MySqlParameter[] pms = new MySqlParameter[5];
            pms[0] = new MySqlParameter("nidReceita", MySqlDbType.Int24);
            pms[0].Value = r.getid();
            pms[1] = new MySqlParameter("nnome", MySqlDbType.String);
            pms[1].Value = r.getnome();
            pms[2] = new MySqlParameter("ninstrucoes", MySqlDbType.String);
            pms[2].Value = r.getinstrucoes();
            pms[3] = new MySqlParameter("nmorada", MySqlDbType.String);
     
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_utilizador";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();*/
        }

        public Boolean contains (int id)
        {
            Receita r = get(id);
            if (r == null) return false;
            else return true;
        }

        public Receita get (int id)
        {
            Receita res = null;
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Id", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "get_receita";
            cmd.Parameters.AddRange(pms);

            MySqlDataReader reader = cmd.ExecuteReader();
            string nome = "", inst = "";
            int cat = -1;
            while (reader.Read())
            {
                nome = (string)reader["Nome"];
                cat = (int)reader["Categoria"];
                inst = (string)reader["Instrucoes"];
            }
            if (nome == "") res = null;
            else res = new Receita(id, nome, cat, inst);
            conn.Close();


            return res;
        }

    }
}
