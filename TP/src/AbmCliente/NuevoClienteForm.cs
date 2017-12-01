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
using System.Text.RegularExpressions;
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
            if (string.IsNullOrWhiteSpace(textBoxDomicilio.Text)) throw new CampoVacioException("Calle");
            if (string.IsNullOrWhiteSpace(textBoxNumero.Text)) throw new CampoVacioException("Numero");
            if (string.IsNullOrWhiteSpace(textBoxPiso.Text)) throw new CampoVacioException("Piso");
            if (string.IsNullOrWhiteSpace(textBoxDpto.Text)) throw new CampoVacioException("Dpto");
            if (string.IsNullOrWhiteSpace(textBoxLocalidad.Text)) throw new CampoVacioException("Localidad");
            if (string.IsNullOrWhiteSpace(textBoxTelefono.Text)) throw new CampoVacioException("Telefono");
            if (dateTimePickerFechaNacimiento == null) throw new CampoVacioException("Fecha de Nacimiento");
            if (string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text)) throw new CampoVacioException("Codigo Postal");

            if (Cliente.esClienteExistenteMail(textBoxEmail.Text)) throw new EmailExistenteException(textBoxEmail.Text);
            if (!esFormatoEmail()) throw new EmailFormatException(textBoxEmail.Text);

            if (decimal.Parse(textBoxDni.Text) <= 0) throw new ValorNegativoException("DNI");
            if (decimal.Parse(textBoxTelefono.Text)<= 0) throw new ValorNegativoException("Telefono");
            if (decimal.Parse(textBoxCodigoPostal.Text) <= 0) throw new ValorNegativoException("Codigo_Postal");
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validar(); // valido los datos ingresados

                Cliente.nuevo(  Convert.ToString(textBoxNombre.Text), 
                                Convert.ToString(textBoxApellido.Text), 
                                Convert.ToDecimal(textBoxDni.Text),
                                Convert.ToString(textBoxEmail.Text),
                                Convert.ToDecimal(textBoxTelefono.Text), 
                                Convert.ToString(textBoxDomicilio.Text),
                                Convert.ToDecimal(textBoxNumero.Text),
                                Convert.ToDecimal(textBoxPiso.Text), 
                                Convert.ToString(textBoxDpto.Text),
                                Convert.ToString(textBoxLocalidad.Text),
                                dateTimePickerFechaNacimiento.Value, 
                                Convert.ToDecimal(textBoxCodigoPostal.Text), 
                                true);
                // persisto el nuevo cliente
                this.Close();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException ||
                    exception is CampoVacioException ||
                    exception is ValorNegativoException ||
                    exception is EmailExistenteException ||
                    exception is EmailFormatException) Error.show(exception.Message);
                else throw;
            }
        }

        private Boolean esFormatoEmail()
        {
            if (!Regex.IsMatch(textBoxEmail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
                return false;
            return true;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

