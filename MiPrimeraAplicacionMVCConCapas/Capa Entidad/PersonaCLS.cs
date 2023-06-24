using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class PersonaCLS
    {
        public int iidpersona { get; set; }
        public int iidtipousuario { get; set; }
        public string nombreCompleto { get; set; }
        public string nombreSexo { get; set; }
        public string nombreTipoUsuario { get; set; }
        //Propiedades adicionales
        public string nombre { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
        public string telefono { get; set; }
        public int iidsexo { get; set; }
        //Propiedades foto
        public string nombrefoto { get; set; }
        public byte[] foto { get; set; }

        public string fotobase64 { get; set; }

        public List<int> valor { get; set; }

        public int iidusuario { get; set; }
        public string nombreusuario { get; set; }

    }
}
