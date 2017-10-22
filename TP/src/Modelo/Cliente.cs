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
            id = (int)data["ID_CLIENTE"];
            apellido = (String)data["Apellido"];
            nombre = (String)data["Nombre"];
            dni = Convert.ToDecimal(data["DNI"]);
            mail = (String)data["Mail"];
            //telefono = (decimal)data["Telefono"];
            domicilio = (String)data["Domicilio"];
            //numero = (decimal)data["Numero"];
            //piso = (String)data["Piso"];
            //localidad = (String)data["Localidad"];
            fechaNac = (DateTime)data["Fecha Nacimiento"];
            codigoPostal = Convert.ToDecimal(data["Codigo Postal"]);
            habilitado = (Boolean)data["HABILITADO"];
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

        public static DataTable getClientesConFiltros(  String nombre,  // "CLIENTES"
                                                  String apellido,
                                                  decimal DNI)        // obtengo un tipo de usuarios que cumplen con los filtros
        {
            return DB.correrFuncionDeTabla("GET_CLIENTES_CON_FILTROS",
                               "nombre", nombre,
                               "apellido", apellido,
                               "dni", DNI);
        }

        public static void inhabilitar(int id_cliente)    // inhabilito un usuario
        {
            DB.correrProcedimiento("_INHABILITAR",
                                            "id", id_cliente);
        }

        public static void habilitar(int id_cliente)    // habilito un usuario
        {
            DB.correrProcedimiento("_HABILITAR",
                                            "id", id_cliente);
        }
    }
}
