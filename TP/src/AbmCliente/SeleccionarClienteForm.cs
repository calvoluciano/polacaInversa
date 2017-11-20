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
    public partial class SeleccionarClienteForm : PagoAgilFrba.AbmCliente.TablaClienteForm
    {
        private Cliente clienteSeleccionado;

        public SeleccionarClienteForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }

        public Cliente getCliente()
        {
            abrir();
            return clienteSeleccionado;                  
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)DataGridClientes.SelectedRows[0].DataBoundItem).Row;    // obtengo la fila seleccionada

            if (!(Boolean)fila["HABILITADO"])    
            {
                Error.show("No se puede seleccionar un Cliente inhabilitada.");
                return;
            }

            clienteSeleccionado = new Cliente(fila);      
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
