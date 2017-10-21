using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PagoAgilFrba.Modelo;
using PagoAgilFrba.AbmSucursal;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class ABMEmpresaForm : PagoAgilFrba.AbmEmpresa.TablaEmpresaForm
    {
       public ABMEmpresaForm()
        {
            InitializeComponent();
        }
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)DataGridViewUsuario.SelectedRows[0].DataBoundItem).Row;
            new EditarEmpresaForm(this, new Empresa(fila)).abrir();
        }
        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            new NuevaEmpresaForm(this).abrir();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            //Sucursal.inhabilitar((int)DataGridViewUsuario.SelectedRows[0].Cells["usua_id"].Value);    // Obtengo el id de la sucursal seleccionada y la inhabilita
            CargarTabla();
        }
    }
}
