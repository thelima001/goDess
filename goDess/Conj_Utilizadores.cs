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













        //////////////////////////////geral user //////////////////////////////////////

        public int add(Utilizador u)
        {

            MySqlParameter[] pms = new MySqlParameter[4];
            pms[0] = new MySqlParameter("nnome", MySqlDbType.String);
            pms[0].Value = u.getnome();
            pms[1] = new MySqlParameter("nemail", MySqlDbType.String);
            pms[1].Value = u.getemail();
            pms[2] = new MySqlParameter("nmorada", MySqlDbType.String);
            pms[2].Value = u.getmorada();
            pms[3] = new MySqlParameter("npasse", MySqlDbType.String);
            pms[3].Value = u.getpass();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_utilizador";
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

        public Boolean contains(int i)
        {
            Utilizador u = get(i);
            if ( u == null) return false;
            else return true;
        }
        public void update(Utilizador u) {
            if (contains(u.getid())) {remove(u.getid()); add(u);}   
        }
        public void remove(int id)
        {

            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_utilizador";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
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




        //////////////////////////////excluidos user //////////////////////////////////////

        



        public List<int> getexcluidos(int id)
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
            if (res.Count == 0) return null;
            return res;

        }
        public void removeexcluidos (int idu, int idi)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = idu;
            pms[1] = new MySqlParameter("ningrediente", MySqlDbType.Int24);
            pms[1].Value = idi;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_utilizador_ingrediente";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void limpaexluidos(int idu)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = idu;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_utilizador_ingredientes";
            cmd.Parameters.AddRange(pms);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void addexcluidos(int idu, int idi)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = idu;
            pms[1] = new MySqlParameter("ningrediente", MySqlDbType.Int24);
            pms[1].Value = idi;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_configuracao_ingrediente";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }








        //////////////////////////////receitas favoritas user //////////////////////////////////////






        public void removefavoritos (int idu, int idr) {  
            
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = idu;
            pms[1] = new MySqlParameter("nreceita", MySqlDbType.Int24);
            pms[1].Value = idr;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_favorito";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void limparfavoritos(int id)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = id;
            
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_favoritos_utilizador";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
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
            if (res.Count == 0) return null;
            return res;
        }
        public void addfavoritos(int idu, int idr)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = idu;
            pms[1] = new MySqlParameter("nreceita", MySqlDbType.Int24);
            pms[1].Value = idr;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_favorito";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }




        //////////////////////////////dietas user //////////////////////////////////////


        public List<int> getdietas(int id)
        {
            List<int> res = new List<int>();
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("Id", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DietasUser";
            cmd.Parameters.AddRange(pms);

            MySqlDataReader reader = cmd.ExecuteReader();
            int aux;
            while (reader.Read())
            {
                aux = (int)reader["Dieta"];
                res.Add(aux);
            }
            conn.Close();
            if (res.Count == 0) return null;
            return res;
        }
        public void removedietas(int idu, int idd)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = idu;
            pms[1] = new MySqlParameter("ndieta", MySqlDbType.Int24);
            pms[1].Value = idd;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_utilizador_dieta";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void limpardietas(int id)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_utilizador_dietas";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void inserirdietas(int idu, int idd)
        {
            MySqlParameter[] pms = new MySqlParameter[2];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = idu;
            pms[1] = new MySqlParameter("ndieta", MySqlDbType.Int24);
            pms[1].Value = idd;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_configuracao_dieta";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }











        ////////////////////////Calendario/////////////////////////

       public string datetostr(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }


      public void agendar_receita(int idu, int idr, DateTime data)
        {
            MySqlParameter[] pms = new MySqlParameter[3];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = idu;
            pms[1] = new MySqlParameter("nreceita", MySqlDbType.Int24);
            pms[1].Value = idr;
            pms[2] = new MySqlParameter("ndata", MySqlDbType.Date);
            pms[2].Value = datetostr(data);

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "inserir_calendario";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void remove_calendario(int idu, int idr, DateTime data)
        {
            MySqlParameter[] pms = new MySqlParameter[3];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = idu;
            pms[1] = new MySqlParameter("nreceita", MySqlDbType.Int24);
            pms[1].Value = idr;
            pms[2] = new MySqlParameter("ndata", MySqlDbType.Date);
            pms[2].Value = datetostr(data);

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_calendario";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void limparcalendario(int id)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("nutilizador", MySqlDbType.Int24);
            pms[0].Value = id;

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "eliminar_calendario_utilizador";
            cmd.Parameters.AddRange(pms);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        public void limpardia(int id, DateTime data)
        {
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("nid", MySqlDbType.Int24);
            pms[0].Value = id;
            pms[1] = new MySqlParameter("ndata", MySqlDbType.Date);
            pms[1].Value = datetostr(data);

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "limpar_dia";
            cmd.Parameters.AddRange(pms);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<int> getdia (int id, DateTime data)
        {
            List<int> res = new List<int>();
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("nid", MySqlDbType.Int24);
            pms[0].Value = id;
            pms[1] = new MySqlParameter("ndata", MySqlDbType.Date);
            pms[1].Value = datetostr(data);

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "get_dia";
            cmd.Parameters.AddRange(pms);

            MySqlDataReader reader = cmd.ExecuteReader();
            int aux;
            while (reader.Read())
            {
                aux = (int)reader["Receita"];
                res.Add(aux);
            }
            conn.Close();
            if (res.Count == 0) return null;
            return res;
        }


    }
}
