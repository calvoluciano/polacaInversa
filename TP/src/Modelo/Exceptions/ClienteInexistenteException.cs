using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions 
{
    public class ClienteInexistenteException : Exception
    {
        public ClienteInexistenteException(String campo1)
            : base("El cliente con Dni" + campo1 + " no esta registrado en la base de datos") { }
    }
}
