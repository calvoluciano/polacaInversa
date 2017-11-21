using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    class FacturaInexistenteException : Exception
    {
        public FacturaInexistenteException(String campo)
            : base("La Factura " + campo + ", que desea agregar no existe en la base de datos.") { }
    }
}
