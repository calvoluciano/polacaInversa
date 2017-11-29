using PagoAgilFrba.Modelo;
using PagoAgilFrba.Modelo.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Rendicion
{
    public partial class RendicionForm : PagoAgilFrba.Modelo.ReturnForm
    {
        DataTable tablaFacturas = new DataTable();
        double comision;
        private Empresa empresaSeleccionada = null;

        public RendicionForm (ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();

            cargarEmpresas();

            dateTimePickerFechaRendicion.MaxDate = DateTime.Today;

            tablaFacturas.Columns.Add("Numero Factura", typeof(decimal));
            tablaFacturas.Columns.Add("Empresa", typeof(string));
            tablaFacturas.Columns.Add("Cliente", typeof(string));
            tablaFacturas.Columns.Add("Monto", typeof(float));
            tablaFacturas.Columns.Add("Fecha de Pago", typeof(DateTime));
        }

        public DateTime FechaRendicion
        {
            get
            {
                return dateTimePickerFechaRendicion.Value;
            }

            set
            {
                dateTimePickerFechaRendicion.Value = value;
            }
        }

        public Decimal PorcentajeComision
        {
            get
            {
                return Convert.ToDecimal( numericUpDownPorcentajeComision.Value);
            }
        }

        public Double Total
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxTotal.Text)) return 0;

                return Convert.ToDouble(textBoxTotal.Text);
            }

            set
            {
                textBoxTotal.Text = value.ToString();
            }
        }

        public Int32 CantidadFacturas
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxCantidadFacturas.Text)) return 0;

                return Convert.ToInt32(textBoxCantidadFacturas.Text);
            }

            set
            {
                textBoxCantidadFacturas.Text = value.ToString();
            }
        }

        void cargarEmpresas()
        {
            Empresa.getEmpresas().ForEach(r => comboBoxEmpresa.Items.Add(r));    // obtengo y agrego los nuevos

            comboBoxEmpresa.DisplayMember = "nombre";
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCargarFacturasPagas_Click(object sender, EventArgs e)
        {
            try{
                limpiarFacturas();
                tablaFacturas.Rows.Clear();

                validarDatosBusquedaRendicion();

                if (!Factura.esEmpresaYFecharendida(empresaSeleccionada.id, FechaRendicion))
                {
                    mensajeDeErrorEmpresa();
                    return;
                }

                tablaFacturas = Factura.getFacturasARendirDeEmpresa(empresaSeleccionada.id, FechaRendicion);

                foreach (DataRow row in tablaFacturas.Rows)
                {
                    Total += Convert.ToDouble(row["Monto"]);
                }

                actualizarTablaFacturas();

            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if ( exception is CampoVacioException 
                    ) Error.show(exception.Message);
                else throw;
            } 
        }

        private void actualizarTablaFacturas()
        {
            CantidadFacturas = tablaFacturas.Rows.Count;
            dataGridView1.DataSource = tablaFacturas;
        }

        private void validarDatosBusquedaRendicion()
        {
            if (comboBoxEmpresa.SelectedItem == null) throw new CampoVacioException("Empresa");
        }

        private void mensajeDeErrorEmpresa()
        {
            MessageBox.Show("No se encontraron facturas\n *Las facturas ya se encuentran rendidas en este mes para esta empresa*", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void limpiarFacturas()
        {
            Total = 0;
            CantidadFacturas = 0;
            tablaFacturas.Rows.Clear();
            numericUpDownPorcentajeComision.Value = 0;
            textBoxImporteComision.Text = "0";
            actualizarTablaFacturas();
        }

        private void comboBoxEmpresa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxEmpresa.SelectedItem != null)
            {
                empresaSeleccionada = (Empresa)comboBoxEmpresa.SelectedItem;
                if (!empresaSeleccionada.habilitado)
                {
                    Error.show("No se puede seleccionar una empresa inhabilitada.");
                    comboBoxEmpresa.SelectedItem = null;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarFacturas();
        }

        private void numericUpDownPorcentajeComision_ValueChanged(object sender, EventArgs e)
        {
            comision = Total * Convert.ToDouble(PorcentajeComision) / 100;
            textBoxImporteComision.Text = comision.ToString() + " $";
            textBoxTotal.Text = (Total - comision).ToString();
        }

        public void validarDatosRendicion()
        {
            if (tablaFacturas.Rows.Count == 0) if (tablaFacturas.Rows.Count==0) throw new EmptyFieldException("Tabla Facturas");
            if (comboBoxEmpresa.SelectedItem == null) throw new CampoVacioException("Empresa");
        }

        private void buttonRendirFacturas_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatosRendicion();

                Factura.rendir(tablaFacturas, PorcentajeComision, comision, CantidadFacturas, Total, empresaSeleccionada.id, FechaRendicion);

                MessageBox.Show("La rendicion ha sido procesada exitosamente", "Rendicion", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);

                limpiarFacturas();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is EmptyFieldException ||
                    exception is CampoVacioException) Error.show(exception.Message);
                else throw;
            } 
        }

    }
}
