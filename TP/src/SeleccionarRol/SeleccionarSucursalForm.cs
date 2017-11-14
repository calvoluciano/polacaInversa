using PagoAgilFrba.Modelo;
using PagoAgilFrba.SeleccionarFuncionalidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.SeleccionarRol
{
    public partial class SeleccionarSucursalForm : ReturnForm
    {
        public SeleccionarSucursalForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
        }

        public override void Refrescar()
        {
            comboBoxSucursal.Items.Clear();                                    // saco los items del combobox
            Usuario.getSucursales().ForEach(r => comboBoxSucursal.Items.Add(r));    // obtengo y agrego los nuevos

            comboBoxSucursal.DisplayMember = "nombre";
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (comboBoxSucursal.SelectedItem != null)
            {   // si hay un rol seleccionado...
                Usuario.sucursalSeleccionada= (Sucursal)comboBoxSucursal.SelectedItem;
                if (!Sucursal.validarSucursalHabilitada(Usuario.sucursalSeleccionada.id)) Error.show("Sucursal seleccionada se encuentra inhabilitada");
                else
                    new SeleccionarFuncionalidadForm(this).abrir();     // lo elijo y busco sus funcionalidades
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
