using Capa_Negocio;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAplicacionMVCConCapas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session["persona"] = null;
            return RedirectToAction("Index");
        }

        public JsonResult uspLogin(string usuario, string contra)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PaginaBL oPaginaBL = new PaginaBL();
            PersonaCLS oPersonaCLS = oPersonaBL.uspLogin(usuario, contra);
			if (oPersonaCLS.iidusuario != 0)
			{
                Session["persona"] = oPersonaCLS;
                int iidtipousuario= oPersonaCLS.iidtipousuario;
                List<PaginaCLS> listaPagina = oPaginaBL.listarMenu(iidtipousuario);
                //Todas las opciones que el usuario puede ver
                Session["menu"] = listaPagina;

            }
			else
			{
                Session["persona"] = null;

            }
            return Json(oPersonaCLS,
                JsonRequestBehavior.AllowGet);
        }

    }
}