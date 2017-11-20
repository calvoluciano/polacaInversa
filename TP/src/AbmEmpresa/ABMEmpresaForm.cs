using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PagoAgilFrba.Modelo;
using PagoAgilFrba.AbmSucursal;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class ABMEmpresaForm : PagoAgilFrba.AbmEmpresa.TablaEmpresaForm
    {
        public ABMEmpresaForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow fila = ((DataRowView)DataGridViewEmpresas.SelectedRows[0].DataBoundItem).Row;
                new EditarEmpresaForm(this, new Empresa(fila)).abrir();
            }
            catch (ArgumentOutOfRangeException)
            { Error.show("Seleccion un elemento de la Tabla"); }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            new EditarEmpresaForm(this).abrir();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            try
            {
                int cantPendientes = Empresa.tieneTodasFacturasCobradasRendidas((int)DataGridViewEmpresas.SelectedRows[0].Cells["ID_EMPRESA"].Value);
                if (cantPendientes > 0)
                {
                    Error.show("No se pueder dar de baja la Empresa, aun tiene " + cantPendientes + "facturas pendientes de Cobrar y/o Rendir." );
                }
                else
                {
                    Empresa.inhabilitar((int)DataGridViewEmpresas.SelectedRows[0].Cells["ID_EMPRESA"].Value);    // Obtengo el id de la sucursal seleccionada y la inhabilita
                    CargarTabla();
                }
            }
            catch (ArgumentOutOfRangeException)
            { Error.show("Seleccion un elemento de la Tabla"); }
            catch (SqlException) { }
        }
    }
}
