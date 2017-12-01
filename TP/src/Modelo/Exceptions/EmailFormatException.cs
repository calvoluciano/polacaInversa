using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class EmailFormatException: Exception
    {
        public EmailFormatException(String campo)
            : base("El email ingresado no tiene un formato valido" + campo ) { }
    }
}
