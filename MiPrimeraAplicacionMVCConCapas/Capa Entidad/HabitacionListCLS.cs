using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{ 
    //listado total
    public class HabitacionListCLS
    {
        public List<HabitacionCLS> listaHabitacion { get; set; }
        public List<TipoHabitacionCLS> listaTipoHabitacion { get; set; }
        public List<CamaCLS> listaCama { get; set; }
        public List<HotelCLS> listaHotel { get; set; }
    }
}
