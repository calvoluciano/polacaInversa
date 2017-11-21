using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class MedioDePago
    {
        public MedioDePago(DataRow data)
        {
            id = (int)data["ID_MEDIO"];
            descripcion = (String)data["Descripcion"];
        }

        public int id { get; set; }
        public String descripcion { get; set; }

        public static List<MedioDePago> getMedioPagos()              // obtengo las Sucursales del usuario seleccionado
        {
            DataTable data = DB.correrFuncionDeTabla("GET_MEDIOS_PAGOS"); ;
            return data.AsEnumerable()
                        .Select(fila => new MedioDePago(fila))
                        .ToList();
        }
    }
}
