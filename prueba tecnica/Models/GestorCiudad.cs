using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prueba_tecnica.Models
{
    public class GestorCiudad
    {
        public List<CIUDADES> getCiudad()
        {
            List<CIUDADES> lista = new List<CIUDADES>();
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "CIUDADES_All";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    int id_pais = dr.GetInt32(2);



                    CIUDADES ciudad = new CIUDADES(id, nombre, id_pais);

                    lista.Add(ciudad);
                }

                dr.Close();
                conn.Close();
            }

            return lista;
        }
        public bool addCiudad(CIUDADES ciudad)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "CIUDADES_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", ciudad.nombre);
                cmd.Parameters.AddWithValue("@id_pais", ciudad.id_pais);


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


        public bool updateCiudad(int id, CIUDADES ciudad)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "CIUDADES_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_ciudad", id);
                cmd.Parameters.AddWithValue("@nombre", ciudad.nombre);
                cmd.Parameters.AddWithValue("@id_pais", ciudad.id_pais);


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





        public static CIUDADES Obtener(int id_pais)
        {
            CIUDADES ciudad = new CIUDADES();
            //using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_pais", id_pais);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            ciudad = new CIUDADES()
                            {
                                id_ciudad = Convert.ToInt32(dr["id_ciudad"]),
                                nombre = dr["nombre"].ToString(),
                                id_pais = Convert.ToInt32(dr["id_pais"]),

                            };
                        }

                    }



                    return ciudad;
                }
                catch (Exception ex)
                {
                    return ciudad;
                }
            }
        }










        public bool deleteCiudad(int id)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "CIUDADES_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_ciudad", id);

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



        public static IEnumerable<CIUDADES> GetArticlesByName(string nombre)
        {
            CIUDADES ciudad = new CIUDADES();
            //using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                using (var command = new SqlCommand("usp_obtenerpornombre", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", nombre);

                    using (var reader = command.ExecuteReader())
                    {
                        var articles = new List<CIUDADES>();

                        while (reader.Read())
                        {
                            var article = new CIUDADES
                            {

                                id_ciudad = (int)reader["id_ciudad"],
                                nombre = (string)reader["nombre"],
                                id_pais = (int)reader["id_pais"],


                            };

                            articles.Add(article);
                        }

                        return articles;
                    }
                }
            }
        }



        //obtener ciudad por pais
        public static IEnumerable<CIUDADES> GetCiudadesById(int id_pais)
        {
            CIUDADES ciudad = new CIUDADES();
            //using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                using (var command = new SqlCommand("usp_obtener", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id_pais", id_pais);

                    using (var reader = command.ExecuteReader())
                    {
                        var articles = new List<CIUDADES>();

                        while (reader.Read())
                        {
                            var article = new CIUDADES
                            {

                                id_ciudad = (int)reader["id_ciudad"],
                                nombre = (string)reader["nombre"],
                                id_pais = (int)reader["id_pais"],


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