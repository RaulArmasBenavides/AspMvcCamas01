using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class HabitacionCLS
    {
        public int iidhabitacion { get; set; }
        public string nombre { get; set; }
        public decimal precionoche { get; set; }
        public int numeropersonas { get; set; }
        //Texto mostrar en la lista
        public string textotienepiscina { get; set; }
        public string textotienewifi { get; set; }
        public string textotienevistaalmar { get; set; }
        public int iidtipohabitacion { get; set; }
        public int iidcama { get; set; }
        public int iidhotel { get; set; }
        public string descripcion { get; set; }
        //Names para guardar
        public int tienepiscina { get; set; }
        public int tienewifi { get; set; }
        public int tienevistaalmar { get; set; }
    }
}
