using System;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba_tecnica.Models
{
    public class GestorGiro
    {
        public List<GIROS> getGiro()
        {
            List<GIROS> lista = new List<GIROS>();
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GIROS_All";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    int gir_ciudad_id = dr.GetInt32(2);


                    GIROS giro = new GIROS(id, nombre, gir_ciudad_id);

                    lista.Add(giro);
                }

                dr.Close();
                conn.Close();
            }

            return lista;
        }


        public bool addGiro(GIROS giro)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "GIROS_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GIR_RECIBO", giro.GIR_RECIBO);
                cmd.Parameters.AddWithValue("@GIR_CIUDAD_ID", giro.GIR_CIUDAD_ID);


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
        public bool updateGiro(int id, GIROS giro)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "GIROS_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GIR_GIRO_ID", id);
                cmd.Parameters.AddWithValue("@GIR_RECIBO", giro.GIR_RECIBO);
                cmd.Parameters.AddWithValue("@GIR_CIUDAD_ID", giro.GIR_CIUDAD_ID);


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
        public bool deleteGiro(int id)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "GIROS_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@GIR_GIRO_ID", id);

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

        // obtener giro por ciudad consultada
        public static IEnumerable<GIROS> GetGirosById(int GIR_CIUDAD_ID)
        {
            GIROS giro = new GIROS();
            //using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                using (var command = new SqlCommand("usp_obtenerGiroPorCiudad", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@GIR_CIUDAD_ID", GIR_CIUDAD_ID);

                    using (var reader = command.ExecuteReader())
                    {
                        var articles = new List<GIROS>();

                        while (reader.Read())
                        {
                            var article = new GIROS
                            {

                                GIR_GIRO_ID = (int)reader["GIR_GIRO_ID"],
                                GIR_RECIBO = (string)reader["GIR_RECIBO"],
                                GIR_CIUDAD_ID = (int)reader["GIR_CIUDAD_ID"],


                            };

                            articles.Add(article);
                        }

                        return articles;
                    }
                }
            }
        }




    }
}