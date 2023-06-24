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
  public  class CategoriaDAL:CadenaDAL
    {


        public int guardarCategoria(CategoriaCLS oCategoriaCLS)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarCategoria", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idcategoria", oCategoriaCLS.iidcategoria);
                        cmd.Parameters.AddWithValue("@nombre", oCategoriaCLS.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oCategoriaCLS.descripcion);
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


        public int eliminarCategoria(int iidcategoria)
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
                    using (SqlCommand cmd = new SqlCommand("uspEliminarCategoria", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idcategoria", iidcategoria);
                        rpta = cmd.ExecuteNonQuery();
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


        public CategoriaCLS recuperarCategoria(int iidcategoria)
        {
            CategoriaCLS oCategoriaCLS=null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarCategoria", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idcategoria", iidcategoria);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                           
                           
                            int posId = drd.GetOrdinal("iidcategoria");
                            int posNombre = drd.GetOrdinal("nombre");
                            int posDescripcion = drd.GetOrdinal("descripcion");
                            while (drd.Read())
                            {
                                oCategoriaCLS = new CategoriaCLS();
                                oCategoriaCLS.iidcategoria = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oCategoriaCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oCategoriaCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
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
            return oCategoriaCLS;


        }

        public List<CategoriaCLS> listarCategoria()
        {
            List<CategoriaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarCategorias", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CategoriaCLS>();
                            CategoriaCLS oCategoriaCLS;
                            int posId = drd.GetOrdinal("IIDCATEGORIA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oCategoriaCLS = new CategoriaCLS();
                                oCategoriaCLS.iidcategoria = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oCategoriaCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oCategoriaCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);
                                lista.Add(oCategoriaCLS);
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
