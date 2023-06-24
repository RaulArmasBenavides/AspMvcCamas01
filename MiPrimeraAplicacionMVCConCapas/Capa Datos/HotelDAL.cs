using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace Capa_Datos
{
   public class HotelDAL:CadenaDAL
    {


        public int guardarHotel(HotelCLS oHotelCLS)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarHotel", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idhotel", oHotelCLS.iidhotel);
                        cmd.Parameters.AddWithValue("@nombre", oHotelCLS.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oHotelCLS.descripcion);
                        //@iidestado
                        cmd.Parameters.AddWithValue("@direccion", oHotelCLS.direccion);
                        cmd.Parameters.AddWithValue("@nombreArchivo",
                            oHotelCLS.nombrearchivo==null? "" :
                          oHotelCLS.nombrearchivo);
                        if (oHotelCLS.nombrearchivo != null)
                        {
                            File.WriteAllBytes(
                                Path.Combine( oHotelCLS.rutaGuardar, oHotelCLS.nombrearchivo), 
                                oHotelCLS.foto);
                        }
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

        public HotelCLS recuperarHotel(int iidhotel, string rutaFile)
        {
            HotelCLS oHotelCLS = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarHotel",
                        cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidhotel", iidhotel);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {


                            int posIIDHOTEL = drd.GetOrdinal("IIDHOTEL");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDESCRIPCION = drd.GetOrdinal("DESCRIPCION");
                            int posDIRECCION = drd.GetOrdinal("DIRECCION");
                            int posNOMBREARCHIVO = drd.GetOrdinal("NOMBREARCHIVO");


                            while (drd.Read())
                            {
                                oHotelCLS = new HotelCLS();
                                oHotelCLS.iidhotel = drd.IsDBNull(posIIDHOTEL) ? 0 :
                                    drd.GetInt32(posIIDHOTEL);
                                oHotelCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oHotelCLS.descripcion = drd.IsDBNull(posDESCRIPCION) ? ""
                                    : drd.GetString(posDESCRIPCION);
                                oHotelCLS.direccion = drd.IsDBNull(posDIRECCION) ? ""
                                  : drd.GetString(posDIRECCION);

                                oHotelCLS.nombrearchivo = drd.IsDBNull(posNOMBREARCHIVO) ? "" :
                            drd.GetString(posNOMBREARCHIVO);

                                string nombrearchivo = oHotelCLS.nombrearchivo;
                                string rutacompleta = Path.Combine(rutaFile, nombrearchivo);
                                byte[] buffer = File.ReadAllBytes(rutacompleta);
                                //.jpg .png
                                string extension = Path.GetExtension(oHotelCLS.nombrearchivo);
                                string nombresinextension = extension.Substring(1);
                                string mime = "data:image/" + nombresinextension + ";base64,";

                                oHotelCLS.fotobase64 = mime+Convert.ToBase64String(buffer);



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
            return oHotelCLS;


        }


        public List<HotelCLS> listarHotel(string ruta)
        {
            List<HotelCLS> lista = null;
            //  string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString; 
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarHotel", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<HotelCLS>();
                            HotelCLS oHotelCLS;
                            int posId = drd.GetOrdinal("IIDHOTEL");
                            int posNombre = drd.GetOrdinal("NOMBRE");
                            int posDireccion = drd.GetOrdinal("DIRECCION");
                            int posNombrefoto = drd.GetOrdinal("NOMBREARCHIVO");
                            while (drd.Read())
                            {
                                oHotelCLS = new HotelCLS();
                                oHotelCLS.iidhotel = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oHotelCLS.nombre = drd.IsDBNull(posNombre) ? ""
                                    : drd.GetString(posNombre);
                                oHotelCLS.direccion = drd.IsDBNull(posDireccion) ? ""
                                    : drd.GetString(posDireccion);
                                oHotelCLS.nombrearchivo = drd.IsDBNull(posNombrefoto) ? ""
                                    : drd.GetString(posNombrefoto);
                                //No hay
                                if (oHotelCLS.nombrearchivo == "")
                                {
                                    string mime = "data:image/png;base64,";
                                    string rutaA = Path.Combine(ruta, "nofoto.png");
                                    byte[] archivoByte = File.ReadAllBytes(rutaA);
                                    string archivoBase = Convert.ToBase64String(archivoByte);
                                    oHotelCLS.fotobase64 = mime+archivoBase;

                                }
                                //si hay
                                else
                                {
                                    string extension = Path.GetExtension(oHotelCLS.nombrearchivo);
                                    string nombresinextension = extension.Substring(1);
                                    string rutaArchivo= Path.Combine(ruta, oHotelCLS.nombrearchivo);
                                    byte[] archivoByte = File.ReadAllBytes(rutaArchivo);
                                    string archivoBase = Convert.ToBase64String(archivoByte);
                                    string mime = "data:image/" + nombresinextension + ";base64,";
                                    oHotelCLS.fotobase64 = mime + archivoBase;

                                }

                                lista.Add(oHotelCLS);
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
