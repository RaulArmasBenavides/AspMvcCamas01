using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
//Conectarme a base de datos SQL Server
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace Capa_Datos
{
    public class TipoHabitacionDAL:CadenaDAL
    {
        /*
    public List<TipoHabitacionCLS> listarTipoHabitacion()
    {
        List<TipoHabitacionCLS> lista = new List<TipoHabitacionCLS>();
        lista.Add(new TipoHabitacionCLS
        {
            id = 1,
            nombre = "Simple",
            descripcion = "Solo para uno"
        });
        lista.Add(new TipoHabitacionCLS
        {
            id = 2,
            nombre = "Doble",
            descripcion = "Hecho para casados"
        });

        return lista;
    }*/
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = null;
          //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn=new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoHabitacion", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd= cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.GetString(posDescripcion);
                                lista.Add(oTipoHabitacionCLS);
                            }
                        }

                    }
                       
                    //Cierro una vez de traer la data
                   cn.Close(); 
                }
                catch(Exception ex)
                {
                    cn.Close();
                }
               
            }
            return lista;


        }



        public TipoHabitacionCLS recuperarTipoHabitacion(int id)
        {
            TipoHabitacionCLS oTipoHabitacionCLS=null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoHabitacion", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                                                    
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.GetString(posDescripcion);
                              
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
            return oTipoHabitacionCLS;


        }


        public int guardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            //error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarTipohabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oTipoHabitacion.id);
                        cmd.Parameters.AddWithValue("@nombre", oTipoHabitacion.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoHabitacion.descripcion);
                        rpta= cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                catch(Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }

             }

            return rpta;

       }



        public int  eliminarTipoHabitacion(int iidtipohabitacion)
        {
            //error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidtipohabitacion);
                   
                        rpta = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }

            }

            return rpta;

        }







        public List<TipoHabitacionCLS> filtrarTipoHabitacion(string nombrehabitacion)
        {
            List<TipoHabitacionCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspFiltarTipoHabitacion", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombrehabitacion", nombrehabitacion);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.GetString(posDescripcion);
                                lista.Add(oTipoHabitacionCLS);
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
