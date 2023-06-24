using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
namespace Capa_Negocio
{
   public class PaginaBL
    {

        public List<PaginaCLS> listarPagina()
        {
            PaginaDAL obj = new PaginaDAL();
            return obj.listarPagina();

        }

		public PaginaCLS recuperarPagina(int iidpagina)
		{
			PaginaDAL oPaginaDAL = new PaginaDAL();
			return oPaginaDAL.recuperarPagina(iidpagina);

		}
		public int eliminarPagina(int iidpagina)
		{
			PaginaDAL oPaginaDAL = new PaginaDAL();
			return oPaginaDAL.eliminarPagina(iidpagina);
		}

		public int guardarPagina(PaginaCLS oPaginaCLS)
		{
			PaginaDAL oPaginaDAL = new PaginaDAL();
			return oPaginaDAL.guardarPagina(oPaginaCLS);
		}

		public List<PaginaCLS> listarMenu(int iidtipousuario)
		{
			PaginaDAL obj = new PaginaDAL();
			return obj.listarMenu(iidtipousuario);
		}



	}
}
