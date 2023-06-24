using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Capa_Datos
{
   public class CadenaDAL
    {
       public string cadena { get; set; }
        public CadenaDAL()
        {
            cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }
    }
}
