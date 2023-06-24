using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class ProductoMarcaCLS
    {
        public List<MarcaCLS> listaMarca { get; set; }
        public List<ProductoCLS> listaProducto { get; set; }
        public List<CategoriaCLS> listaCategoria { get; set; }
    }
}
