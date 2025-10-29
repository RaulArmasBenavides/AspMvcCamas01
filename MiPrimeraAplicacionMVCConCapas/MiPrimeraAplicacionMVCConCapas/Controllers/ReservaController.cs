using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
namespace BDHotel.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            return View();
        }

        public int guardarReserva(ReservaCLS oReservaCLS)
		{
            int iidusuario= ((PersonaCLS)Session["persona"]).iidusuario;
            oReservaCLS.iidusuario = iidusuario;
            ReservaBL oReservaBL = new ReservaBL();
            return oReservaBL.guardarReserva(oReservaCLS);
		}

    }
}