using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Modelo;
using PagoAgilFrba.Modelo.Exceptions;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class TablaEmpresaForm : ReturnForm
    {

        public TablaEmpresaForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
            comboBoxRubro.Items.Add("");
            Empresa.getDetalle().ForEach(detalle => comboBoxRubro.Items.Add(detalle));
        }


        public TablaEmpresaForm()
        {
            InitializeComponent();
        }

        public override void Refrescar()
        {
            base.Refrescar();
            CargarTabla();
            DataGridViewEmpresas.Columns["ID_EMPRESA"].Visible = false;  // oculto columna que no quiero mostrar
            DataGridViewEmpresas.Columns["ESTADO_EMPRESA"].HeaderText = "Habilitado"; //  cambio nombre visible de columna
            DataGridViewEmpresas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public DataGridView DataGridViewEmpresas
        {
            get { return dataGridViewEmpresas; }
        }
        public string Nombre
        {
            get
            {
                return textBoxNombre.Text;
            }
        }
        public Decimal Cuit
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxCuit.Text)) return 0;

                return Convert.ToDecimal(textBoxCuit.Text);
            }
        }
        public String Rubro
        {
            get
            {
                if (string.IsNullOrWhiteSpace((string)comboBoxRubro.SelectedItem)) return "";

                return (String)comboBoxRubro.SelectedItem;
            }
        }

        protected virtual void CargarTabla()
        {
            dataGridViewEmpresas.DataSource = Empresa.getXsConFiltros(  // obtengo las empresas y las cargo en la tabla
                                                                Nombre,
                                                                Cuit,
                                                                Rubro);
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void codigoPostal_TextChanged(object sender, EventArgs e)
        {

        }

        private void validar()
        {
            if (Cuit < 0) throw new ValorNegativoException("Cuit");
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
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

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxCuit.Text = "";
            comboBoxRubro.SelectedItem = null;
        }
    }
}
