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
            telefono = Convert.ToDecimal(data["Telefono"]);
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
            DB.correrProcedimiento("CLIENTE_UPDATE",
                                         "id", id,
                                         "nombre", nombre,
                                         "apellido", apellido,
                                         "dni", dni,
                                         "mail", mail,
                                         "telefono", telefono,
                                         "domicilio", domicilio,
                                         //"Numero", numero,
                                         //"Piso", piso,
                                         //"Dpto", dpto,
                                         //"Localidad", localidad,
                                         "fechaNac", fechaNac,
                                         "codigoPostal", codigoPostal,
                                         "habilitado", habilitado);
        }

        public static void nuevo(String nombre, String apellido, Decimal dni ,String mail, Decimal telefono, String domicilio,
                            DateTime fechaNac, Decimal codigoPostal, Boolean habilitado)  // persisto un cliente nuevo
        {
            DB.correrProcedimiento("CLIENTE_NUEVO",
                                         "nombre", nombre,
                                         "apellido", apellido,
                                         "dni", dni,
                                         "mail", mail,
                                         "telefono", telefono,
                                         "domicilio", domicilio,
                                         //"Numero", numero,
                                         //"Piso", piso,
                                         //"Dpto", dpto,
                                         //"Localidad", localidad,
                                         "fechaNac", fechaNac,
                                         "codigoPostal", codigoPostal,
                                         "habilitado", habilitado);
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
