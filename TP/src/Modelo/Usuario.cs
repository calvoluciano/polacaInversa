using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Modelo
{
    public class Usuario
    {
        public int id;
        public String nombreDeUsuario;
        public byte[] contrasenia;
        public Boolean habilitado;

        public Usuario(DataRow data)
        {
            New(data);
            habilitado = (Boolean)data["Usuario_Habilitado"];
        }

        public Usuario() { }

        protected void New(DataRow data)
        {
            id = (int)data["id_Usuario"];
        }

        public static int? usuarioSeleccionado;

        public static byte[] encriptar(string texto)    // encripto una contraseña
        {
            return new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(texto), 0, Encoding.UTF8.GetByteCount(texto));
        }

        public static void cargar(String username)      // cargo usuario seleccionado por username
        {
            usuarioSeleccionado = (int)DB.correrFuncion("USUARIO_GET_ID", "usuario", username);
        }

        public static List<Rol> getRoles()              // obtengo los roles del usuario seleccionado
        {
            DataTable data = DB.correrFuncionDeTabla("USUARIO_GET_ROLES", "id_Usuario", usuarioSeleccionado);

            return data.AsEnumerable()
                        .Select(fila => new Rol(fila))
                        .ToList();
        }

        public static void rolUpdate(int idUsuario, byte idRol, Boolean habilitado) // modifico el acceso de un usuario a un rol
        {
            DB.correrProcedimiento("USUARIO_ROL_UPDATE",
                                    "idUsuario", idUsuario,
                                    "idRol", idRol,
                                    "habilitado", habilitado);
        }

        public static DataTable getTablaRolX(    // "USUARIOS" 
                                        String nombre,
                                        String apellido,
                                        decimal DNI,
                                        byte rol)           // obtengo un tipo de usuarios que cumplen con los filtros y tienen un rol determinado
        {
            return DB.correrFuncionDeTabla("GET_TABLA_ROL",
                                            "nombre", nombre,
                                            "apellido", apellido,
                                            "DNI", DNI,
                                            "rol", rol);
        }
    }
}
