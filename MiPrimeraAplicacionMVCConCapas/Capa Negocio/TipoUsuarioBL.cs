using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public class TipoUsuarioBL
    {
        public TipoUsuarioCLS recuperarTipousuario(int iidtipousuario)
        {
            TipoUsuarioDAL oTipoUsuarioDAL = new TipoUsuarioDAL();
            return oTipoUsuarioDAL.recuperarTipousuario(iidtipousuario);
        }
        public int guardarTipousuario(TipoUsuarioCLS oTipoUsuarioCLS)
        {
            TipoUsuarioDAL oTipoUsuarioDAL = new TipoUsuarioDAL();
            return oTipoUsuarioDAL.guardarTipousuario(oTipoUsuarioCLS);
        }
        public List<TipoUsuarioCLS> listarTipoUsuario()
        {
            TipoUsuarioDAL oTipoUsuarioDAL = new TipoUsuarioDAL();
            return oTipoUsuarioDAL.listarTipoUsuario();
        }


    }
}
