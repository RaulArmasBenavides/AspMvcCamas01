using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;
namespace Capa_Negocio
{
   public class HotelBL
    {
        public HotelCLS recuperarHotel(int iidhotel,string rutaFile)
		{
            HotelDAL oHotelDAL = new HotelDAL();
            return oHotelDAL.recuperarHotel(iidhotel, rutaFile);
        }
        public List<HotelCLS> listarHotel(string ruta)
        {
            HotelDAL oHotelDAL = new HotelDAL();
            return oHotelDAL.listarHotel(ruta);
        }

        public int guardarHotel(HotelCLS oHotelCLS)
        {
            HotelDAL oHotelDAL = new HotelDAL();
            return oHotelDAL.guardarHotel(oHotelCLS);
        }

    }
}
