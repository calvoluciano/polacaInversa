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

namespace PagoAgilFrba.AbmCliente
{
    public partial class NuevoClienteForm : ReturnForm
    {
        public NuevoClienteForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }
  
        private void validar()      // valido los datos ingresados
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text)) throw new CampoVacioException("Nombre");
            if (string.IsNullOrWhiteSpace(textBoxApellido.Text)) throw new CampoVacioException("Apellido");
            if (string.IsNullOrWhiteSpace(textBoxDni.Text)) throw new CampoVacioException("DNI");
            if (string.IsNullOrWhiteSpace(textBoxDomicilio.Text)) throw new CampoVacioException("Domicilio");
            if (string.IsNullOrWhiteSpace(textBoxTelefono.Text)) throw new CampoVacioException("Telefono");
            if (dateTimePickerFechaNacimiento == null) throw new CampoVacioException("Fecha de Nacimiento");
            if (string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text)) throw new CampoVacioException("Codigo Postal");

            if (decimal.Parse(textBoxDni.Text) <= 0) throw new ValorNegativoException("DNI");
            if (decimal.Parse(textBoxTelefono.Text)<= 0) throw new ValorNegativoException("Telefono");
            if (decimal.Parse(textBoxCodigoPostal.Text) <= 0) throw new ValorNegativoException("Codigo_Postal");
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validar(); // valido los datos ingresados

                Cliente.nuevo(textBoxNombre.Text, Convert.ToString(textBoxApellido.Text), Convert.ToDecimal(textBoxDni.Text)
                    , Convert.ToString(textBoxEmail.Text),decimal.Parse(textBoxTelefono.Text), textBoxDomicilio.Text, dateTimePickerFechaNacimiento.Value, 
                    decimal.Parse(textBoxCodigoPostal.Text), true);
                // persisto el nuevo cliente
                this.Close();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException ||
                    exception is CampoVacioException ||
                    exception is ValorNegativoException) Error.show(exception.Message);
                else throw;
            }
        }

    }
}

