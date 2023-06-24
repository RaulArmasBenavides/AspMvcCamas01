using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAplicacionMVCConCapas.Filter
{
	public class Seguridad : ActionFilterAttribute
	{

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var persona=  HttpContext.Current.Session["persona"];
			List<PaginaCLS> listapagina=(List<PaginaCLS>)HttpContext.Current.Session["menu"];
			//El nombre controller
			string nombreController = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
			string nombreaccion = filterContext.ActionDescriptor.ActionName;
			int cantidad= listapagina.Where(p => p.controlador == nombreController 
			&& p.accion == nombreaccion).Count();
			if (persona == null || cantidad==0)
			{
				filterContext.Result = new RedirectResult("~/Login/Index");
			}
			base.OnActionExecuting(filterContext);
		}

	}
}