using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class EmailExistenteException: Exception
    {
        public EmailExistenteException(String campo)
            : base("Ya existe un cliente con el mail ingresado " + campo ) { }
    }
}
