using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using io=System.IO;
namespace BDHotel.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listarHotel()
        {
            string ruta = Server.MapPath("~/Files");

            HotelBL oHotelBL = new HotelBL();
            var json = Json(oHotelBL.listarHotel(ruta), JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;

            return json ;
        }

        public JsonResult recuperarHotel(int iidhotel)
		{
            HotelBL oHotelBL = new HotelBL();
            string ruta = Server.MapPath("~/Files");
            HotelCLS obj = oHotelBL.recuperarHotel(iidhotel, ruta);
        
            return Json(obj, JsonRequestBehavior.AllowGet);
        }


        public int guardarHotel(HotelCLS oHotelCLS, HttpPostedFileBase fotodata)
        {
            HotelBL oHotelBL = new HotelBL();
            string nombreFoto = "";
            byte[] bufferfoto;
            if (fotodata != null)
            {
                //fotodata.FileName= 
                string fechaActual = DateTime.Now.ToString("ddmmyyyyhhmmss");
                nombreFoto = fechaActual+"-"+fotodata.FileName;
                io.BinaryReader lector = new io.BinaryReader(fotodata.InputStream);
                bufferfoto = lector.ReadBytes((int)fotodata.ContentLength);
                oHotelCLS.foto = bufferfoto;
                oHotelCLS.nombrearchivo = nombreFoto;
                string ruta = Server.MapPath("~/Files");
                
                oHotelCLS.rutaGuardar = ruta;
            }

            return oHotelBL.guardarHotel(oHotelCLS);
        }

    }
}