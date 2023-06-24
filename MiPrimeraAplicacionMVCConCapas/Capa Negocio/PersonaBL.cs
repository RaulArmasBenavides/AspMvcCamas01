using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
   public class PersonaBL
    {

        public int eliminarPersona(int iidpersona)
        {
            PersonaDAL oPersonaDAL = new PersonaDAL();
            return oPersonaDAL.eliminarPersona(iidpersona);
        }

        public List<PersonaCLS> filtrarPersona(int iidtipousuario)
        {
            PersonaDAL oPersonaDAL = new PersonaDAL();
            return oPersonaDAL.filtrarPersona(iidtipousuario);
        }

        public int guardarPersona(PersonaCLS oPersonaCLS,UsuarioCLS oUsuarioCLS)
        {
            PersonaDAL oPersonaDAL = new PersonaDAL();
            return oPersonaDAL.guardarPersona(oPersonaCLS, oUsuarioCLS);
        }

        public PersonaCLS recuperarPersona(int iidpersona)
        {
            PersonaDAL oPersonaDAL = new PersonaDAL();
            return oPersonaDAL.recuperarPersona(iidpersona);
        }

        public List<PersonaCLS> listarPersona(string fotofinal)
        {
            PersonaDAL oPersonaDAL = new PersonaDAL();
            return oPersonaDAL.listarPersona(fotofinal);

        }

        public PersonaCLS uspLogin(string usuario, string contra)
		{
            PersonaDAL oPersonaDAL = new PersonaDAL();
            return oPersonaDAL.uspLogin(usuario, contra);

        }


    }
}
