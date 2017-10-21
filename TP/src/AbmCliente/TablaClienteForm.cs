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

        public DataGridView DataGridViewClientes
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
            dataGridClientes.DataSource = Cliente.getXsConFiltros("Clientes", // obtengo los clientes y los cargo en la tabla
                                                                        Nombre,
                                                                        Apellido,
                                                                        DNI);
        }

        public override void Refrescar()
        {
            base.Refrescar();
            CargarTabla();
            DataGridViewClientes.Columns["Estado_Cliente"].Visible = false;              // oculto columna que no quiero mostrar
            DataGridViewClientes.Columns["Estado_Cliente"].HeaderText = "Habilitado";    // cambio nombre visible de columna
        }

        private void validar()
        {
           if (DNI < 0) throw new ValorNegativoException("DNI");
        }
        
        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                validar();         // valido los datos ingresados
                CargarTabla();    // cargo la tabla
            }
            catch (Exception ex)
            {
               if (ex is FormatException || ex is ValorNegativoException) Error.show(ex.Message);
                else throw;
            }

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            dni.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            CargarTabla();
        }

        private void TablaClienteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
