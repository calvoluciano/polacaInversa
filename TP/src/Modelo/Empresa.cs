using System;
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
            id = (int)data["id_empresa"];
            nombre = (String)data["Nombre"];
            cuit = Convert.ToDecimal(data["Cuit"]);
            direccion = (String)data["Direccion"];
            rubro = (String)data["rubro"];
            habilitado = (Boolean)data["Habilitada"];
        }

        public int id;
        public String nombre;
        public Decimal cuit;
        public String direccion;
        public String rubro;
        public Boolean habilitado;

        public void editar()                                            // persisto los cambios
        {
            DB.correrProcedimiento("EMPRESA_UPDATE",
                                         "id_empresa", id,
                                         "nombre", nombre,
                                         "cuit", cuit,
                                         "direccion", direccion,
                                         "rubro", rubro,
                                         "habilitado", habilitado);
        }

        public static void nuevo(int id, String nombre, Decimal cuit, String direccion, String rubro, Boolean habilitado)  // persisto una sucursal nueva
        {
            DB.correrProcedimiento("EMPRESA_NUEVO",
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

        public void inhabilitar(int id)    // inhabilito la Empresa
        {
            DB.correrProcedimiento("_INHABILITAR",
                                            "id", id);
        }

        public void habilitar(int id)    // habilito la Empresa
        {
            DB.correrProcedimiento("_HABILITAR",
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

    }
}
