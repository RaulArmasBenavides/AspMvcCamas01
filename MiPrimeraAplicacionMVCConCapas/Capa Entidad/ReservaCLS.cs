using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
	public class ReservaCLS
	{
		public int iidhabitacion { get; set; }
		public DateTime fechainicio { get; set; }
		public DateTime fechafin { get; set; }
		public int cantidadnoches { get; set; }
		public decimal preciohabitacion { get; set; }
		public decimal total { get; set; }
		public int iidhotel { get; set; }
		public int iidusuario { get; set; }


	}
}
