using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo.Exceptions
{
    public class rangoFechasException : Exception
    {
        public rangoFechasException(String valor)
            : base("Se definio un rango invalido para " + valor)
        { }
    }
}
