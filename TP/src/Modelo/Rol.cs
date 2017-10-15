using System;
using System.Collections.Generic;
using System.Data;
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
            id = (byte)data["id_Rol"];
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
            DataTable data = DB.correrFuncionDeTabla("ROL_GET_FUNCIONALIDADES", "rolId", id);

            return data.AsEnumerable()
                        .Select(fila => RepoAccesos.get((byte)fila["cod_func"]))
                        .ToList();
        }
    }
}
