﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Empresa
    {
        public Empresa(DataRow data)
        {
            id = (int)data["ID_EMPRESA"];
            nombre = (String)data["Nombre"];
            cuit = Convert.ToDecimal(data["Cuit"]);
            direccion = (String)data["Direccion"];
            rubro = (String)data["rubro"];
            habilitado = (Boolean)data["ESTADO_EMPRESA"];
        }

        public int id{ get; set; }
        public String nombre{ get; set; }
        public Decimal cuit;
        public String direccion;
        public String rubro;
        public Boolean habilitado;

        public void editar()                                            // persisto los cambios
        {
            DB.correrProcedimiento("EMPRESA_UPDATE",
                                         "id", id,
                                         "nombre", nombre,
                                         "cuit", cuit,
                                         "direccion", direccion,
                                         "rubro", rubro,
                                         "habilitado", habilitado);
        }

        public static void nuevo(String nombre, Decimal cuit, String direccion, String rubro, Boolean habilitado)  // persisto una sucursal nueva
        {
            DB.correrProcedimiento("EMPRESA_NUEVA",
                                         "nombre", nombre,
                                         "cuit", cuit,
                                         "direccion", direccion,
                                         "rubro", rubro,
                                         "habilitado", habilitado);
        }
        public static DataTable getXsConFiltros(String nombre,
                                                 Decimal cuit,
                                                 String rubro)        // obtengo un tipo de usuarios que cumplen con los filtros
        {
            return DB.correrFuncionDeTabla("GET_EMPRESAS_CON_FILTROS",
                               "nombre", nombre,
                               "cuit", cuit,
                               "rubro", rubro);
        }

        public static void inhabilitar(int id)    // inhabilito la Empresa
        {
            DB.correrProcedimiento("INHABILITAR_EMPRESA",
                                            "id", id);
        }

        public static void habilitar(int id)    // habilito la Empresa
        {
            DB.correrProcedimiento("HABILITAR_EMPRESA",
                                            "id", id);
        }

        public static List<String> getDetalle()                                  // obtengo las marcas
        {
            return DB.correrQuery(@"SELECT detalle
                                    FROM POLACA_INVERSA.RUBRO")
                    .AsEnumerable()
                    .Select(fila => fila.Field<string>("detalle"))
                    .ToList();
        }

        public static List<Empresa> getEmpresas()              // obtengo las Sucursales del usuario seleccionado
        {
            DataTable data = getXsConFiltros("",0,"");
            return data.AsEnumerable()
                        .Select(fila => new Empresa(fila))
                        .ToList();
        }

        public static int tieneTodasFacturasCobradasRendidas(int idEmpresa)
        {
            return Factura.getFacturasPendientesDeRendicionEmpresa(idEmpresa).Rows.Count;
        }

        public static DataTable obtenerListadoEmpresas(DateTime fechaDesde,
                                                       DateTime fechaHasta,
                                                       int cantElementos,
                                                       string SP)
        {
            return DB.correrFuncionDeTabla("BUSCAR_" + SP + "_EMPRESA",
                                           "fechaDesde", fechaDesde,
                                           "fechaHasta", fechaHasta,
                                           "cantElementos", cantElementos);
        }
        
    }
}
