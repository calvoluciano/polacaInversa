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
        public RegistroPagoForm(ReturnForm caller)
            : base(caller)
        {
            
            InitializeComponent();
            cargarEmpresas();
            labelSucursal.Text += Usuario.sucursalSeleccionada.nombre;
        }

        private Cliente cliente = null;
        private Empresa empresaSeleccionada = null;

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

        public Decimal Importe
        {
            get
            {
                return Convert.ToDecimal(textBoxImporte.Text);
            }

            set
            {
                textBoxImporte.Text = value.ToString();
            }
        }

        void cargarEmpresas()
        {
            Empresa.getEmpresas().ForEach(r => comboBoxEmpresa.Items.Add(r));    // obtengo y agrego los nuevos

            comboBoxEmpresa.DisplayMember = "nombre";
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

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                validarDatosFactura();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException || 
                    exception is CampoVacioException ||
                    exception is ValorNegativoException |
                    exception is ExpireDateBeforeException) Error.show(exception.Message);
                else throw;
            } 
        }

        private void validarDatosFactura()
        {

            if (string.IsNullOrWhiteSpace(textBoxNumeroFactura.Text)) throw new CampoVacioException("Numero Factura");
            if (string.IsNullOrWhiteSpace(textBoxImporte.Text)) throw new CampoVacioException("Importe");
            if (comboBoxEmpresa.SelectedItem == null) throw new CampoVacioException("Empresa");
            if (dateTimePickerFechaVencimiento == null) throw new CampoVacioException("Fecha de Vencimiento");
            if (Importe <= 0) throw new ValorNegativoException("Cuit");

            if (esFacturaYaAgregadaParaPagar(NumeroFactura)) throw new FacturaYaAgregadaException("Numero Factura");

            /*
            if (!FacturasRepositorio.esFacturaExistente(tx_numero_factura.Text))
            {
                MessageBox.Show("La factura no existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return error;
            }

            if (!FacturasRepositorio.esFacturaHabilitada(tx_numero_factura.Text))
            {
                MessageBox.Show("La factura no esta habilitada para pagar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return error;
            }
            */
            
            if (FechaVencimiento < FechaCobro) throw new ExpireDateBeforeException("Factura vencida controle las fechas");
        }

        public Boolean esFacturaYaAgregadaParaPagar(int idFactura)
        {
            return true;
        }
       
    }
}
