using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class FacturaFechaVencimientoException : Exception
    {
        public FacturaFechaVencimientoException(String campo1, String campo2)
            : base("La Fecha de Vencimiento " + campo2 + ", no se corresponde con el Numero de factura ingresado, " + campo1) { }

    }
}
