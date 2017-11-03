using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Modelo
{
    public class Factura
    {
        public int idEmpresa;
        public int idFactura;
        public int idCliente;
        public decimal dniCliente;
        public decimal cuitEmpresa;
        public string nombreEmpresa;
        public string nombreCliente;

        public int idDetalle;
        public int idPago;
        public int idRendicion;
        public int idDevolucion;


        public DateTime fechaAlta;
        public DateTime fechaVencimiento;
        public decimal total;

         public Factura(DataRow data)
        {
            idFactura = (int)data["ID_FACTURA"];
            //idEmpresa = (int)data["ID_EMPRESA"];
            //idCliente = (int)data["ID_CLIENTE"];
            nombreEmpresa = (string)data["Nombre Empresa"];
            cuitEmpresa = (decimal)data["Cuit Empresa"];
            nombreCliente = (string)data["Nombre Cliente"];
            //idPago = (int)data["ID_PAGO"];
            dniCliente = (int)data["DNI"];
            fechaAlta = (DateTime)data["Fecha Alta"];
            fechaVencimiento = (DateTime)data["Fecha Vencimiento"];
            total = (decimal)data["Total"];
        }

        public Factura() { }

        public void editar()                                            // persisto los cambios
        {
            DB.correrProcedimiento("FACTURA_UPDATE",
                                         "idFactura", idFactura,
                                         "cuitEmpresa", cuitEmpresa,
                                         "dniCliente", dniCliente,
                                         "fechaAlta", fechaAlta,
                                         "fechaVencimiento", fechaVencimiento);
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
        public static DataTable getXsConFiltros(    int numFactura, // "FACTURAS"
                                                    decimal dniCliente,
                                                    decimal cuitEmpresa,
                                                    decimal total)        // obtengo un tipo de usuarios que cumplen con los filtros
        {
            return DB.correrFuncionDeTabla("GET_FACTURAS_CON_FILTROS",
                                            "numFactura", numFactura,
                                            "dniCliente", dniCliente,
                                            "cuitEmpresa", cuitEmpresa,
                                            "total", total);
        }
        

    }
}
