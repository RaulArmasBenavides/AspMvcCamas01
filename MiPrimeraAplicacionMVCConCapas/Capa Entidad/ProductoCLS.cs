using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
   public class ProductoCLS
    {
        public int iidproducto { get; set; }
        public string nombreproducto { get; set; }
        public string nombremarca { get; set; }
        public decimal precioventa { get; set; }
        public decimal preciocontra { get; set; }
        public int stock { get; set; }
        public string denominacion { get; set; }
        public int iidmarca { get; set; }
        public int iidcategoria { get; set; }
        public string descripcion { get; set; }
    }
}
