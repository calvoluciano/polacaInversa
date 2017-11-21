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
                textBoxNombreCliente.Text = cliente.nombre + ", " + cliente.apellido;
            }
        }

        public Int32 NumeroFactura
        {
            get
            {
                return Convert.ToInt32(textBoxNumeroFactura.Text);
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
                    exception is FacturaFechaVencimientoException) Error.show(exception.Message);
                else throw;
            } 
        }

        private void validarDatosFactura()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombreCliente.Text)) throw new CampoVacioException("Cliente");
            if (string.IsNullOrWhiteSpace(textBoxNumeroFactura.Text)) throw new CampoVacioException("Numero Factura");
            if (string.IsNullOrWhiteSpace(textBoxImporte.Text)) throw new CampoVacioException("Importe");
            if (comboBoxEmpresa.SelectedItem == null) throw new CampoVacioException("Empresa");
            if (dateTimePickerFechaVencimiento == null) throw new CampoVacioException("Fecha de Vencimiento");
            if (Importe <= 0) throw new ValorNegativoException("Importe");

            if (esFacturaYaAgregada(NumeroFactura)) throw new FacturaYaAgregadaException(NumeroFactura.ToString());
            if (!Factura.esFacturaExistente(NumeroFactura)) throw new FacturaInexistenteException(NumeroFactura.ToString());
            if (!Factura.esFacturaHabilitada(NumeroFactura)) throw new FacturaInhabilitadaException(NumeroFactura.ToString());
            if (Factura.estaCobrada(NumeroFactura)) throw new FacturaYaCobradaException(NumeroFactura.ToString());
            if (!Factura.esFacturaDelCliente(NumeroFactura, Cliente.id)) throw new ClienteFacturaException(NumeroFactura.ToString(), Cliente.nombre);
            if (!Factura.esFacturaDeLaEmpresa(NumeroFactura, empresaSeleccionada.id)) throw new EmpresaFacturaException(NumeroFactura.ToString(), empresaSeleccionada.nombre);
            if (!Factura.verificaFechaVencimiento(NumeroFactura, FechaVencimiento)) throw new FacturaFechaVencimientoException(NumeroFactura.ToString(), empresaSeleccionada.nombre);

            ComparadorFechas comparar = new ComparadorFechas();
            if (comparar.esMenor(FechaVencimiento,FechaCobro)) throw new ExpireDateBeforeException("Factura vencida controle las fechas");
        }

        public void registrarNuevaFactura()
        {
            DataRow fila = tablaFacturas.NewRow();
            fila["Numero Factura"] = NumeroFactura;
            fila["Empresa"] = empresaSeleccionada.nombre;
            fila["Fecha de Vencimiento"] = FechaVencimiento;
            fila["Importe"] = Importe;

            tablaFacturas.Rows.Add(fila);
                
            Factura factura = new Factura();
            factura.idFactura = Convert.ToDecimal(textBoxNumeroFactura.Text);
            factura.idEmpresa = ((Empresa)(comboBoxEmpresa.SelectedItem)).id;
            factura.fechaVencimiento = dateTimePickerFechaVencimiento.Value;
            pago.agregarFacturaAPagar(factura);

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
            dateTimePickerFechaVencimiento.Value = DateTime.Today;
            textBoxImporte.Text = "";
        }

        public Boolean esFacturaYaAgregada(int idFactura)
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

    }
}
