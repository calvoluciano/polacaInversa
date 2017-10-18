using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PagoAgilFrba.Modelo;
using PagoAgilFrba.AbmSucursal;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class ABMSucursalForm : PagoAgilFrba.AbmSucursal.TablaSucursalForm
    {
        public ABMSucursalForm()
        {
            InitializeComponent();
        }
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)DataGridViewUsuario.SelectedRows[0].DataBoundItem).Row;
            new EditarSucursalForm(this, new Sucursal(fila)).abrir();
        }
        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            new NuevaSucursalForm(this).abrir();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            Sucursal.inhabilitar((int)DataGridViewUsuario.SelectedRows[0].Cells["usua_id"].Value);    // Obtengo el id del chofer seleccionado y lo inhabilito
            CargarTabla();
        }
    }
}
