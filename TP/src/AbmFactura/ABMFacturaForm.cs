using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PagoAgilFrba.Modelo;
using PagoAgilFrba.AbmFactura;

namespace PagoAgilFrba.AbmFactura
{
    public partial class ABMFacturaForm : PagoAgilFrba.AbmFactura.TablaFacturaForm
    {

       public ABMFacturaForm(ReturnForm caller)
           : base(caller)
        {
            InitializeComponent();
        }
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)DataGridViewFactura.SelectedRows[0].DataBoundItem).Row;
            Factura facturaSeleccionada = new Factura(fila);

            if (!facturaSeleccionada.estaCobrada())
                new EditarFacturaForm(this, facturaSeleccionada).abrir();
            else
                Error.show("La Factura seleccionada esta cobrada, por lo tanto no puede ser modificada!");
        }
        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            new EditarFacturaForm(this).abrir();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            //Sucursal.inhabilitar((int)DataGridViewUsuario.SelectedRows[0].Cells["usua_id"].Value);    // Obtengo el id de la sucursal seleccionada y la inhabilita
            //CargarTabla();
        }
    }
}
