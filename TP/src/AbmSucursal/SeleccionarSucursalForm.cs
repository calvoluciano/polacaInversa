using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Modelo;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class SeleccionarSucursalForm : PagoAgilFrba.AbmSucursal.TablaSucursalForm
    {
        private Sucursal sucursalSeleccionada;

        public SeleccionarSucursalForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)DataGridViewUsuario.SelectedRows[0].DataBoundItem).Row;    // obtengo la fila seleccionada

            if (!(Boolean)fila["Sucursal_Habilitada"])    // si la sucursal no está habilitada...
            {
                Error.show("No se puede seleccionar una sucursal inhabilitada.");
                return;
            }

            sucursalSeleccionada = new Sucursal(fila);      // creo una sucursal de la fila seleccionada
            this.Close();
        }

        public Sucursal getSucursal()
        {
            abrir();
            return sucursalSeleccionada;                  // devuelvo la sucursal seleccionada
        }
    }
}
