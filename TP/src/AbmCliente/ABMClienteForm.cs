using PagoAgilFrba.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class ABMClienteForm : TablaClienteForm
    {
        public ABMClienteForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow fila = ((DataRowView)DataGridClientes.SelectedRows[0].DataBoundItem).Row;    // Obtengo fila seleccionada
                new EditarClienteForm(this, new Cliente(fila)).abrir();
            }
            catch (ArgumentOutOfRangeException) { Error.show("Seleccion un elemento de la Tabla"); }

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            new NuevoClienteForm(this).abrir();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            try{
                Cliente.inhabilitar((int)DataGridClientes.SelectedRows[0].Cells["ID_CLIENTE"].Value);   // Obtengo el id del cliente seleccionado y lo inhabilito
                CargarTabla();
             }catch (ArgumentOutOfRangeException) 
            { Error.show("Seleccion un elemento de la Tabla"); }
        }

    }
}
