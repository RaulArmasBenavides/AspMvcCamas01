using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public class CamaBL
    {

        public List<CamaCLS> listarCama()
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.listarCama();

        }

        public int eliminarCama(int iidcama)
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.eliminarCama(iidcama);

        }

        public CamaCLS recuperarCamaPorId(int id)
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.recuperarCamaPorId(id);
        }

        public int guardarCama(CamaCLS oCamaCLS)
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.guardarCama(oCamaCLS);
        }

        public List<CamaCLS> filtrarCama(string nombrecama)
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.filtrarCama(nombrecama);
        }

    }
}
