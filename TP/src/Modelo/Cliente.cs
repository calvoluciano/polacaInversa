using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Cliente
    {
        public Cliente(DataRow data)
        {
            id = (int)data["id_cliente"];
            dni = (decimal)data["DNI"];
            nombre = (String)data["Nombre"];
            apellido = (String)data["Apellido"];
            mail = (String)data["Mail"];
            telefono = (decimal)data["Telefono"];
            domicilio = (String)data["Domicilio"];
            numero = (decimal)data["Numero"];
            piso = (String)data["Piso"];
            localidad = (String)data["Localidad"];
            fechaNac = (DateTime)data["Fecha_Nac"];
            codigoPostal = (decimal)data["Codigo_Postal"];
            habilitado = (Boolean)data["Estado_Cliente"];
         }

        public int id;
        public String nombre;
        public String apellido;
        public decimal dni;
        public String mail;
        public decimal telefono;
        public String domicilio;
        public decimal numero;
        public String piso;
        public String dpto;
        public String localidad;
        public DateTime fechaNac;
        public Boolean habilitado;
        public decimal codigoPostal;

        public void editar()                                            // persisto los cambios
        {
            DB.correrProcedimiento("Cliente_UPDATE",
                                         "DNI_Cliente", dni,
                                         "Nombre", nombre,
                                         "Apellido", apellido,
                                         "Mail", mail,
                                         "Telefono", telefono,
                                         "Domicilio", domicilio,
                                         "Numero", numero,
                                         "Piso", piso,
                                         "Dpto", dpto,
                                         "Localidad", localidad,
                                         "Fecha_Nac", fechaNac,
                                         "Codigo_Postal", codigoPostal,
                                         "Estado_Cliente", habilitado);
        }

        public void nuevo()  // persisto un cliente nuevo
        {
            DB.correrProcedimiento("Cliente_NUEVO",
                                         "DNI_Cliente", dni,
                                         "Nombre", nombre,
                                         "Apellido", apellido,
                                         "Mail", mail,
                                         "Telefono", telefono,
                                         "Domicilio", domicilio,
                                         "Numero", numero,
                                         "Piso", piso,
                                         "Dpto", dpto,
                                         "Localidad", localidad,
                                         "Fecha_Nac", fechaNac,
                                         "Codigo_Postal", codigoPostal,
                                         "Estado_Cliente", habilitado);
        }

         public static DataTable getXsConFiltros( String X, // "CLIENTES"
                                                String nombre,
                                                String apellido,
                                                decimal DNI)        // obtengo un tipo de usuarios que cumplen con los filtros
        {
            return DB.correrFuncionDeTabla("GET_" + X + "_CON_FILTROS",
                               "Nombre", nombre,
                               "Apellido", apellido,
                               "DNI_Cliente", DNI);
        }

        public void inhabilitar()    // inhabilito un usuario
        {
            DB.correrProcedimiento("_INHABILITAR",
                                            "id", id);
        }

        public void habilitar()    // habilito un usuario
        {
            DB.correrProcedimiento("_HABILITAR",
                                            "id", id);
        }
    }
}
