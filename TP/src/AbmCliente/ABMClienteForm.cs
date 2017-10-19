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
            DataRow fila = ((DataRowView)DataGridViewClientes.SelectedRows[0].DataBoundItem).Row;    // Obtengo fila seleccionada
            new EditarClienteForm(this, new Cliente(fila)).abrir();        
        }

    }
}
