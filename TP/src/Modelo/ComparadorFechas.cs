using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class ComparadorFechas
    {
        public bool esMenor(DateTime fecha1, DateTime fecha2)
        {
            if (fecha1.Year < fecha2.Year) return true;
            if (fecha1.Year > fecha2.Year) return false;

            if (fecha1.Month < fecha2.Month) return true;
            if (fecha1.Month > fecha2.Month) return false;

            return fecha1.Day < fecha2.Day;
        }

        public bool esIgual(DateTime fecha1, DateTime fecha2)
        {
            return fecha1.Year == fecha2.Year && fecha1.Month == fecha2.Month && fecha1.Day == fecha2.Day;
        }
    }
}
