using PagoAgilFrba.Modelo;
using PagoAgilFrba.Modelo.Exceptions;
using System;
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

        public DataGridView DataGridClientes
        {
            get { return dataGridClientes; }
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
            dataGridClientes.DataSource = Cliente.getClientesConFiltros(// obtengo los clientes y los cargo en la tabla
                                                                        Nombre,
                                                                        Apellido,
                                                                        DNI);
        }

        public override void Refrescar()
        {
            base.Refrescar();
            CargarTabla();
            DataGridClientes.Columns["ID_CLIENTE"].Visible = false; 
            DataGridClientes.Columns["Habilitado"].Visible = false;              // oculto columna que no quiero mostrar
            DataGridClientes.Columns["Habilitado"].HeaderText = "Habilitado";    // cambio nombre visible de columna
        }

        private void validar()
        {
           if (DNI < 0) throw new ValorNegativoException("DNI");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            dni.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            CargarTabla();
        }

        private void buttonFiltrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                validar();                                                                      // valido los datos ingresados
                CargarTabla();                                                                  // cargo la tabla
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is ValorNegativoException) Error.show(ex.Message);
                else throw;
            }
        }
    }
}
