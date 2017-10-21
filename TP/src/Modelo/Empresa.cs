using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Modelo
{
    public class Empresa : Usuario
    {
        public String nombre;
        public String direccion;

        public Empresa(DataRow data)
        {
            New(data);
            habilitado = (Boolean)data["Sucursal_Habilitada"];
            direccion = (String)data["Direccion"];
            nombre = (String)data["Nombre"];
        }
        public Empresa() { }

        public void editar()                                            // persisto los cambios
        {
            DB.correrProcedimiento("SUCURSAL_UPDATE",
                                         "id_sucursal", id,
                                         "nombre", nombre,
                                         "direccion", direccion,
                                         "estado_sucursal", habilitado);
        }

        public static void nuevo(int id, decimal codigoPostal, Boolean habilitado, String nombre, String direccion)  // persisto una sucursal nueva
        {
            DB.correrProcedimiento("Sucursal_NUEVO",
                                         "id", id,
                                         "nombre", nombre,
                                         "direccion", direccion,
                                         "habilitado", habilitado);
        }
        public static DataTable getXsConFiltros(String X, // "EMPRESAS"
                                              String nombre,
                                              String direccion)        // obtengo un tipo de usuarios que cumplen con los filtros
        {
            return DB.correrFuncionDeTabla("GET_" + X + "_CON_FILTROS",
                               "Nombre", nombre,
                               "Direccion", direccion);
        }

        public void inhabilitar(int id)    // inhabilito la sucursal
        {
            DB.correrProcedimiento("_INHABILITAR",
                                            "id", id);
        }
        public void habilitar(int id)    // habilito la sucursal
        {
            DB.correrProcedimiento("_HABILITAR",
                                            "id", id);
        }

    }
}
