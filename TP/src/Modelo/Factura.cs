using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Modelo
{
    public class Factura : Usuario
    {
        public int numFactura;
        public int cuit;
        public int dniCliente;

        public int idDetalle;
        public int idPago;
        public int idRendicion;
        public int idDevolucion;


        public DateTime fechaAlta;
        public DateTime fechaVencimiento;
        public int total;

         public Factura(DataRow data)
        {
            New(data);
            numFactura = (int)data["Factura_Numero"];
            cuit = (int)data["Factura_Cuit"];
            dniCliente = (int)data["Factura_DNI_Cliente"];
            fechaAlta = (DateTime)data["Factura_Fecha_Alta"];
            fechaVencimiento = (DateTime)data["Factura_Fecha_Vencimiento"];

        }
        public Factura() { }

        public void editar()                                            // persisto los cambios
        {
            DB.correrProcedimiento("FACTURA_UPDATE",
                                         "factura_numero", numFactura,
                                         "factura_cuit", cuit,
                                         "factura_dni_cliente", dniCliente,
                                         "factura_fecha_alta", fechaAlta,
                                         "factura_fecha_vencimiento", fechaVencimiento);
        }

        public static void nuevo(int numFactura, int cuit, int dniCliente, DateTime fechaAlta, DateTime fechaVencimiento)  // persisto una factura nueva
        {
            DB.correrProcedimiento("Factura_NUEVA",
                                         "numeroFactura",numFactura,
                                         "cuit", cuit,
                                         "dniCliente", dniCliente,
                                         "fechaAlta", fechaAlta,
                                         "fechaVencimiento",fechaVencimiento);
        }
        /*public static DataTable getXsConFiltros(String X, // "FACTURAS"
                                              int numFactura)        // obtengo un tipo de usuarios que cumplen con los filtros
        {
            return DB.correrFuncionDeTabla("GET_" + X + "_CON_FILTROS",
                               "Nombre", nombre,
                               "Direccion", direccion);
        }*/
        

    }
}
