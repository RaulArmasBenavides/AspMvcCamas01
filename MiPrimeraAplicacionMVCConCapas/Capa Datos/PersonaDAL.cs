using Capa_Entidad;
using Capa_Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
  public  class PersonaDAL:CadenaDAL
    {


        public PersonaCLS uspLogin(string usuario,string contra)
		{
            PersonaCLS oPersonaCLS = null;
            using (SqlConnection cn = new SqlConnection(cadena))
			{
				try
				{
                    string contracifrado= GenericLH.cifrarCadena(contra);
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspLogin",
					   cn))
					{
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreusuario", "RARMAS");
                        cmd.Parameters.AddWithValue("@contra", "123456");
                        SqlDataReader drd = cmd.ExecuteReader();
						if (drd != null)
						{
                            oPersonaCLS = new PersonaCLS();
                            int posNombreFoto = drd.GetOrdinal("NOMBREFOTO");
                            int posFoto = drd.GetOrdinal("FOTO");
                            while (drd.Read())
							{
                                oPersonaCLS.iidusuario= drd.IsDBNull(0) ? 0 :
                                    drd.GetInt32(0);
                                oPersonaCLS.nombreCompleto = drd.IsDBNull(1) ? "" :
                                  drd.GetString(1);
                                oPersonaCLS.iidtipousuario = drd.IsDBNull(2) ? 0 :
                                   drd.GetInt32(2);
                                oPersonaCLS.nombrefoto = drd.IsDBNull(posNombreFoto) ? "" :
                                  drd.GetString(posNombreFoto);
                                if (!drd.IsDBNull(posFoto))
                                {
                                    string nomfoto = oPersonaCLS.nombrefoto;
                                    //.jpg .png
                                    string extension = Path.GetExtension(nomfoto);
                                    //string nombresinextension = extension.Substring(1);
                                    //byte[] fotobyte = (byte[])drd.GetValue(posFoto);
                                    ////mime  data:image/formato;base64,
                                    //// data:image/jpg;base64,
                                    //// data:image/png;base64,
                                    //// data:image/jpeg;base64,
                                    //string mime = "data:image/" + nombresinextension + ";base64,";
                                    //string fotobase = Convert.ToBase64String(fotobyte);
                                    //oPersonaCLS.fotobase64 = mime + fotobase;

                                }
                            }

                        }
                    }
                }
                catch(Exception ex)
				{
                    oPersonaCLS = null;
                }
               
            }
            return oPersonaCLS;
        }

        public PersonaCLS recuperarPersona(int iidpersona)
        {
            PersonaCLS oPersonaCLS=null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarPersona",
                        cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idpersona", iidpersona);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            
                           
                            int posIdpersona = drd.GetOrdinal("IIDPERSONA");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posAppaterno = drd.GetOrdinal("APPATERNO");
                            int posApmaterno = drd.GetOrdinal("APMATERNO");
                            int posTelefono = drd.GetOrdinal("TELEFONOFIJO");
                            int posidsexo = drd.GetOrdinal("IIDSEXO");
                            int posiidusuario = drd.GetOrdinal("IIDTIPOUSUARIO");
                            int posNombreFoto = drd.GetOrdinal("NOMBREFOTO");
                            int posFoto = drd.GetOrdinal("FOTO");
                            int posIidusuario = drd.GetOrdinal("IIDUSUARIO");
                            int posNombreUsuario = drd.GetOrdinal("NOMBREUSUARIO");


                            while (drd.Read())
                            {
                                oPersonaCLS = new PersonaCLS();
                                oPersonaCLS.iidpersona = drd.IsDBNull(posIdpersona) ? 0 :
                                    drd.GetInt32(posIdpersona);
                                oPersonaCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oPersonaCLS.apellidopaterno = drd.IsDBNull(posAppaterno) ? ""
                                    : drd.GetString(posAppaterno);
                                oPersonaCLS.apellidomaterno = drd.IsDBNull(posApmaterno) ? ""
                                  : drd.GetString(posApmaterno);
                                oPersonaCLS.telefono = drd.IsDBNull(posTelefono) ? ""
                                  : drd.GetString(posTelefono);
                                oPersonaCLS.iidsexo = drd.IsDBNull(posidsexo) ? 0 :
                                    drd.GetInt32(posidsexo);
                                oPersonaCLS.iidtipousuario = drd.IsDBNull(posiidusuario) ? 0 :
                                  drd.GetInt32(posiidusuario);
                                oPersonaCLS.nombrefoto = drd.IsDBNull(posNombreFoto) ? "" :
                            drd.GetString(posNombreFoto);
                                if (!drd.IsDBNull(posFoto))
                                {
                                    string nomfoto = oPersonaCLS.nombrefoto;
                                    //.jpg .png
                                    string extension = Path.GetExtension(nomfoto);
                                    string nombresinextension = extension.Substring(1);
                                    byte[] fotobyte = (byte[])drd.GetValue(posFoto);
                                    //mime  data:image/formato;base64,
                                    // data:image/jpg;base64,
                                    // data:image/png;base64,
                                    // data:image/jpeg;base64,
                                    string mime = "data:image/" + nombresinextension + ";base64,";
                                    string fotobase = Convert.ToBase64String(fotobyte);
                                    oPersonaCLS.fotobase64 = mime + fotobase;

                                }
                                oPersonaCLS.iidusuario = drd.IsDBNull(posIidusuario) ? 0 :
                                 drd.GetInt32(posIidusuario);
                                oPersonaCLS.nombreusuario = drd.IsDBNull(posNombreUsuario) ? "" :
                                drd.GetString(posNombreUsuario);


                            }
                            //Viene el detalle (Para ver si hay otro select abajo)
                            if (drd.NextResult())
                            {
                                oPersonaCLS.valor = new List<int>();
                                while (drd.Read())
                                {
                                    oPersonaCLS.valor.Add(drd.GetInt32(0));
                                }
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
            return oPersonaCLS;


        }

        public int eliminarPersona(int iidpersona)
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
                    using (SqlCommand cmd = new SqlCommand("uspEliminarPersona", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idpersona", iidpersona);
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
        //Comienza como 0
        public int guardarPersona(PersonaCLS oPersonaCLS,UsuarioCLS oUsuarioCLS)
        {
            int rpta = 0;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    using(SqlTransaction transaccion= cn.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand("uspGuardarPersona", cn, transaccion))
                        {
                            //Buena practica (Opcional)->Indicamos que es un procedure
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@iidpersona", oPersonaCLS.iidpersona);
                            cmd.Parameters.AddWithValue("@nombre", oPersonaCLS.nombre);
                            cmd.Parameters.AddWithValue("@appaterno", oPersonaCLS.apellidopaterno);
                            cmd.Parameters.AddWithValue("@apmaterno", oPersonaCLS.apellidomaterno);
                            cmd.Parameters.AddWithValue("@telefonofijo", oPersonaCLS.telefono);
                            cmd.Parameters.AddWithValue("@iidsexo", oPersonaCLS.iidsexo);
                            cmd.Parameters.AddWithValue("@iidtipousuario", oPersonaCLS.iidtipousuario);

                            cmd.Parameters.AddWithValue("@foto",
                                oPersonaCLS.foto == null ? System.Data.SqlTypes.SqlBinary.Null
                                : oPersonaCLS.foto);
                            cmd.Parameters.AddWithValue("@nombrefoto",
                                oPersonaCLS.nombrefoto == null ? "" : oPersonaCLS.nombrefoto);
                            //Nuevo
                            SqlParameter parametro=null;
                            if (oPersonaCLS.iidpersona == 0)
                            {
                                parametro = cmd.Parameters.Add("@@identity", SqlDbType.Int);
                                parametro.Direction = ParameterDirection.ReturnValue;
                            }

                            rpta = cmd.ExecuteNonQuery();
                            //Solo en agregar
                            if (oPersonaCLS.iidpersona == 0)
                            {
                                oPersonaCLS.iidpersona = (int)parametro.Value;
                            }

                        }
                        using (SqlCommand cmd = new SqlCommand("uspEliminarGustos", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idpersona", oPersonaCLS.iidpersona);
                            cmd.ExecuteNonQuery();
                        }
                        for(int i=0;i < oPersonaCLS.valor.Count;i++)
                        {
                            using (SqlCommand cmd = new SqlCommand("uspAgregarHabilitarGusto", cn, transaccion))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@idpersona", oPersonaCLS.iidpersona);
                                cmd.Parameters.AddWithValue("@idgusto", oPersonaCLS.valor[i]);
                                cmd.ExecuteNonQuery();
                            }

                        }

                        using (SqlCommand cmd = new SqlCommand("uspGuardarUsuario", cn, transaccion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@iidusuario", oUsuarioCLS.iidusuario);
                            cmd.Parameters.AddWithValue("@nombreusuario", oUsuarioCLS.nombreusuario);
                            cmd.Parameters.AddWithValue("@contra", "123456");
                            //cmd.Parameters.AddWithValue("@contra", GenericLH.cifrarCadena(oUsuarioCLS.contra));
                            cmd.Parameters.AddWithValue("@iidpersona", oPersonaCLS.iidpersona);


                            rpta=cmd.ExecuteNonQuery();
                        }

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


        public List<PersonaCLS> filtrarPersona(int iidtipousuario)
        {
            List<PersonaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarPersonaPorTipoUsuario",
                        cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idtipousuario", iidtipousuario);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<PersonaCLS>();
                            PersonaCLS oPersonaCLS;
                            int posIdpersona = drd.GetOrdinal("IIDPERSONA");
                            int posNombreCompleto = drd.GetOrdinal("NOMBRECOMPLETO");
                            int posNombreSexo = drd.GetOrdinal("NOMBRESEXO");
                            int posNombreTipousuario = drd.GetOrdinal("NOMBRETIPOUSUARIO");
                            while (drd.Read())
                            {
                                oPersonaCLS = new PersonaCLS();
                                oPersonaCLS.iidpersona = drd.IsDBNull(posIdpersona) ? 0 :
                                    drd.GetInt32(posIdpersona);
                                oPersonaCLS.nombreCompleto = drd.IsDBNull(posNombreCompleto) ? ""
                                    : drd.GetString(posNombreCompleto);
                                oPersonaCLS.nombreSexo = drd.IsDBNull(posNombreSexo) ? ""
                                    : drd.GetString(posNombreSexo);
                                oPersonaCLS.nombreTipoUsuario = drd.IsDBNull(posNombreTipousuario) ? ""
                                  : drd.GetString(posNombreTipousuario);
                                lista.Add(oPersonaCLS);
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


        public List<PersonaCLS> listarPersona(string fotofinal)
        {
            List<PersonaCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarPersona", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<PersonaCLS>();
                            PersonaCLS oPersonaCLS;
                            int posIdpersona = drd.GetOrdinal("IIDPERSONA");
                            int posNombreCompleto = drd.GetOrdinal("NOMBRECOMPLETO");
                            int posNombreSexo = drd.GetOrdinal("NOMBRESEXO");
                            int posNombreTipousuario = drd.GetOrdinal("NOMBRETIPOUSUARIO");
                            int posFoto = drd.GetOrdinal("FOTO");
                            int posNombreFoto = drd.GetOrdinal("NOMBREFOTO");
                            while (drd.Read())
                            {
                                oPersonaCLS = new PersonaCLS();
                                oPersonaCLS.iidpersona = drd.IsDBNull(posIdpersona) ? 0 :
                                    drd.GetInt32(posIdpersona);
                                oPersonaCLS.nombreCompleto = drd.IsDBNull(posNombreCompleto) ? ""
                                    : drd.GetString(posNombreCompleto);
                                oPersonaCLS.nombreSexo = drd.IsDBNull(posNombreSexo) ? ""
                                    : drd.GetString(posNombreSexo);
                                oPersonaCLS.nombreTipoUsuario = drd.IsDBNull(posNombreTipousuario) ? ""
                                  : drd.GetString(posNombreTipousuario);
                                oPersonaCLS.nombrefoto = drd.IsDBNull(posNombreFoto) ? "" :
                                            drd.GetString(posNombreFoto);
                                if (!drd.IsDBNull(posFoto))
                                {
                                    string nomfoto = oPersonaCLS.nombrefoto;
                                    //.jpg .png
                                    string extension = Path.GetExtension(nomfoto);
                                    string nombresinextension = extension.Substring(1);
                                    byte[] fotobyte = (byte[])drd.GetValue(posFoto);
                                    //mime  data:image/formato;base64,
                                    // data:image/jpg;base64,
                                    // data:image/png;base64,
                                    // data:image/jpeg;base64,
                                    string mime = "data:image/" + nombresinextension + ";base64,";
                                    string fotobase = Convert.ToBase64String(fotobyte);
                                    oPersonaCLS.fotobase64 = mime + fotobase;

                                }
                                else {
                                    oPersonaCLS.fotobase64 = fotofinal;
                                }
                                lista.Add(oPersonaCLS);
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
