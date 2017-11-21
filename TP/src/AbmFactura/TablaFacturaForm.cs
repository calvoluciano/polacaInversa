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

namespace PagoAgilFrba.AbmFactura
{
    public partial class TablaFacturaForm : ReturnForm
    {
        public TablaFacturaForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
        }

        public TablaFacturaForm()
        {
            InitializeComponent();
        }

        private Cliente cliente;

        public override void Refrescar()
        {
            base.Refrescar();
            CargarTabla();
            DataGridViewFactura.Columns["ID_FACTURA"].HeaderText = "Num Fctura";  // oculto columna que no quiero mostrar
            //DataGridViewUsuario.Columns["Chofer_Habilitado"].HeaderText = "Habilitado"; //  cambio nombre visible de columna
            //DataGridViewFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public DataGridView DataGridViewFactura
        {
            get { return dataGridViewFacturas; }
        }

        internal Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                
            }
        }

        public int NumeroFactura
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxNumeroFactura.Text)) return 0;

                return Convert.ToInt32(textBoxNumeroFactura.Text);
            }
        }
        public Decimal CUIT
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxCuit.Text)) return 0;

                return Convert.ToDecimal(textBoxCuit.Text);
            }
        }

        public Decimal DNICliente
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxDniCliente.Text)) return 0;

                return Convert.ToDecimal(textBoxDniCliente.Text);
            }
        }
        public Decimal Total
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxTotal.Text)) return 0;

                return Convert.ToDecimal(textBoxTotal.Text);
            }
        }


        protected virtual void CargarTabla()
        {
            dataGridViewFacturas.DataSource = Factura.getXsConFiltros(NumeroFactura, // obtengo las Facturas y las cargo en la tabla
                                                                        DNICliente,
                                                                        CUIT,
                                                                        Total);
        }

        private void validar()
        {
            if (NumeroFactura < 0) throw new ValorNegativoException("Numero Factura");
            if (CUIT < 0) throw new ValorNegativoException("Cuit Empresa");
            if (DNICliente < 0) throw new ValorNegativoException("DNI Cliente");
            if (Total < 0) throw new ValorNegativoException("Total");
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
            textBoxCuit.Text = "";
            textBoxDniCliente.Text = "";
            textBoxNumeroFactura.Text = "";
            textBoxTotal.Text = "";
        }
    }
}

