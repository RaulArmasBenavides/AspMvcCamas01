using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Usuario
{
    public class GenericLH
    {

		public static string cifrarCadena(string cadena)
		{
			SHA256Managed sha = new SHA256Managed();
			//Bytes
			byte[] bytecadena = Encoding.Default.GetBytes(cadena);
			byte[] bytecifrado = sha.ComputeHash(bytecadena);
			return BitConverter.ToString(bytecifrado).Replace("-", "");
		}

	}
}
