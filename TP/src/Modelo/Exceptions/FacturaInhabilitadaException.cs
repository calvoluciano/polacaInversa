using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class FacturaInhabilitadaException : Exception
    {
        public FacturaInhabilitadaException(String campo)
            : base("La Factura " + campo + ", que desea agregar se encuentra inhabilitada.") { }
    }
}
