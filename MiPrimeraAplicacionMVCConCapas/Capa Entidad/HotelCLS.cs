using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class HotelCLS
    {
        public int iidhotel { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }
        public byte[] foto { get; set; }
        public string nombrearchivo { get; set; }

        public string fotobase64 { get; set; }

        public string rutaGuardar { get; set; }

    }
}
