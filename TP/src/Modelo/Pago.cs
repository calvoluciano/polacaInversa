using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Pago
    {
        public int idPago;
        public int idMedioPago { get; set; }
        public DataTable detallePago;
        public DateTime fechaCobro {get; set;}
        public Double total {get; set;}
        public int idCliente {get; set;}
        public int idSucursal {get; set;}

        public void aumentarImporteTotal(Double importeFactura)
        {
            this.total += importeFactura;
        }

        public void registrarPago()
        {
            SqlCommand comando = DB.nuevoProcedimiento("PAGO_NUEVO",
                                            "idPago", idPago,
                                            "idSucursal",idSucursal,
                                            "idCliente", idCliente,
                                            "medioPago", idMedioPago,
                                            "fechaPago", fechaCobro,
                                            "total",total);

            SqlParameter parametroDetallePago = new SqlParameter("@facturas", SqlDbType.Structured); // dado que uno de los parametros es una tabla tengo que hacer un poco de magia
            parametroDetallePago.TypeName = "POLACA_INVERSA.TABLA_ITEMS_PAGO";
            parametroDetallePago.Value = detallePago;
            comando.Parameters.Add(parametroDetallePago);
            
            DB.ejecutarProcedimiento(comando);
        }

        public void guardarDetalleFacturas()
        {
            SqlCommand comando = DB.nuevoProcedimiento("DETALLE_PAGO_NUEVO",
                                                "idPago", idPago);
            SqlParameter parametroDetallePago = new SqlParameter("@facturas", SqlDbType.Structured); // dado que uno de los parametros es una tabla tengo que hacer un poco de magia
            parametroDetallePago.TypeName = "POLACA_INVERSA.TABLA_ITEMS_PAGO";
            parametroDetallePago.Value = detallePago;
            comando.Parameters.Add(parametroDetallePago);
            DB.ejecutarProcedimiento(comando);
        }

    }
}
