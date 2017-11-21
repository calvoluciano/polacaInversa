using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class FacturaYaCobradaException : Exception
    {
        public FacturaYaCobradaException(String campo)
            : base("La Factura " + campo + " ya esta cobrada.") { }
    }
}
