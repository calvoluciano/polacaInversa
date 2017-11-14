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
    public partial class SeleccionarRolYSucursalForm : ReturnForm
    {
        public SeleccionarRolYSucursalForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
        }

        public override void Refrescar()
        {
            comboBox1.Items.Clear();                                    // saco los items del combobox
            Usuario.getRoles().ForEach(r => comboBox1.Items.Add(r));    // obtengo y agrego los nuevos
            comboBoxSucursal.Items.Clear();
            Usuario.getSucursales().ForEach(s => comboBoxSucursal.Items.Add(s));
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBoxSucursal.SelectedItem != null)
            {   // si hay un rol seleccionado...
                Rol.rolSeleccionado = (Rol)comboBox1.SelectedItem;
                Usuario.sucursalSeleccionada = (Sucursal)comboBoxSucursal.SelectedItem;
                new SeleccionarFuncionalidadForm(this).abrir();     // lo elijo y busco sus funcionalidades
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
