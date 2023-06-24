using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using io=System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimeraAplicacionMVCConCapas.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarPersona()
        {
            PersonaBL oPersonaBL = new PersonaBL();
            //ruta
            string rutaAbsolutaNoFoto = Server.MapPath("~/img/nofoto.png");
            //como leo sus bytes
            byte[] bufferNoFoto= io.File.ReadAllBytes(rutaAbsolutaNoFoto);
            string baseNoFoto = Convert.ToBase64String(bufferNoFoto);
            string mime = "data:image/png;base64,";
            string fotoFinal = mime + baseNoFoto;
            var json = Json(oPersonaBL.listarPersona(fotoFinal), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public JsonResult filtrarPersona(int iidtipousuario)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            return Json(oPersonaBL.filtrarPersona(iidtipousuario),
                JsonRequestBehavior.AllowGet);
        }

      

        public int eliminarPersona(int iidpersona)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            return oPersonaBL.eliminarPersona(iidpersona);
        }

        public JsonResult recuperarPersona(int iidpersona)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            return Json(oPersonaBL.recuperarPersona(iidpersona),
                JsonRequestBehavior.AllowGet);
        }

        public int Guardar(PersonaCLS oPersona,UsuarioCLS oUsuarioCLS, HttpPostedFileBase fotopersona,List<int> valor)
        {
            string nombreFoto = "";
            byte[] bufferfoto;
            //Llenar la foto y el nombre foto
            if (fotopersona != null)
            {
                nombreFoto = fotopersona.FileName;
                io.BinaryReader lector = new io.BinaryReader(fotopersona.InputStream);
                bufferfoto = lector.ReadBytes((int)fotopersona.ContentLength);
                oPersona.foto = bufferfoto;
                oPersona.nombrefoto = nombreFoto;
            }
            PersonaBL oPersonaBL = new PersonaBL();
            oPersona.valor = valor;
            return oPersonaBL.guardarPersona(oPersona, oUsuarioCLS);
        }
    }
}