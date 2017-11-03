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
            DataRow fila = ((DataRowView)DataGridViewEmpresas.SelectedRows[0].DataBoundItem).Row;
            new EditarEmpresaForm(this, new Empresa(fila)).abrir();
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
             try{        
                Empresa.inhabilitar((int)DataGridViewEmpresas.SelectedRows[0].Cells["ID_EMPRESA"].Value);    // Obtengo el id de la sucursal seleccionada y la inhabilita
                CargarTabla();
            }
            catch (SqlException) { }
        }
    }
}
