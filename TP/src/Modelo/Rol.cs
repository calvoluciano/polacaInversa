using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Rol
    {
        public static Rol rolSeleccionado;
        public byte id;
        public String nombre;
        public String detalle;
        public Boolean habilitado;

        public Rol(DataRow data)
        {
            id = (byte)data["ID_ROL"];
            nombre = (String)data["Nombre"];
            //Ver si luego lo necesitamos
            //detalle = (String)data["Descripcion"];
            habilitado = (Boolean)data["Habilitado"];
        }

        public Rol() { }

        public override String ToString()
        {
            return nombre;
        }


        public List<Acceso> getAccesos() // obtengo las funcionalidades de un rol
        {
            DataTable data = DB.correrFuncionDeTabla("ROL_GET_ACCESOS", "rolId", id);

            return data.AsEnumerable()
                        .Select(fila => RepoAccesos.get((byte)fila["Id_Acceso"]))
                        .ToList();
        }

        public void editar(DataTable accesos)                                           // persisto los cambios
        {

            SqlCommand comando = DB.nuevoProcedimiento("ROL_UPDATE",
                                                        "id", id,
                                                        "nombre", nombre,
                                                        "detalle", detalle,
                                                        "habilitado", habilitado);
            SqlParameter parametroFuncionalidades = new SqlParameter("@funcionalidades", SqlDbType.Structured); // dado que uno de los parametros es una tabla tengo que hacer un poco de magia
            parametroFuncionalidades.TypeName = "POLACA_INVERSA.TABLA_ROL_X_FUNCIONALIDAD";
            parametroFuncionalidades.Value = accesos;
            comando.Parameters.Add(parametroFuncionalidades);
            DB.ejecutarProcedimiento(comando);
        }

        public void nuevo(DataTable accesos)                                           // persisto el nuevo rol
        {
            SqlCommand comando = DB.nuevoProcedimiento("ROL_NUEVO",
                                                        "nombre", nombre,
                                                        "detalle", detalle,
                                                        "habilitado", habilitado);
            SqlParameter parametroFuncionalidades = new SqlParameter("@funcionalidades", SqlDbType.Structured); // dado que uno de los parametros es una tabla tengo que hacer un poco de magia
            parametroFuncionalidades.TypeName = "POLACA_INVERSA.TABLA_ROL_X_FUNCIONALIDAD";
            parametroFuncionalidades.Value = accesos;
            comando.Parameters.Add(parametroFuncionalidades);
            DB.ejecutarProcedimiento(comando);
        }

        public static void inhabilitar(byte id)         // inhabilito un rol
        {
            DB.correrProcedimiento("ROL_INHABILITAR",
                                    "rol", id);
        }

        public static DataTable getRoles()              // obtengo todos los roles
        {
            return DB.correrQuery(@"SELECT  id_Rol,
                                            Nombre_Rol AS Nombre, 
                                            Habilitado AS Habilitado
                                    FROM POLACA_INVERSA.Roles");
        }
    }
}
