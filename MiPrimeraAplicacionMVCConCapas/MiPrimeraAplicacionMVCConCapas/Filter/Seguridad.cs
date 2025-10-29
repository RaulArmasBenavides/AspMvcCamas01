using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDHotel.Filter
{
	public class Seguridad : ActionFilterAttribute
	{

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = System.Web.HttpContext.Current?.Session;
            var persona = session?["persona"];
            var paginas = session?["menu"] as List<PaginaCLS>;

            // 1) Sin sesión o sin menú => login
            if (persona == null || paginas == null || paginas.Count == 0)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
                base.OnActionExecuting(filterContext);
                return;
            }

            // 2) Normaliza nombres
            string ctrl = (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName ?? "").Trim();
            string act = (filterContext.ActionDescriptor.ActionName ?? "").Trim();

            // 3) Coincidencia case-insensitive
            bool matchAccion = paginas.Any(p =>
                string.Equals((p.controlador ?? "").Trim(), ctrl, StringComparison.OrdinalIgnoreCase) &&
                string.Equals((p.accion ?? "").Trim(), act, StringComparison.OrdinalIgnoreCase));

            // 4) (Opcional) Permitir Index si el controlador existe aunque no haya registro de acción
            bool matchSoloCtrl = paginas.Any(p =>
                string.Equals((p.controlador ?? "").Trim(), ctrl, StringComparison.OrdinalIgnoreCase));
            bool esIndex = string.Equals(act, "Index", StringComparison.OrdinalIgnoreCase);

            if (!matchAccion && !(esIndex && matchSoloCtrl))
            {
                // Si es AJAX, puedes devolver 401 en vez de redirect:
                // if (filterContext.HttpContext.Request.IsAjaxRequest())
                // { filterContext.Result = new HttpStatusCodeResult(401); return; }

                filterContext.Result = new RedirectResult("~/Login/Index");
                base.OnActionExecuting(filterContext);
                return;
            }

            base.OnActionExecuting(filterContext);
        }

    }
}