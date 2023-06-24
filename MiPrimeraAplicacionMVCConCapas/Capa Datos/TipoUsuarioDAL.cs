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
   public  class TipoUsuarioDAL:CadenaDAL
    {

        public TipoUsuarioCLS recuperarTipousuario(int iidtipousuario)
        {
            TipoUsuarioCLS oTipoUsuarioCLS = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoUsuario",
                        cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idtipousuario", iidtipousuario);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {


                            int posIdtipousuario = drd.GetOrdinal("IIDTIPOUSUARIO");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
       

                            while (drd.Read())
                            {
                                oTipoUsuarioCLS = new TipoUsuarioCLS();
                                oTipoUsuarioCLS.iidtipousuario = drd.IsDBNull(posIdtipousuario) ? 0 :
                                    drd.GetInt32(posIdtipousuario);
                                oTipoUsuarioCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oTipoUsuarioCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);


                                }


                            }
                            //Viene el detalle (Para ver si hay otro select abajo)
                            if (drd.NextResult())
                            {
                            oTipoUsuarioCLS.idpaginas = new List<int>();
                                while (drd.Read())
                                {
                                oTipoUsuarioCLS.idpaginas.Add(drd.GetInt32(0));
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
            return oTipoUsuarioCLS;


        }

        public int guardarTipousuario(TipoUsuarioCLS oTipoUsuarioCLS)
        {
            int rpta = 0;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    // +100 (Ok)
                    // -100 (Falla)  -> Proceso anula
                    using (SqlTransaction transaccion = cn.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand("uspGuardarTipousuario", cn, transaccion))
                        {
                            //Buena practica (Opcional)->Indicamos que es un procedure
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idtipousuario", oTipoUsuarioCLS.iidtipousuario);
                            cmd.Parameters.AddWithValue("@nombre", oTipoUsuarioCLS.nombre);
                            cmd.Parameters.AddWithValue("@descripcion", oTipoUsuarioCLS.descripcion);

                            SqlParameter parametro = null;
                            if (oTipoUsuarioCLS.iidtipousuario == 0)
                            {
                                parametro = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                                parametro.Direction = ParameterDirection.ReturnValue;
                            }
                            rpta = cmd.ExecuteNonQuery();
                            if (oTipoUsuarioCLS.iidtipousuario == 0)
                            {
                                //Ya vamos a tener el id
                                oTipoUsuarioCLS.iidtipousuario = (int)parametro.Value;
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand("uspDeshabilitarPaginasTipousuario", cn, transaccion))
                        {
                            //Buena practica (Opcional)->Indicamos que es un procedure
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idtipousuario", oTipoUsuarioCLS.iidtipousuario);

                            rpta = cmd.ExecuteNonQuery();
                        }

                        for (int i = 0; i < oTipoUsuarioCLS.idpaginas.Count; i++)
                        {
                            using (SqlCommand cmd = new SqlCommand("uspGuardarPaginasTipousuario", cn, transaccion))
                            {
                                //Buena practica (Opcional)->Indicamos que es un procedure
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@idtipousuario", oTipoUsuarioCLS.iidtipousuario);
                                cmd.Parameters.AddWithValue("@idpagina", oTipoUsuarioCLS.idpaginas[i]);
                                rpta = cmd.ExecuteNonQuery();
                            }
                        }
                        //Recien ejecuta
                        transaccion.Commit();
                    }
                    //Llame al procedure
               



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

        public List<TipoUsuarioCLS> listarTipoUsuario()
        {
            List<TipoUsuarioCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoUsuario", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<TipoUsuarioCLS>();
                            TipoUsuarioCLS oTipoUsuarioCLS;
                            int posId = drd.GetOrdinal("IIDTIPOUSUARIO");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDescripcion = drd.GetOrdinal("DESCRIPCION");
                            while (drd.Read())
                            {
                                oTipoUsuarioCLS = new TipoUsuarioCLS();
                                oTipoUsuarioCLS.iidtipousuario = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oTipoUsuarioCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oTipoUsuarioCLS.descripcion = drd.IsDBNull(posDescripcion) ? ""
                                    : drd.GetString(posDescripcion);
                                lista.Add(oTipoUsuarioCLS);
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
