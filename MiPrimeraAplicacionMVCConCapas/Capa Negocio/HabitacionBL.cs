using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
  public  class HabitacionBL
    {

        public List<HabitacionCLS> recuperarHabitacionPorIdHotel(int iidhotel)
		{
            HabitacionDAL obj = new HabitacionDAL();
            return obj.recuperarHabitacionPorIdHotel(iidhotel);
        }
        public int guardarHabitacion(HabitacionCLS oHabitacionCLS)
        {
            HabitacionDAL obj = new HabitacionDAL();
            return obj.guardarHabitacion(oHabitacionCLS);
        }
        public HabitacionCLS recuperarHabitacion(int idhabitacion)
        {
            HabitacionDAL obj = new HabitacionDAL();
            return obj.recuperarHabitacion(idhabitacion);
        }
        public HabitacionListCLS listarHabitacionList()
        {

            HabitacionDAL obj = new HabitacionDAL();
            return obj.listarHabitacionList();
        }


    }
}
