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

namespace PagoAgilFrba.Devoluciones
{
    public partial class DevolucionesForm : PagoAgilFrba.Modelo.ReturnForm
    {
        DataTable tablaFacturasPagas = new DataTable();
        DataTable tablaFacturasDevolucion = new DataTable();
        Devolucion devolucion = new Devolucion();

        public DevolucionesForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
            setearTablaFacturasDevolucion();
            //dateTimePickerFechaPagoHasta.MaxDate = DateTime.Today;
        }

        public Decimal DNICliente
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxDNICliente.Text)) return 0;

                return Convert.ToDecimal(textBoxDNICliente.Text);
            }

            set
            {
                textBoxDNICliente.Text = value.ToString();
            }
        }

        public string Motivo
        {
            get
            {
                return richTextBoxMotivoDevolucion.Text;
            }

            set
            {
                richTextBoxMotivoDevolucion.Text = value;
            }
        }

        public DateTime FechaDesde
        {
            get
            {
                return dateTimePickerFechaPagoDesde.Value;
            }

            set
            {
                dateTimePickerFechaPagoDesde.Value = value;
            }
        }

        public DateTime FechaHasta
        {
            get
            {
                return dateTimePickerFechaPagoHasta.Value;
            }

            set
            {
                dateTimePickerFechaPagoHasta.Value = value;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setearTablaFacturasDevolucion()
        {
            tablaFacturasDevolucion.Columns.Add("Cliente", typeof(string));
            tablaFacturasDevolucion.Columns.Add("Factura", typeof(Decimal));
            tablaFacturasDevolucion.Columns.Add("Total", typeof(float));
            tablaFacturasDevolucion.Columns.Add("Fecha Vencimiento", typeof(DateTime));

            tablaFacturasDevolucion.PrimaryKey = new DataColumn[] { tablaFacturasDevolucion.Columns["Factura"] };
        }

        private void validarFiltroBusqueda()
        {
            if (DNICliente < 0) throw new ValorNegativoException("DNI Cliente");
            ComparadorFechas comparador = new ComparadorFechas();
            if (comparador.esMenor(FechaHasta,FechaDesde)) throw new rangoFechasException("Fecha Hasta/Desde");
        }

        private void buttonCargarFacturasPagas_Click(object sender, EventArgs e)
        {
            try
            {
                validarFiltroBusqueda();

                tablaFacturasPagas.Rows.Clear();
                tablaFacturasPagas = Factura.getFacturasPagasConfiltro(DNICliente,FechaDesde,FechaHasta);
                actualizarTablaFacturasPagas();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is ValorNegativoException ||
                    exception is FormatException ||
                    exception is rangoFechasException
                    ) Error.show(exception.Message);
                else throw;
            } 
        }

        private void actualizarTablaFacturasDevolucion()
        {
            dataGridViewDevoluciones.DataSource = tablaFacturasDevolucion;
        }

        private void limpiarPagos()
        {
            tablaFacturasPagas.Rows.Clear();
            DNICliente = 0;
            actualizarTablaFacturasPagas();
        }

        private void actualizarTablaFacturasPagas()
        {
            dataGridViewFacturasPagas.DataSource = tablaFacturasPagas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarPagos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewFacturasPagas.Rows.Count == 0) return;
            if (dataGridViewFacturasPagas.SelectedRows.Count != 1) return;

            DataRow fila = ((DataRowView)dataGridViewFacturasPagas.SelectedRows[0].DataBoundItem).Row;

            if (esFacturaYaAgregada(Convert.ToDecimal(fila["Factura"])))
            {
                MessageBox.Show("La factura ya fue ingresada para su devolucion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tablaFacturasDevolucion.ImportRow(fila);
            actualizarTablaFacturasDevolucion();
        }

        public Boolean esFacturaYaAgregada(Decimal idFactura)
        {
            DataRow foundRow = tablaFacturasDevolucion.Rows.Find(idFactura);

            if (foundRow != null)
                return true;

            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiarDevoluciones();
        }

        private void limpiarDevoluciones()
        {
            tablaFacturasDevolucion.Rows.Clear();
            actualizarTablaFacturasDevolucion();
            Motivo = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatosPago();

                devolucion.motivoDevolucion = Motivo;
                devolucion.fechaDevolucion = DateTime.Now;
                devolucion.detalleFacturas = tablaFacturasDevolucion;
                devolucion.registrarDevolucion();

                MessageBox.Show("La devolucion ha sido procesada exitosamente","Devolucion", MessageBoxButtons.OK,
                             MessageBoxIcon.Information);

                limpiarDevoluciones();
                limpiarPagos();
            }catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException || 
                    exception is CampoVacioException
                    ) Error.show(exception.Message);
                else throw;
            } 
        }
        

        private void validarDatosPago()
        {
            if (string.IsNullOrWhiteSpace(Motivo)) throw new CampoVacioException("Motivo de Devolucion");
            if (tablaFacturasDevolucion.Rows.Count == 0) throw new CampoVacioException("Tabla Facturas");
        }
    }
}
