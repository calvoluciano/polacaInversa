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
using PagoAgilFrba.Modelo;
using PagoAgilFrba.Modelo.Exceptions;
using PagoAgilFrba.AbmEmpresa;


namespace PagoAgilFrba.AbmFactura
{
    
    public partial class EditarFacturaForm : ReturnForm
    {
        private Factura facturaAEditar = null;
        public EditarFacturaForm()
        {
            InitializeComponent();
        }

        public EditarFacturaForm(ReturnForm caller, Factura facturaAEditar)
            : base(caller)
        {
            this.facturaAEditar = facturaAEditar;

            InitializeComponent();
            
            DNICliente = facturaAEditar.dniCliente.ToString();
            idFactura = facturaAEditar.idFactura;
            Empresa = new Empresa(Empresa.getXsConFiltros("",facturaAEditar.cuitEmpresa,"").Rows[0]);
            FechaAlta = facturaAEditar.fechaAlta;
            FechaVencimiento = facturaAEditar.fechaVencimiento;
        }

        private Empresa empresa = null;

        public decimal idFactura
        {
            set
            {
                textBoxNumeroFactura.Text = value.ToString();
                textBoxNumeroFactura.ReadOnly = true;
            }
        }

        public string DNICliente
        {
            get
            {
                return textBoxDNICliente.Text;
            }

            set
            {
                textBoxDNICliente.Text = value;
            }
        }

     
        public DateTime FechaAlta
        {
            get
            {
                return dateTimePickerFechaAlta.Value;
            }

            set
            {
                dateTimePickerFechaAlta.Value = value;
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

        public Empresa Empresa
        {
            get
            {
                return empresa;
            }
            set
            {
                empresa = value;
                textBoxNombreEmpresa.Text = empresa.nombre;
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validar();                              
                facturaAEditar.idEmpresa = Empresa.id;          
                facturaAEditar.dniCliente = Int32.Parse(DNICliente);
                facturaAEditar.fechaAlta = Convert.ToDateTime(FechaAlta);
                facturaAEditar.fechaVencimiento = Convert.ToDateTime(FechaVencimiento);

                facturaAEditar.editar();                 //persisto los cambios
                new NuevaFacturaDetalle(this, facturaAEditar, true).abrir();

                this.Close();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException ||
                    exception is EmptyFieldException ||
                    exception is CampoVacioException ||
                    exception is ExpireDateBeforeException ||
                    exception is EmpresaNoSeleccionadaException) Error.show(exception.Message);
                else throw;
            }
        }

        private void validar()  // valido los datos ingresados
        {

            if (string.IsNullOrWhiteSpace(textBoxDNICliente.Text)) throw new CampoVacioException("DNI Cliente");
            if (Empresa == null) throw new EmpresaNoSeleccionadaException();    // valido los datos ingresados     
            if (dateTimePickerFechaAlta == null) throw new CampoVacioException("Fecha de Alta");
            if (dateTimePickerFechaVencimiento == null) throw new CampoVacioException("Fecha de Vencimiento");
            if (FechaAlta > FechaVencimiento) throw new ExpireDateBeforeException("Corrija las fechas");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSeleccionarEmpresa_Click(object sender, EventArgs e)
        {
            Empresa seleccionado = new SeleccionarEmpresaForm(this).getEmpresa();   // selecciono cliente
            if (seleccionado != null) Empresa = seleccionado;    
        }

        private void EditarFacturaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
