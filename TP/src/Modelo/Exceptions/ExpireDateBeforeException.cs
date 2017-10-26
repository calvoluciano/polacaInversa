using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    class ExpireDateBeforeException : Exception
    {
        public ExpireDateBeforeException(String campo)
            : base("La fecha de vencimiento es anterior a la fecha de alta") { }
    }
}
