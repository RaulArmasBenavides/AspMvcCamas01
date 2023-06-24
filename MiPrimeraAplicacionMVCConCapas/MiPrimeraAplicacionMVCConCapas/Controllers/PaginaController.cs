using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Entidad;
namespace MiPrimeraAplicacionMVCConCapas.Controllers
{
    public class PaginaController : Controller
    {
        // GET: Pagina
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarPaginas()
        {
            PaginaBL oPaginaBL = new PaginaBL();
            return Json(oPaginaBL.listarPagina(),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarMenus(int iidtipousuario)
        {
            PaginaBL oPaginaBL = new PaginaBL();
            return Json(oPaginaBL.listarMenu(iidtipousuario),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult recuperarPagina(int iidpagina)
        {
            PaginaBL oPaginaDAL = new PaginaBL();
            return Json(oPaginaDAL.recuperarPagina(iidpagina),
                JsonRequestBehavior.AllowGet);

        }
        public int eliminarPagina(int iidpagina)
        {
            PaginaBL oPaginaDAL = new PaginaBL();
            return oPaginaDAL.eliminarPagina(iidpagina);
        }

        public int guardarPagina(PaginaCLS oPaginaCLS)
        {
            PaginaBL oPaginaDAL = new PaginaBL();
            return oPaginaDAL.guardarPagina(oPaginaCLS);
        }





    }
}