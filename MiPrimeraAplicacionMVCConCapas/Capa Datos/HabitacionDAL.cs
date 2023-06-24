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
  public  class HabitacionDAL:CadenaDAL
    {


        public int guardarHabitacion(HabitacionCLS oHabitacionCLS)
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
                    using (SqlCommand cmd = new SqlCommand("uspGuardarHabitacion", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idhabitacion", oHabitacionCLS.iidhabitacion);
                        cmd.Parameters.AddWithValue("@iidtipohabitacion", oHabitacionCLS.iidtipohabitacion);
                        cmd.Parameters.AddWithValue("@iidcama", oHabitacionCLS.iidcama);

                        cmd.Parameters.AddWithValue("@descripcion", oHabitacionCLS.descripcion);
                        cmd.Parameters.AddWithValue("@numero", oHabitacionCLS.numeropersonas);
                        cmd.Parameters.AddWithValue("@precio", oHabitacionCLS.precionoche);
                        cmd.Parameters.AddWithValue("@vistamar", oHabitacionCLS.tienevistaalmar);
                        cmd.Parameters.AddWithValue("@wifi", oHabitacionCLS.tienewifi);
                        cmd.Parameters.AddWithValue("@piscina", oHabitacionCLS.tienepiscina);
                        cmd.Parameters.AddWithValue("@nombre", oHabitacionCLS.nombre);
                        cmd.Parameters.AddWithValue("@iidhotel", oHabitacionCLS.iidhotel);
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


        public HabitacionCLS recuperarHabitacion(int idhabitacion)
        {
            HabitacionCLS oHabitacionCLS = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidhabitacion", idhabitacion);
                        //Captura

                        SqlDataReader drd = cmd.ExecuteReader();
                        int posIIDHABITACION = drd.GetOrdinal("IIDHABITACION");
                        int posNOMBRE = drd.GetOrdinal("NOMBRE");
                        int posPRECIOPORNOCHE = drd.GetOrdinal("PRECIOPORNOCHE");
                        int posNUMEROPERSONAS = drd.GetOrdinal("NUMEROPERSONAS");
                        int posTIENEWIFI = drd.GetOrdinal("TIENEWIFI");
                        int posTIENEVISTAALMAR = drd.GetOrdinal("TIENEVISTAALMAR");
                        int posTIENEPISCINA = drd.GetOrdinal("TIENEPISCINA");
                        int posIIDCAMA = drd.GetOrdinal("IIDCAMA");
                        int posIIDHOTEL = drd.GetOrdinal("IIDHOTEL");
                        int posIIDTIPOHABITACION = drd.GetOrdinal("IIDTIPOHABITACION");
                        int posDESCRIPCION = drd.GetOrdinal("DESCRIPCION");
                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                oHabitacionCLS = new HabitacionCLS();
                                oHabitacionCLS.iidhabitacion = drd.IsDBNull(posIIDHABITACION) ? 0 : drd.GetInt32(posIIDHABITACION);
                                oHabitacionCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oHabitacionCLS.descripcion = drd.IsDBNull(posDESCRIPCION) ? "" : drd.GetString(posDESCRIPCION);
                                oHabitacionCLS.precionoche = drd.IsDBNull(posPRECIOPORNOCHE) ? 0 : drd.GetDecimal(posPRECIOPORNOCHE);
                                oHabitacionCLS.numeropersonas = drd.IsDBNull(posNUMEROPERSONAS) ? 0 : drd.GetInt32(posNUMEROPERSONAS);
                                oHabitacionCLS.tienewifi = drd.IsDBNull(posTIENEWIFI) ? 0 :
                                    drd.GetInt32(posTIENEWIFI);
                                oHabitacionCLS.tienevistaalmar = drd.IsDBNull(posTIENEVISTAALMAR) ? 0 :
                                   drd.GetInt32(posTIENEVISTAALMAR) ;
                                oHabitacionCLS.tienepiscina = drd.IsDBNull(posTIENEPISCINA) ? 0 :
                                 drd.GetInt32(posTIENEPISCINA);
                                oHabitacionCLS.iidcama = drd.IsDBNull(posIIDCAMA) ? 0 :
                              drd.GetInt32(posIIDCAMA);
                                oHabitacionCLS.iidhotel = drd.IsDBNull(posIIDHOTEL) ? 0 :
                            drd.GetInt32(posIIDHOTEL);
                                oHabitacionCLS.iidtipohabitacion = drd.IsDBNull(posIIDTIPOHABITACION) ? 0 :
                              drd.GetInt32(posIIDTIPOHABITACION);

                            }
                          
                        }
                    }
                }
                catch(Exception ex){
                    cn.Close();
                }

            }
            return oHabitacionCLS;
        }


        public List<HabitacionCLS> recuperarHabitacionPorIdHotel(int iidhotel)
        {
            List<HabitacionCLS> listaHabitacion = new List<HabitacionCLS>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarHabitacionPorHotel", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iidhotel", iidhotel);
                        //Captura

                        SqlDataReader drd = cmd.ExecuteReader();
                        int posIIDHABITACION = drd.GetOrdinal("IIDHABITACION");
                        int posNOMBRE = drd.GetOrdinal("NOMBRE");
                        int posPRECIOPORNOCHE = drd.GetOrdinal("PRECIOPORNOCHE");
                        int posNUMEROPERSONAS = drd.GetOrdinal("NUMEROPERSONAS");
                        int posTIENEWIFI = drd.GetOrdinal("TIENEWIFI");
                        int posTIENEVISTAALMAR = drd.GetOrdinal("TIENEVISTAALMAR");
                        int posTIENEPISCINA = drd.GetOrdinal("TIENEPISCINA");
                       
                        HabitacionCLS oHabitacionCLS;
                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                oHabitacionCLS = new HabitacionCLS();
                                oHabitacionCLS.iidhabitacion = drd.IsDBNull(posIIDHABITACION) ? 0 : drd.GetInt32(posIIDHABITACION);
                                oHabitacionCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oHabitacionCLS.precionoche = drd.IsDBNull(posPRECIOPORNOCHE) ? 0 : drd.GetDecimal(posPRECIOPORNOCHE);
                                oHabitacionCLS.numeropersonas = drd.IsDBNull(posNUMEROPERSONAS) ? 0 : drd.GetInt32(posNUMEROPERSONAS);
                                oHabitacionCLS.textotienewifi = drd.IsDBNull(posTIENEWIFI) ? "" :
                                    drd.GetInt32(posTIENEWIFI) == 1 ? "Si" : "No";
                                oHabitacionCLS.textotienevistaalmar = drd.IsDBNull(posTIENEVISTAALMAR) ? "" :
                                   drd.GetInt32(posTIENEVISTAALMAR) == 1 ? "Si" : "No";
                                oHabitacionCLS.textotienepiscina = drd.IsDBNull(posTIENEPISCINA) ? "" :
                                 drd.GetInt32(posTIENEPISCINA) == 1 ? "Si" : "No";
                                listaHabitacion.Add(oHabitacionCLS);

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

            return listaHabitacion;
        }

        public HabitacionListCLS listarHabitacionList()
        {
            HabitacionListCLS oHabitacionListCLS = new HabitacionListCLS();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    //Llame al procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarHabitacionListas", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Captura
                        
                        SqlDataReader drd = cmd.ExecuteReader();
                        int posIIDHABITACION = drd.GetOrdinal("IIDHABITACION");
                        int posNOMBRE = drd.GetOrdinal("NOMBRE");
                        int posPRECIOPORNOCHE = drd.GetOrdinal("PRECIOPORNOCHE");
                        int posNUMEROPERSONAS = drd.GetOrdinal("NUMEROPERSONAS");
                        int posTIENEWIFI = drd.GetOrdinal("TIENEWIFI");
                        int posTIENEVISTAALMAR = drd.GetOrdinal("TIENEVISTAALMAR");
                        int posTIENEPISCINA = drd.GetOrdinal("TIENEPISCINA");
                        List<HabitacionCLS> listaHabitacion = new List<HabitacionCLS>();
                        HabitacionCLS oHabitacionCLS;
                        if (drd != null)
                        {
                            while (drd.Read())
                            {
                                oHabitacionCLS = new HabitacionCLS();
                                oHabitacionCLS.iidhabitacion = drd.IsDBNull(posIIDHABITACION) ? 0 : drd.GetInt32(posIIDHABITACION);
                                oHabitacionCLS.nombre = drd.IsDBNull(posNOMBRE) ? "" : drd.GetString(posNOMBRE);
                                oHabitacionCLS.precionoche = drd.IsDBNull(posPRECIOPORNOCHE) ? 0 : drd.GetDecimal(posPRECIOPORNOCHE);
                                oHabitacionCLS.numeropersonas = drd.IsDBNull(posNUMEROPERSONAS) ? 0 : drd.GetInt32(posNUMEROPERSONAS);
                                oHabitacionCLS.textotienewifi = drd.IsDBNull(posTIENEWIFI) ? "" :
                                    drd.GetInt32(posTIENEWIFI)==1 ? "Si" : "No";
                                oHabitacionCLS.textotienevistaalmar = drd.IsDBNull(posTIENEVISTAALMAR) ? "" :
                                   drd.GetInt32(posTIENEVISTAALMAR) == 1 ? "Si" : "No";
                                oHabitacionCLS.textotienepiscina = drd.IsDBNull(posTIENEPISCINA) ? "" :
                                 drd.GetInt32(posTIENEPISCINA) == 1 ? "Si" : "No";
                                listaHabitacion.Add(oHabitacionCLS);
                              
                            }
                            oHabitacionListCLS.listaHabitacion = listaHabitacion;
                        }
                        if (drd.NextResult())
                        {
                            List<TipoHabitacionCLS> listaTipoHabitacion = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.IsDBNull(0) ? 0 : drd.GetInt32(0);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(1) ? "" : drd.GetString(1);
                                listaTipoHabitacion.Add(oTipoHabitacionCLS);
                            }
                            oHabitacionListCLS.listaTipoHabitacion = listaTipoHabitacion;
                        }

                        if (drd.NextResult())
                        {
                            List<CamaCLS> listaCama = new List<CamaCLS>();
                            CamaCLS oCamaCLS;
                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.idcama = drd.IsDBNull(0) ? 0 : drd.GetInt32(0);
                                oCamaCLS.nombre = drd.IsDBNull(1) ? "" : drd.GetString(1);
                                listaCama.Add(oCamaCLS);
                            }
                            oHabitacionListCLS.listaCama = listaCama;
                        }

                        if (drd.NextResult())
                        {
                            List<HotelCLS> listaHotel = new List<HotelCLS>();
                            HotelCLS oHotelCLS;
                            while (drd.Read())
                            {
                                oHotelCLS = new HotelCLS();
                                oHotelCLS.iidhotel = drd.IsDBNull(0) ? 0 : drd.GetInt32(0);
                                oHotelCLS.nombre = drd.IsDBNull(1) ? "" : drd.GetString(1);
                                listaHotel.Add(oHotelCLS);
                            }
                            oHabitacionListCLS.listaHotel = listaHotel;
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

            return oHabitacionListCLS;
        }


    }
}
