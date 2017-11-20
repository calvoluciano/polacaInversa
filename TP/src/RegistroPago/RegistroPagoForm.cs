using PagoAgilFrba.AbmCliente;
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

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPagoForm : PagoAgilFrba.Modelo.ReturnForm
    {
        public RegistroPagoForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
        }

        private Cliente cliente = null;

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                textBoxNombreCliente.Text = cliente.nombre;
            }
        }

        public override void Refrescar()
        {
            //cargarClientes();
        }

        void cargarClientes()
        {
            /*
            comboBoxCliente.Items.Clear();                                    // saco los items del combobox
            comboBoxCliente.DataSource = Cliente.getClientesConFiltros("", "", 0);    // obtengo y agrego los nuevos

            comboBoxCliente.DisplayMember = "DNI";
            comboBoxCliente.ValueMember = "{ID_CLIENTE}{Nombre}";
            
            comboBoxCliente.SelectedIndex = -1;*/
        }

        private void buttonSeleccionarCliente_Click(object sender, EventArgs e)
        {
            Cliente seleccionado = new SeleccionarClienteForm(this).getCliente();   // selecciono cliente
            if (seleccionado != null) Cliente = seleccionado;  
        }
    }
}
