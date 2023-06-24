using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capa_Datos;
using Capa_Entidad;

public class CamaDAL:CadenaDAL
    {

    public CamaCLS recuperarCamaPorId(int id)
    {
        CamaCLS oCamaCLS=null;
        //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
        using (SqlConnection cn = new SqlConnection(cadena))
        {
            try
            {
                //Abro la conexion
                cn.Open();
                //Llame al procedure
                using (SqlCommand cmd = new SqlCommand("uspRecuperarCama", cn))
                {
                    //Buena practica (Opcional)->Indicamos que es un procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",id);
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd != null)
                    {
                      
                        
                        int posId = drd.GetOrdinal("IIDCAMA");
                        int posNombre = drd.GetOrdinal("NOMBRE");
                        int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                        int posIidestado = drd.GetOrdinal("IIDESTADO");

                        while (drd.Read())
                        {
                            oCamaCLS = new CamaCLS();
                            oCamaCLS.idcama = drd.IsDBNull(posId) ? 0 :
                                drd.GetInt32(posId);
                            oCamaCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                : drd.GetString(posNombre);
                            oCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                : drd.GetString(posDescripcion);
                            oCamaCLS.iidestado = drd.IsDBNull(posIidestado) ? 0
                       : drd.GetInt32(posIidestado);

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
        return oCamaCLS;


    }



    public List<CamaCLS> listarCama()
        {
            List<CamaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarCama", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");

                        while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                            oCamaCLS.idcama = drd.IsDBNull(posId) ? 0:
                                drd.GetInt32(posId);
                            oCamaCLS.nombre = drd.IsDBNull(posNombre)?""
                                : drd.GetString(posNombre);
                            oCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? "" 
                                :drd.GetString(posDescripcion);
                      
                            lista.Add(oCamaCLS);
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



    public int eliminarCama(int iidcama)
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
                using (SqlCommand cmd = new SqlCommand("uspEliminarCama", cn))
                {
                    //Buena practica (Opcional)->Indicamos que es un procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", iidcama);
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

    public int guardarCama(CamaCLS oCamaCLS)
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
                using (SqlCommand cmd = new SqlCommand("uspGuardarCama", cn))
                {
                    //Buena practica (Opcional)->Indicamos que es un procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", oCamaCLS.idcama);
                    cmd.Parameters.AddWithValue("@nombre", oCamaCLS.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", oCamaCLS.descripcion);
                    //@iidestado
                    cmd.Parameters.AddWithValue("@iidestado", oCamaCLS.iidestado);
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


    public List<CamaCLS> filtrarCama(string nombrecama)
    {
        List<CamaCLS> lista = null;
        //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
        using (SqlConnection cn = new SqlConnection(cadena))
        {
            try
            {
                //Abro la conexion
                cn.Open();
                //Llame al procedure
                using (SqlCommand cmd = new SqlCommand("uspFiltarCama", cn))
                {
                    //Buena practica (Opcional)->Indicamos que es un procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombrecama", nombrecama);
                    SqlDataReader drd = cmd.ExecuteReader();
                    if (drd != null)
                    {
                        lista = new List<CamaCLS>();
                        CamaCLS oCamaCLS;
                        int posId = drd.GetOrdinal("IIDCAMA");
                        int posNombre = drd.GetOrdinal("NOMBRE");
                        int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                        while (drd.Read())
                        {
                            oCamaCLS = new CamaCLS();
                            oCamaCLS.idcama = drd.IsDBNull(posId) ? 0 :
                                drd.GetInt32(posId);
                            oCamaCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                : drd.GetString(posNombre);
                            oCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                : drd.GetString(posDescripcion);
                            lista.Add(oCamaCLS);
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

