using Capa_Entidad;
using Capa_Negocio;
using MiPrimeraAplicacionMVCConCapas.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAplicacionMVCConCapas.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }
      
        public JsonResult listarMarca()
        {
            MarcaBL oMarcaBL = new MarcaBL();
            return Json(oMarcaBL.listarMarca(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult filtrarMarca(string nombremarca)
        {
            MarcaBL oMarcaBL = new MarcaBL();
            return Json(oMarcaBL.filtrarMarca(nombremarca), JsonRequestBehavior.AllowGet);
        }


        public JsonResult recuperarMarca(int iidmarca)
        {
            MarcaBL oMarcaBL = new MarcaBL();
            return Json(oMarcaBL.recuperarMarca(iidmarca),
                JsonRequestBehavior.AllowGet);
        }


        public int eliminarMarca(int iidmarca)
        {
            MarcaBL oMarcaBL = new MarcaBL();
            return oMarcaBL.eliminarMarca(iidmarca);
        }

        public int guardarMarca(MarcaCLS oMarcaCLS)
        {
            MarcaBL oMarcaBL = new MarcaBL();
            return oMarcaBL.guardarMarca(oMarcaCLS);
        }



    }
}