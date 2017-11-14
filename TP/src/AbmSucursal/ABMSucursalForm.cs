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
        public ABMSucursalForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
        }
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try{
                DataRow fila = ((DataRowView)DataGridViewSucursal.SelectedRows[0].DataBoundItem).Row;
                new EditarSucursalForm(this, new Sucursal(fila)).abrir();
            }catch (ArgumentOutOfRangeException) 
            { Error.show("Seleccion un elemento de la Tabla"); }
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
            try{
                Sucursal.inhabilitar((int)DataGridViewSucursal.SelectedRows[0].Cells["ID_SUCURSAL"].Value);    // Obtengo el id de la sucursal seleccionada y la inhabilita
                CargarTabla();
            }catch (ArgumentOutOfRangeException) 
            { Error.show("Seleccion un elemento de la Tabla"); }
        }
    }
}
