using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba_tecnica.Models
{
    public class GestorPais
    {
        public List<PAISES> getPais()
        {
            List<PAISES> lista = new List<PAISES>();
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "PAISES_All";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                   

                    PAISES pais = new PAISES(id, nombre);

                    lista.Add(pais);
                }

                dr.Close();
                conn.Close();
            }

            return lista;
        }

        public bool addPais(PAISES pais)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "PAISES_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", pais.nombre);
             

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }
        public bool updatePais(int id, PAISES pais)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "PAISES_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_pais", id);
                cmd.Parameters.AddWithValue("@nombre", pais.nombre);
               

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }


        public bool deletePais(int id)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "PAISES_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_pais", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }
    }

}
