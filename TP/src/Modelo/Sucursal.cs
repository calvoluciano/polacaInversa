using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Modelo
{
    public class Sucursal
    {
        public int id;
        public String nombre { get; set; }
        public String direccion;
        public Decimal codigoPostal { get; set; }
        public Boolean habilitado;

        public Sucursal(DataRow data)
        {
            id = (int)data["ID_SUCURSAL"];
            codigoPostal = Convert.ToDecimal(data["Codigo_Postal"]);
            direccion = (String)data["Direccion"];
            nombre = (String)data["Nombre"];
            habilitado = (Boolean)data["Habilitado"];
        }
        public Sucursal() { }

        public void editar()                                            // persisto los cambios
        {
            DB.correrProcedimiento("SUCURSAL_UPDATE",
                                         "idSucursal", id,
                                         "nombre", nombre,
                                         "direccion",direccion,
                                         "codigoPostal", codigoPostal,
                                         "habilitado", habilitado);
        }

        public static void nuevo(String nombre, String direccion, decimal codigoPostal, Boolean habilitado)  // persisto una sucursal nueva
        {
            DB.correrProcedimiento("SUCURSAL_NUEVO",
                                         "nombre", nombre,
                                         "direccion", direccion,
                                         "codigoPostal", codigoPostal,
                                         "habilitado", habilitado);
        }
        public static DataTable getXsConFiltros( // "SUCURSALES"
                                              String nombre,
                                              String direccion,
                                              Decimal codigoPostal)        // obtengo un tipo de usuarios que cumplen con los filtros
        {
            return DB.correrFuncionDeTabla("GET_SUCURSAL_CON_FILTROS",
                               "Nombre", nombre,
                               "Direccion", direccion,
                               "Codigo_Postal", codigoPostal);
        }

        public static void inhabilitar(int id)    // inhabilito la sucursal
        {
            DB.correrProcedimiento("INHABILITAR_SUCURSAL",
                                            "id", id);
        }
        public static void habilitar(int id)    // habilito la sucursal
        {
            DB.correrProcedimiento("HABILITAR_SUCURSAL",
                                            "id", id);
        }

        public static Boolean validarSucursalHabilitada(int id)
        {
            return (Boolean)DB.correrFuncion("SUCURSAL_ESTA_HABILITADA", "id", id);
        }

    }
}
