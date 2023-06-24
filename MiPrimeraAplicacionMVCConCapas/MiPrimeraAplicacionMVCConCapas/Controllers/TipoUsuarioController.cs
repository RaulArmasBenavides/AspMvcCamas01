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
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        public int guardarTipoUsuario(TipoUsuarioCLS oTipoUsuarioCLS)
        {
           // oTipoUsuarioCLS.idpaginaTipousuarios = idpaginas;
            TipoUsuarioBL oTipoUsuarioBL = new TipoUsuarioBL();
            return oTipoUsuarioBL.guardarTipousuario(oTipoUsuarioCLS);
        }

        public JsonResult recuperarTipoUsuario(int iidtipousuario)
        {
            TipoUsuarioBL oTipoUsuarioBL = new TipoUsuarioBL();
            return Json(oTipoUsuarioBL.recuperarTipousuario(iidtipousuario),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarTipoUsuario()
        {
            TipoUsuarioBL oTipoUsuarioBL = new TipoUsuarioBL();
            return Json(oTipoUsuarioBL.listarTipoUsuario(),
                JsonRequestBehavior.AllowGet);
        }
    }
}