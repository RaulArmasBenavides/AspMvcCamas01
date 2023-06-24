using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CategoriaBL
    {

        public int guardarCategoria(CategoriaCLS oCategoriaCLS)
        {
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            return oCategoriaDAL.guardarCategoria(oCategoriaCLS);
        }

        public int eliminarCategoria(int iidcategoria)
        {
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            return oCategoriaDAL.eliminarCategoria(iidcategoria);
        }

        public CategoriaCLS recuperarCategoria(int iidcategoria)
        {
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            return oCategoriaDAL.recuperarCategoria(iidcategoria);
        }

        public List<CategoriaCLS> listarCategoria()
        {
            CategoriaDAL oCategoriaDAL = new CategoriaDAL();
            return oCategoriaDAL.listarCategoria();

        }
    }
}
