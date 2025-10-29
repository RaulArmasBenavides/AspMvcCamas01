using Capa_Entidad;
using Capa_Negocio;
using BDHotel.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDHotel.Controllers
{
   
    public class CamaController : Controller
    {
        // GET: Cama
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        public int guardarCama(CamaCLS oCamaCLS)
        {
            CamaBL oCamaBL = new CamaBL();
            return oCamaBL.guardarCama(oCamaCLS);
        }

        public int eliminarCama(int idcama)
        {
            CamaBL oCamaBL = new CamaBL();

            return oCamaBL.eliminarCama(idcama);
        }

        public JsonResult recuperarCama(int idcamita)
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.recuperarCamaPorId(idcamita),JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarCama()
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.listarCama(),JsonRequestBehavior.AllowGet);
        }

        //Simular que ya lo cree
        public JsonResult filtrarCama(string nombre)
        {
            CamaBL oCamaBL = new CamaBL();
            return Json(oCamaBL.filtrarCama(nombre), JsonRequestBehavior.AllowGet);
        }
    }
}