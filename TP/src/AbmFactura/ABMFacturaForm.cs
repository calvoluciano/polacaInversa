using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PagoAgilFrba.Modelo;
using PagoAgilFrba.AbmFactura;
using PagoAgilFrba.Modelo.Exceptions;

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
            try
            {
                DataRow fila = ((DataRowView)DataGridViewFactura.SelectedRows[0].DataBoundItem).Row;

                if (Factura.estaCobrada(Convert.ToDecimal(fila["ID_FACTURA"]))) throw new FacturaYaCobradaException(fila["ID_FACTURA"].ToString());

                Factura facturaSeleccionada = new Factura(fila);
                new EditarFacturaForm(this, facturaSeleccionada).abrir();

            }
            catch (ArgumentOutOfRangeException) { Error.show("Seleccion un elemento de la Tabla"); }
            catch (Exception exception)
            {
                if (exception is FacturaYaCobradaException) Error.show(exception.Message);
                    else throw;
            } 
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
            try
            {
                DataRow fila = ((DataRowView)DataGridViewFactura.SelectedRows[0].DataBoundItem).Row;

                if (Factura.estaCobrada(Convert.ToDecimal(fila["ID_FACTURA"]))) throw new FacturaYaCobradaException(fila["ID_FACTURA"].ToString());

                Factura.inhabilitar(Convert.ToDecimal(fila["ID_FACTURA"]));

                MessageBox.Show("La Factura a sido deshabiltada", "Factura", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

                CargarTabla();

            }
            catch (ArgumentOutOfRangeException) { Error.show("Seleccion un elemento de la Tabla"); }
            catch (Exception exception)
            {
                if (exception is FacturaYaCobradaException) Error.show(exception.Message);
                    else throw;
            } 

            //Sucursal.inhabilitar((int)DataGridViewUsuario.SelectedRows[0].Cells["usua_id"].Value);    // Obtengo el id de la sucursal seleccionada y la inhabilita
            //CargarTabla();
        }
    }
}
