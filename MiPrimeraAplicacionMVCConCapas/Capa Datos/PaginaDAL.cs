using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;
namespace Capa_Datos
{
    public class PaginaDAL:CadenaDAL
    {

        public List<PaginaCLS> listarPagina()
        {
            List<PaginaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarPagina", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<PaginaCLS>();
                            PaginaCLS oPaginaCLS;
                            int posId = drd.GetOrdinal("IIDPAGINA");
                            int posNombre = drd.GetOrdinal("MENSAJE");
                            int poscONTROLLER = drd.GetOrdinal("CONTROLLER");
                            int posACCION = drd.GetOrdinal("ACCION");

                            while (drd.Read())
                            {
                                oPaginaCLS = new PaginaCLS();
                                oPaginaCLS.iidpagina = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oPaginaCLS.mensaje = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oPaginaCLS.controlador = drd.IsDBNull(poscONTROLLER) ? ""
                                   : drd.GetString(poscONTROLLER);
                                oPaginaCLS.accion = drd.IsDBNull(posACCION) ? ""
                                   : drd.GetString(posACCION);

                                lista.Add(oPaginaCLS);
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


        public List<PaginaCLS> listarMenu(int iidtipousuario)
        {
            List<PaginaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarMenu", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidtipousuario", iidtipousuario);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<PaginaCLS>();
                            PaginaCLS oPaginaCLS;
                            int posId = drd.GetOrdinal("IIDPAGINA");
                            int posNombre = drd.GetOrdinal("MENSAJE");
                            int poscONTROLLER = drd.GetOrdinal("CONTROLLER");
                            int posACCION = drd.GetOrdinal("ACCION");

                            while (drd.Read())
                            {
                                oPaginaCLS = new PaginaCLS();
                                oPaginaCLS.iidpagina = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oPaginaCLS.mensaje = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oPaginaCLS.controlador = drd.IsDBNull(poscONTROLLER) ? ""
                                   : drd.GetString(poscONTROLLER);
                                oPaginaCLS.accion = drd.IsDBNull(posACCION) ? ""
                                   : drd.GetString(posACCION);

                                lista.Add(oPaginaCLS);
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

        public int guardarPagina(PaginaCLS oPaginaCLS)
        {
            //error
            //Rpta 0 va a ser error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarPagina", cn))
                    {
                        //Indico que es Procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidpagina", oPaginaCLS.iidpagina);
                        cmd.Parameters.AddWithValue("@mensaje", oPaginaCLS.mensaje);
                        cmd.Parameters.AddWithValue("@controlador", oPaginaCLS.controlador);
                        cmd.Parameters.AddWithValue("@accion", oPaginaCLS.accion);
                        rpta = cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    rpta = 0;
                }


            }
            return rpta;

        }

        public int eliminarPagina(int iidpagina)
        {
            //error
            //Rpta 0 va a ser error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarPagina", cn))
                    {
                        //Indico que es Procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidpagina", iidpagina);
                        rpta = cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    rpta = 0;
                }


            }
            return rpta;

        }

        public PaginaCLS recuperarPagina(int iidpagina)
        {
            PaginaCLS oPaginaCLS = new PaginaCLS();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarPagina", cn))
                    {
                        //Le indico que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidpagina", iidpagina);

                        SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
                        if (drd != null)
                        {

                            int posId = drd.GetOrdinal("IIDPAGINA");
                            int posMensaje = drd.GetOrdinal("MENSAJE");
                            int posControlador = drd.GetOrdinal("CONTROLLER");
                            int posAccion = drd.GetOrdinal("ACCION");
                            while (drd.Read())
                            {

                                oPaginaCLS.iidpagina = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oPaginaCLS.mensaje = drd.IsDBNull(posMensaje) ? "" : drd.GetString(posMensaje);
                                oPaginaCLS.controlador = drd.IsDBNull(posControlador) ? "" : drd.GetString(posControlador);
                                oPaginaCLS.accion = drd.IsDBNull(posAccion) ? "" : drd.GetString(posAccion);
                            }
                            cn.Close();
                        }

                    }

                }
                catch (Exception ex)
                {
                    cn.Close();
                    //null para mi es error
                    oPaginaCLS = null;
                }

            }


            return oPaginaCLS;
        }


      





    }
}
