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


        ////////////////////////////categoria///////////////////////////////
        
        public int add_categoria(string categoria)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
    
            pms[0] = new MySqlParameter("nnome", MySqlDbType.String);
            pms[0].Value = categoria;


            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_categoria";
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
        public void remove_categoria(int id)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("ncategoria", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_categoria";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public int contains_categoria(string name)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("nnome", MySqlDbType.String);
            pms[0].Value = name;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "get_categoria_id";
            cmd.Parameters.AddRange(pms);

            MySqlDataReader reader = cmd.ExecuteReader();
            int id = -1;
            while (reader.Read())
            {
                id = (int)reader["id"];
            }
            conn.Close();
            return id;
        }
        public string get_categoria(int id)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Id", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "get_categoria";
            cmd.Parameters.AddRange(pms);

            MySqlDataReader reader = cmd.ExecuteReader();
            string nome = "";
            while (reader.Read())
            {
                nome = (string)reader["Nome"];
            }
            conn.Close();
            if (nome == "") return null;
            else return nome;
        }
        










        //////////////////geral receitas///////////////////



        //adiciona uma receita (sem id)
        public int add (Receita r)
        {
            int aux = contains_categoria(r.getcategoria());
            if (aux == -1) aux = add_categoria(r.getcategoria()); 


            MySqlParameter[] pms = new MySqlParameter[3];
            pms[0] = new MySqlParameter("nnome", MySqlDbType.String);
            pms[0].Value = r.getnome();
            pms[1] = new MySqlParameter("ncategoria", MySqlDbType.Int24);
            pms[1].Value = aux;
            pms[2] = new MySqlParameter("ninstrucoes", MySqlDbType.LongText);
            pms[2].Value = r.getinstrucoes();

            conn.Close();
            MySqlCommand cmd = new MySqlCommand("inserir_receita",conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange(pms);
            cmd.ExecuteNonQuery();

            conn.Open();
   
            cmd = new MySqlCommand("last_id",conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read(); int res = reader.GetInt32(0);
            conn.Close();
            return res;
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
            else res = new Receita(id, nome, get_categoria(cat), inst);
            conn.Close();


            return res;
        }
        public void remove(int id)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("nreceita", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_receita";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }












        ////////////////////////////////////ingredientes da receita///////////////////////
        

        public void add_ingrediente_receita(int idi, int idr, string quant)
        {
            MySqlParameter[] pms = new MySqlParameter[3];
            pms[0] = new MySqlParameter("nreceita", MySqlDbType.Int24);
            pms[0].Value = idr;
            pms[1] = new MySqlParameter("ningrediente", MySqlDbType.Int24);
            pms[1].Value = idi;
            pms[2] = new MySqlParameter("nquantidade", MySqlDbType.VarChar);
            pms[2].Value = quant;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_receita_ingrediente";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void remove_ingrediente_receita(int idi, int idr)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("nreceita", MySqlDbType.Int24);
            pms[0].Value = idr;
            pms[1] = new MySqlParameter("ningrediente", MySqlDbType.Int24);
            pms[1].Value = idi;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_receita_ingrediente";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<(int,string)> get_ingredientes_quantidade_receita(int id)
        {
            List<(int, string)> res = null;
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Id", MySqlDbType.Int24);
            pms[0].Value = id;
      

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "IngredientesReceita";
            cmd.Parameters.AddRange(pms);

            MySqlDataReader reader = cmd.ExecuteReader();
            int aux; string q;
            while (reader.Read())
            {
                aux = (int)reader["Ingrediente"];
                q = (string)reader["Quantidade"];
                res.Add((aux,q));
            }


            conn.Close();
            if (res.Count == 0) return null;
            return res;
        }

































        //////////////////////////////////////INGREDIENTE//////////////////////////////////////////

        public int add_ingrediente(string nome)
        {
            MySqlParameter[] pms = new MySqlParameter[1];

            pms[0] = new MySqlParameter("nnome", MySqlDbType.String);
            pms[0].Value = nome;


            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_ingrediente";
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

        public void remove_ingrediente(int id)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("ningrediente", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_ingrediente";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public Ingrediente get_ingrediente(int id)
        {
            Ingrediente res = null;
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("IdIngrediente", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "get_ingrediente";
            cmd.Parameters.AddRange(pms);

            MySqlDataReader reader = cmd.ExecuteReader();
            string nome = "";
            while (reader.Read())
            {
                nome = (string)reader["Nome"];
            }
            conn.Close();
            if (nome == "") return null;
            else return new Ingrediente(id,nome);
        }



    }
}
