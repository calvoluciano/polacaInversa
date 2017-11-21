﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Modelo
{
    public class Factura
    {
        public int idEmpresa;
        public Decimal idFactura;
        public int idCliente;
        public Decimal dniCliente;
        public Decimal cuitEmpresa;
        public string nombreEmpresa;
        public string nombreCliente;

        public int idDetalle;
        public int idPago;
        public int idRendicion;
        public int idDevolucion;


        public DateTime fechaAlta;
        public DateTime fechaVencimiento;
        public Decimal total;
        public DataTable detalleFactura;

         public Factura(DataRow data)
        {
            idFactura = Convert.ToDecimal(data["ID_FACTURA"]);
            //idEmpresa = (int)data["ID_EMPRESA"];
            //idCliente = (int)data["ID_CLIENTE"];
            nombreEmpresa = (string)data["Nombre Empresa"];
            cuitEmpresa = Convert.ToDecimal(data["Cuit Empresa"]);
            nombreCliente = (string)data["Nombre Cliente"];
            //idPago = (int)data["ID_PAGO"];
            dniCliente = Convert.ToDecimal(data["DNI"]);
            fechaAlta = (DateTime)data["Fecha Alta"];
            fechaVencimiento = (DateTime)data["Fecha Vencimiento"];
            total = (Decimal)data["Total"];
        }

        public Factura() { }

        public void editar()                                            // persisto los cambios
        {
            DB.correrProcedimiento("FACTURA_UPDATE",
                                         "idFactura", idFactura,
                                         "idEmpresa", idEmpresa,
                                         "dniCliente", dniCliente,
                                         "fechaAlta", fechaAlta,
                                         "fechaVencimiento", fechaVencimiento);
        }

        public void nuevo()  // persisto una factura nueva
        {
            DB.correrProcedimiento("FACTURA_NUEVA",
                                         "numeroFactura",idFactura,
                                         "idEmpresa", idEmpresa,
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

        public static Boolean estaCobrada(Int32 idFactura)
        {
            return (Boolean)DB.correrFuncion("FACTURA_ESTACOBRADA",
                                    "idFactura", idFactura);
        }
        public void guardarDetalle()
        {
            SqlCommand comando = DB.nuevoProcedimiento("DETALLE_FACTURA_NUEVO",
                                            "idFactura", idFactura,
                                            "total", total);
            SqlParameter parametroDetalleFactura = new SqlParameter("@items", SqlDbType.Structured); // dado que uno de los parametros es una tabla tengo que hacer un poco de magia
            parametroDetalleFactura.TypeName = "POLACA_INVERSA.TABLA_ITEMS_FACTURA";
            parametroDetalleFactura.Value = detalleFactura;
            comando.Parameters.Add(parametroDetalleFactura);
            DB.ejecutarProcedimiento(comando);
            
        }

        public DataTable getDetalle()
        {
            return DB.correrFuncionDeTabla("FACTURA_GET_DETALLE",
                                            "idFactura",idFactura);
        }

        public static DataTable getFacturasPendientesDeRendicionEmpresa(int idEmpresa)
        {
            return DB.correrFuncionDeTabla("BUSCAR_FACTURAS_PENDIENTES_DE_RENDICION_EMPRESA",
                                            "idEmpresa", idEmpresa);
        }

        public static Boolean esFacturaExistente(Int32 idFactura)
        {
            return (Boolean)DB.correrFuncion("FACTURA_EXISTE",
                                    "idFactura", idFactura);
        }

        public static Boolean esFacturaHabilitada(Int32 idFactura)
        {
            return (Boolean)DB.correrFuncion("FACTURA_ESTA_HABILITADA",
                                    "idFactura", idFactura);
        }

        public static Boolean esFacturaDeLaEmpresa(Int32 idFactura, Int32 idEmpresa)
        {
            return (Boolean)DB.correrFuncion("FACTURA_ES_DE_EMPRESA",
                                    "idFactura", idFactura,
                                    "idEmpresa", idEmpresa);
        }

        public static Boolean esFacturaDelCliente(Int32 idFactura, Int32 idCliente)
        {
            return (Boolean)DB.correrFuncion("FACTURA_ES_DE_CLIENTE",
                                    "idFactura", idFactura,
                                    "idCliente", idCliente);
        }

        public static Boolean verificaFechaVencimiento(Int32 idFactura, DateTime fecVencimiento)
        {
            ComparadorFechas comparar = new ComparadorFechas();
            DateTime fechaRegistrada = (DateTime)DB.correrFuncion("GET_FECHA_VENCIMIENTO_FACTURA",
                                    "idFactura", idFactura);
            return comparar.esIgual(fechaRegistrada, fecVencimiento);
                
        }
        
    }
}
