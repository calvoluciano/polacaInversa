using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class FacturaYaAgregadaException : Exception
    {

        public FacturaYaAgregadaException(String campo)
            : base("El campo " + campo + " no contiene datos.") { }
    }
}
