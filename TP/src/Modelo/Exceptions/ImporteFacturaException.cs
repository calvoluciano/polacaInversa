using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class ImporteFacturaException :  Exception
    {
        public ImporteFacturaException(String campo)
            : base("EL importe ingresado no se corresponde a la Factura " + campo) { }
    }
}
