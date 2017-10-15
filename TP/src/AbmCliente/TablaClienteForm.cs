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
    public partial class TablaClienteForm : ReturnForm
    {

        public TablaClienteForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }

        public TablaClienteForm()
        {
            InitializeComponent();
        }

        public DataGridView DataGridViewUsuario
        {
            get { return dataGridView1; }
        }

        public string Nombre
        {
            get
            {
                return nombre.Text;
            }
        }
        public decimal DNI
        {
            get
            {
                if (string.IsNullOrWhiteSpace(dni.Text)) return 0;

                return decimal.Parse(dni.Text);
            }
        }
        public string Apellido
        {
            get
            {
                return apellido.Text;
            }
        }

        protected virtual void CargarTabla()
        {
            dataGridView1.DataSource = Cliente.getXsConFiltros("Clientes", // obtengo los clientes y los cargo en la tabla
                                                                        Nombre,
                                                                        Apellido,
                                                                        DNI);
        }

        public override void Refrescar()
        {
            base.Refrescar();
            CargarTabla();
            DataGridViewUsuario.Columns["Estado_Cliente"].Visible = false;              // oculto columna que no quiero mostrar
            DataGridViewUsuario.Columns["Estado_Cliente"].HeaderText = "Habilitado";    // cambio nombre visible de columna
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void dni_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
