using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class EmpresaNoSeleccionadaException :Exception
    {
        public EmpresaNoSeleccionadaException()
            : base("Debe elegir una empresa para poder crear la factura."){ }
    }
}
