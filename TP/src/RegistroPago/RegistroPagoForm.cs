using PagoAgilFrba.AbmCliente;
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

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPagoForm : PagoAgilFrba.Modelo.ReturnForm
    {
        DataTable tablaFacturas = new DataTable();
        private Cliente cliente = null;
        private Empresa empresaSeleccionada = null;
        Pago pago = new Pago();

        public RegistroPagoForm(ReturnForm caller)
            : base(caller)
        {
            
            InitializeComponent();
            FechaCobro = Program.FechaEjecucion;
            FechaVencimiento = Program.FechaEjecucion;

            cargarEmpresas();
            cargarMediosDePago();
            labelSucursal.Text += Usuario.sucursalSeleccionada.nombre;

            tablaFacturas.Columns.Add("Numero Factura", typeof(decimal));
            tablaFacturas.Columns.Add("Empresa", typeof(string));
            tablaFacturas.Columns.Add("Fecha de Vencimiento", typeof(DateTime));
            tablaFacturas.Columns.Add("Importe", typeof(float));

            tablaFacturas.PrimaryKey = new DataColumn[] {tablaFacturas.Columns["Numero Factura"]};

            actualizarTablaFacturas();

        }

        public void actualizarTablaFacturas()
        {
            dataGridView1.DataSource = tablaFacturas;
        }

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;

                if (cliente != null)
                    textBoxNombreCliente.Text = cliente.nombre + ", " + cliente.apellido;
                else
                    textBoxNombreCliente.Text = "";
            }
        }

        public Decimal NumeroFactura
        {
            get
            {
                return Convert.ToDecimal(textBoxNumeroFactura.Text);
            }
            set
            {
                textBoxNumeroFactura.Text = value.ToString();
            }
        }

        public DateTime FechaVencimiento
        {
            get
            {
                return dateTimePickerFechaVencimiento.Value;
            }

            set
            {
                dateTimePickerFechaVencimiento.Value = value;
            }
        }

        public DateTime FechaCobro
        {
            get
            {
                return dateTimePickerFechaCobro.Value;
            }

            set
            {
                dateTimePickerFechaCobro.Value = value;
            }
        }

        public Double Importe
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxImporte.Text)) return 0;

                return Convert.ToDouble(textBoxImporte.Text);
            }

            set
            {
                textBoxImporte.Text = value.ToString();
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

        void cargarEmpresas()
        {
            Empresa.getEmpresas().ForEach(r => comboBoxEmpresa.Items.Add(r));    // obtengo y agrego los nuevos

            comboBoxEmpresa.DisplayMember = "nombre";
        }

        void cargarMediosDePago()
        {
            MedioDePago.getMedioPagos().ForEach(r => comboBoxMedioPago.Items.Add(r));    // obtengo y agrego los nuevos

            comboBoxMedioPago.DisplayMember = "descripcion";
        }

        private void buttonSeleccionarCliente_Click(object sender, EventArgs e)
        {
            Cliente seleccionado = new SeleccionarClienteForm(this).getCliente();   // selecciono cliente
            if (seleccionado != null) Cliente = seleccionado;  
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

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatosFactura();
                registrarNuevaFactura();
                actualizarTablaFacturas();
                actualizarImporteTotal();
                limpiarDatosFactura();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException || 
                    exception is CampoVacioException ||
                    exception is ValorNegativoException ||
                    exception is ExpireDateBeforeException ||
                    exception is FacturaYaAgregadaException ||
                    exception is FacturaInexistenteException ||
                    exception is FacturaInhabilitadaException ||
                    exception is FacturaYaCobradaException ||
                    exception is ClienteFacturaException ||
                    exception is EmpresaFacturaException ||
                    exception is FacturaFechaVencimientoException ||
                    exception is ImporteFacturaException) Error.show(exception.Message);
                else throw;
            } 
        }

        private void validarDatosFactura()
        {
            if (string.IsNullOrWhiteSpace(textBoxNumeroFactura.Text)) throw new CampoVacioException("Numero Factura");
            if (string.IsNullOrWhiteSpace(textBoxImporte.Text)) throw new CampoVacioException("Importe");

            if (string.IsNullOrWhiteSpace(comboBoxEmpresa.Text)) throw new CampoVacioException("Empresa");
            if (dateTimePickerFechaVencimiento == null) throw new CampoVacioException("Fecha de Vencimiento");
            if (Importe <= 0) throw new ValorNegativoException("Importe");

            if (esFacturaYaAgregada(NumeroFactura)) throw new FacturaYaAgregadaException(NumeroFactura.ToString());
            if (!Factura.esFacturaExistente(NumeroFactura)) throw new FacturaInexistenteException(NumeroFactura.ToString());
            if (!Factura.esFacturaHabilitada(NumeroFactura)) throw new FacturaInhabilitadaException(NumeroFactura.ToString());
            if (Factura.estaCobrada(NumeroFactura)) throw new FacturaYaCobradaException(NumeroFactura.ToString());
            if (!Factura.esFacturaDeLaEmpresa(NumeroFactura, empresaSeleccionada.id)) throw new EmpresaFacturaException(NumeroFactura.ToString(), empresaSeleccionada.nombre);
            if (!Factura.verificaFechaVencimiento(NumeroFactura, FechaVencimiento)) throw new FacturaFechaVencimientoException(NumeroFactura.ToString(), FechaVencimiento.ToString());
            if (!Factura.esImporteCorrecto(NumeroFactura, Importe)) throw new ImporteFacturaException(NumeroFactura.ToString());

            ComparadorFechas comparar = new ComparadorFechas();
            if (comparar.esMenor(FechaVencimiento,FechaCobro)) throw new ExpireDateBeforeException("Factura vencida controle las fechas");
        }

        private void validarDatosPago()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombreCliente.Text)) throw new CampoVacioException("Cliente");
            if (tablaFacturas.Rows.Count==0) throw new EmptyFieldException("Tabla Facturas");
            if (comboBoxMedioPago.SelectedItem == null) throw new CampoVacioException("Medio de Pago");
        }

        public void registrarNuevaFactura()
        {
            DataRow fila = tablaFacturas.NewRow();
            fila["Numero Factura"] = NumeroFactura;
            fila["Empresa"] = empresaSeleccionada.nombre;
            fila["Fecha de Vencimiento"] = FechaVencimiento;
            fila["Importe"] = Importe;

            tablaFacturas.Rows.Add(fila);
        }

        public void actualizarImporteTotal()
        {
            pago.aumentarImporteTotal(Importe);
            Total = pago.total;
        }

        public void limpiarDatosFactura()
        {
            textBoxNumeroFactura.Text = "";
            comboBoxEmpresa.SelectedIndex = -1;
            dateTimePickerFechaVencimiento.Value = Program.FechaEjecucion;
            textBoxImporte.Text = "";
        }

        public Boolean esFacturaYaAgregada(Decimal idFactura)
        {
            DataRow foundRow = tablaFacturas.Rows.Find(idFactura);
            
            if (foundRow != null)
                return true;

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataRow selectedRow = ((DataRowView)dataGridView1.SelectedRows[0].DataBoundItem).Row;
                tablaFacturas.Rows.Remove(selectedRow);
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatosPago();

                pago.idCliente = cliente.id;
                pago.total = Total;
                pago.fechaCobro = FechaCobro;
                pago.idSucursal = Usuario.sucursalSeleccionada.id;
                MedioDePago item = (MedioDePago)comboBoxMedioPago.SelectedItem;
                pago.idMedioPago = item.id;
                pago.detallePago = tablaFacturas;
                pago.registrarPago();

                MessageBox.Show("El pago ha sido procesado exitosamente", "Pago", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                reiniciarPago();

            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is EmptyFieldException ||
                    exception is CampoVacioException) Error.show(exception.Message);
                else throw;
            } 
        }

        public void reiniciarPago()
        {
            tablaFacturas.Rows.Clear();
            actualizarTablaFacturas();
            actualizarImporteTotal();
            empresaSeleccionada = null;
            Cliente = null;
            comboBoxEmpresa.SelectedItem = null;
            comboBoxMedioPago.SelectedItem = null;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxNumeroFactura.Text))
            {
                DataTable dt = Factura.getXsConFiltros(NumeroFactura, 0, 0, 0);
                if (dt.Rows.Count == 1)
                {
                    Factura facturaSeleccionada = new Factura(dt.Rows[0]);
                    cargarDatosFactura(facturaSeleccionada);
                }
                else
                {
                    MessageBox.Show("No existe factura con ese numero", "ERROR", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
        }

        private void cargarDatosFactura(Factura factura)
        {
            empresaSeleccionada = new Empresa(Empresa.getXsConFiltros("", factura.cuitEmpresa, "").Rows[0]);
            comboBoxEmpresa.Text = empresaSeleccionada.nombre;
            if (!empresaSeleccionada.habilitado)
            {
                Error.show("No se puede seleccionar una empresa inhabilitada.");
                comboBoxEmpresa.SelectedItem = null;
            }
            FechaVencimiento = factura.fechaVencimiento;
            Importe = Convert.ToDouble(factura.total);
        }

    }
}
