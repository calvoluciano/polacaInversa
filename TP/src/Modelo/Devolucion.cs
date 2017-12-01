using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Devolucion
    {
        public DataTable detalleFacturas;
        public DateTime fechaDevolucion { get; set; }
        public string motivoDevolucion { get; set; }


        public void registrarDevolucion()
        {
            SqlCommand comando = DB.nuevoProcedimiento("DEVOLUCION_NUEVA",
                                                        "motivoDevolucion", motivoDevolucion,
                                                        "fechaDevolucion", fechaDevolucion
                                                        );

            SqlParameter parametroDetalleDevolucion = new SqlParameter("@facturas", SqlDbType.Structured); // dado que uno de los parametros es una tabla tengo que hacer un poco de magia
            parametroDetalleDevolucion.TypeName = "POLACA_INVERSA.TABLA_ITEMS_DEVOLUCION";
            parametroDetalleDevolucion.Value = detalleFacturas;
            comando.Parameters.Add(parametroDetalleDevolucion);

            DB.ejecutarProcedimiento(comando);
        }
    }
}
