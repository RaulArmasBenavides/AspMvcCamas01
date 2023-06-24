using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
   public class MarcaDAL:CadenaDAL
    {

        public List<MarcaCLS> filtrarMarca(string nombremarca)
        {
            List<MarcaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarMarca", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombremarca);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<MarcaCLS>();
                            MarcaCLS oMarcaCLS;
                            int posId = drd.GetOrdinal("IIDMARCA");
                            int posNombre = drd.GetOrdinal("NOMBREMARCA");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oMarcaCLS = new MarcaCLS();
                                oMarcaCLS.iidMarca = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oMarcaCLS.nombreMarca = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oMarcaCLS.descripcionMarca = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);
                                lista.Add(oMarcaCLS);
                            }
                        }

                    }

                    //Cierro una vez de traer la data
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return lista;


        }



        public int eliminarMarca(int iidmarca)
        {
            int rpta = 0;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspEliminarMarca", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidmarca);
                        rpta=  cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                    //Cierro una vez de traer la data
                   
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return rpta;


        }

        public int guardarMarca(MarcaCLS oMarcaCLS)
        {
            int rpta = 0;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspGuardarMarca", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oMarcaCLS.iidMarca);
                        cmd.Parameters.AddWithValue("@nombre", oMarcaCLS.nombreMarca);
                        cmd.Parameters.AddWithValue("@descripcion", oMarcaCLS.descripcionMarca);
                        rpta = cmd.ExecuteNonQuery();
                    }

                    //Cierro una vez de traer la data
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return rpta;


        }


        public MarcaCLS recuperarMarca(int iidmarca)
        {
            MarcaCLS oMarcaCLS=null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarMarca", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidmarca);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                         
                          
                            int posId = drd.GetOrdinal("IIDMARCA");
                            int posNombre = drd.GetOrdinal("NOMBREMARCA");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oMarcaCLS = new MarcaCLS();
                                oMarcaCLS.iidMarca = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oMarcaCLS.nombreMarca = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oMarcaCLS.descripcionMarca = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);
                              
                            }
                        }

                    }

                    //Cierro una vez de traer la data
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return oMarcaCLS;


        }


        public List<MarcaCLS> listarMarca()
        {
            List<MarcaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarMarca", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<MarcaCLS>();
                            MarcaCLS oMarcaCLS;
                            int posId = drd.GetOrdinal("IIDMARCA");
                            int posNombre = drd.GetOrdinal("NOMBREMARCA");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oMarcaCLS = new MarcaCLS();
                                oMarcaCLS.iidMarca = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oMarcaCLS.nombreMarca = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oMarcaCLS.descripcionMarca = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);
                                lista.Add(oMarcaCLS);
                            }
                        }

                    }

                    //Cierro una vez de traer la data
                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return lista;


        }

    }
}
