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

            //CUITCliente = facturaAEditar.cuitEmpresa.ToString();      // cargo los campos con los datos de la sucursal
            DNICliente = facturaAEditar.dniCliente.ToString();
            FechaAlta = facturaAEditar.fechaAlta;
            FechaVencimiento = facturaAEditar.fechaVencimiento;
        }

        public string CUITCliente
        {
            get
            {
                return textBoxCUITCliente.Text;
            }

            set
            {
                textBoxCUITCliente.Text = value;
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

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validar();                              //valido los datos ingresados
                //facturaAEditar.cuit = Int32.Parse(CUITCliente);          //edito la sucursal
                facturaAEditar.dniCliente = Int32.Parse(DNICliente);
                facturaAEditar.fechaAlta = Convert.ToDateTime(FechaAlta);
                facturaAEditar.fechaVencimiento = Convert.ToDateTime(FechaVencimiento);

                facturaAEditar.editar();                 //persisto los cambios

                this.Close();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException ||
                    exception is EmptyFieldException) Error.show(exception.Message);
                else throw;
            }
        }

        private void validar()  // valido los datos ingresados
        {
            if (string.IsNullOrWhiteSpace(CUITCliente)) throw new EmptyFieldException("Nombre");
            if (string.IsNullOrWhiteSpace(DNICliente)) throw new EmptyFieldException("Domicilio");
            //if (dateTimePickerFechaVencimiento.) throw new EmptyFieldException("Codigo Postal");
            //if (string.IsNullOrWhiteSpace(FechaVencimiento)) throw new EmptyFieldException("Codigo Postal");
            if (FechaAlta > FechaVencimiento) throw new ExpireDateBeforeException("Corrija las fechas");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerFechaAlta_ValueChanged(object sender, EventArgs e)
        {
        
        }
    }
}
