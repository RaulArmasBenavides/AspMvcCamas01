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
   
    public class CategoriaController : Controller
    {
        // GET: Categoria
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult recuperarCategoria(int iidcategoria)
        {
            CategoriaBL oCategoriaBL = new CategoriaBL();
            return Json(oCategoriaBL.recuperarCategoria(iidcategoria), JsonRequestBehavior.AllowGet);
        }

        public int eliminarCategoria(int iidcategoria)
        {
            CategoriaBL oCategoriaBL = new CategoriaBL();
            return oCategoriaBL.eliminarCategoria(iidcategoria);
        }

        public int guardarCategoria(CategoriaCLS oCategoriaCLS)
        {
            CategoriaBL oCategoriaBL = new CategoriaBL();
            return oCategoriaBL.guardarCategoria(oCategoriaCLS);
        }


        public JsonResult listarCategoria()
        {
            CategoriaBL oCategoriaBL = new CategoriaBL();
            return Json(oCategoriaBL.listarCategoria(), JsonRequestBehavior.AllowGet);
        }
    }
}