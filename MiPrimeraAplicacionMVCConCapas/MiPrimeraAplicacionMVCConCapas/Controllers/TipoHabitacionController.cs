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
    public class TipoHabitacionController : Controller
    {
        // GET: TipoHabitacion
        [Seguridad]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult VistaPruebaInicio()
        {
            return View();
        }

        public string cadena()
        {
            return "123";
        }

        public int numero()
        {
            return 5;
        }

        //public List<TipoHabitacionCLS> lista()
        //{
        //    TipoHabitacionBL obj = new TipoHabitacionBL();
        //    return obj.listarTipoHabitacion();
        //}
        // [{"id":1,"nombre":"Simple","descripcion":"Solo para uno"},{"id":2,"nombre":"Doble","descripcion":"Hecho para casados"}]
        public JsonResult lista()
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.listarTipoHabitacion(),JsonRequestBehavior.AllowGet);
        }

        public JsonResult filtrarTipohabitacionPorNombre(string nombrehabitacion)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.filtrarTipoHabitacion(nombrehabitacion),
                JsonRequestBehavior.AllowGet);
        }


        public int guardarDatos(TipoHabitacionCLS oTipoHabitacionCLS)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.guardarTipoHabitacion(oTipoHabitacionCLS);

        }

        public JsonResult recuperarTipoHabitacion(int id)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return Json(obj.recuperarTipoHabitacion(id), JsonRequestBehavior.AllowGet);
        }

        public int eliminarTipoHabitacion(int id)
        {
            TipoHabitacionBL obj = new TipoHabitacionBL();
            return obj.eliminarTipoHabitacion(id);
        }





    }
}