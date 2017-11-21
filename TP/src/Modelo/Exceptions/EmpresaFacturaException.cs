using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class EmpresaFacturaException : Exception
    {
        public EmpresaFacturaException(String campo1, String campo2)
            : base("La Empresa " + campo2 + ", no esta asociada al Numero de factura ingresado, " + campo1) { }
    }
}
