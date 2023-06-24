using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
namespace Capa_Negocio
{
    public class TipoHabitacionBL
    {
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.listarTipoHabitacion();

        }

        public int guardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.guardarTipoHabitacion(oTipoHabitacion);

        }

        public int eliminarTipoHabitacion(int iidtipohabitacion)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.eliminarTipoHabitacion(iidtipohabitacion);
        }

        public TipoHabitacionCLS recuperarTipoHabitacion(int id)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.recuperarTipoHabitacion(id);
        }

        public List<TipoHabitacionCLS> filtrarTipoHabitacion(string nombrehabitacion)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.filtrarTipoHabitacion(nombrehabitacion);

        }

    }
}
