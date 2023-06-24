using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public class MarcaBL
    {


        public List<MarcaCLS> filtrarMarca(string nombremarca)
        {
            MarcaDAL oMarcaDAL = new MarcaDAL();
            return oMarcaDAL.filtrarMarca(nombremarca);
        }

        public List<MarcaCLS> listarMarca()
        {
            MarcaDAL oMarcaDAL = new MarcaDAL();
            return oMarcaDAL.listarMarca();

        }

        public MarcaCLS recuperarMarca(int iidmarca)
        {
            MarcaDAL oMarcaDAL = new MarcaDAL();
            return oMarcaDAL.recuperarMarca(iidmarca);
        }

        public int guardarMarca(MarcaCLS oMarcaCLS)
        {
            MarcaDAL oMarcaDAL = new MarcaDAL();
            return oMarcaDAL.guardarMarca(oMarcaCLS);
        }

        public int eliminarMarca(int iidmarca)
        {
            MarcaDAL oMarcaDAL = new MarcaDAL();
            return oMarcaDAL.eliminarMarca(iidmarca);
        }



    }
}
