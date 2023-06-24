using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Negocio
{
	public class ReservaBL
	{

		public int guardarReserva(ReservaCLS oReservaCLSS)
		{
			ReservaDAL oReservaDAL = new ReservaDAL();
			return oReservaDAL.guardarReserva(oReservaCLSS);
		}
	}
}
