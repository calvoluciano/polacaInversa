using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Modelo
{
    public class Acceso
    {
        public byte id;
        public String acceso;
        public Type ventanaAAbrir;

        public Acceso(byte id, Type ventanaAAbrir)
        {
            this.id = id;
            this.acceso = (String)DB.correrFuncion("ACCESO_GET_NOMBRE", "accesoId", id);
            this.ventanaAAbrir = ventanaAAbrir;
        }

        public void elegir(Form caller) // elijo una funcionalidad y abro su ventana correspondiente
        {
            ReturnForm ventana = (ReturnForm)Activator.CreateInstance(ventanaAAbrir, caller);
            ventana.abrir();
        }

        public override string ToString()
        {
            return acceso;
        }

        public static DataTable getTablaDe(byte idRol)  // obtengo la tabla de funcionalidades de un rol
        {
            return DB.correrFuncionDeTabla("FUNCIONALIDADES_GET_TABLA_DE_ROL",
                                            "Id_Rol", idRol);
        }

        public static DataTable getTablaDeDisponibles(byte idRol)
        {
            return DB.correrFuncionDeTabla("FUNCIONALIDADES_GET_TABLA_DE_ROL_DISPONIBLES",
                                            "Id_Rol", idRol);
        }

    }
}
