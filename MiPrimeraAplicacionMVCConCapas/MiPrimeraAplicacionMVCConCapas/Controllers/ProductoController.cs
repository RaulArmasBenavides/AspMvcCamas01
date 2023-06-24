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
    public class ProductoController : Controller
    {
        // GET: Producto
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult lista()
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.listarProductos(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult filtrarProductoPorNombre(string nombreproducto)
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.filtrarProductos(nombreproducto),
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarProductoMarca()
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.listarProductoMarca(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult recuperarProducto(int iidproducto)
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.recuperarProducto(iidproducto),
                JsonRequestBehavior.AllowGet);
        }

        public int guardarProducto(ProductoCLS oProductoCLS)
        {
            ProductoBL obj = new ProductoBL();
           // public int guardarProducto(ProductoCLS oProductoCLS)
            return obj.guardarProducto(oProductoCLS);
        }


        public JsonResult filtrarProductoPorMarca(int iidmarca)
        {
            ProductoBL obj = new ProductoBL();
            return Json(obj.filtrarProductoPorMarca(iidmarca),
            JsonRequestBehavior.AllowGet);

        }

        public JsonResult filtrarProductoPorCategoria(int? iidcategoria)
        {
            if (iidcategoria == null)
            {
                iidcategoria = 0;
            }
            ProductoBL obj = new ProductoBL();
            return Json(obj.filtrarProductoPorCategoria(iidcategoria),
            JsonRequestBehavior.AllowGet);

        }

    }
}