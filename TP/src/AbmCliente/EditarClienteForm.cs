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
    public partial class EditarClienteForm : ReturnForm
    {
        private Cliente clienteAEditar = null;

        public EditarClienteForm(ReturnForm caller, Cliente clienteAEditar)
            : base(caller)
        {
            this.clienteAEditar = clienteAEditar;
            InitializeComponent();

            Nombre = clienteAEditar.nombre;             // cargo los campos con los datos del cliente
            Apellido = clienteAEditar.apellido;
            DNI = clienteAEditar.dni;
            Domicilio = clienteAEditar.domicilio;
            Numero = clienteAEditar.numero;
            Piso = clienteAEditar.piso;
            Dpto = clienteAEditar.dpto;
            Localidad = clienteAEditar.localidad;
            Telefono = clienteAEditar.telefono;
            Mail = clienteAEditar.mail;
            FechaNac = clienteAEditar.fechaNac;
            CodigoPostal = clienteAEditar.codigoPostal;
            Habilitado = clienteAEditar.habilitado;
        }

        public string Nombre
        {
            get
            {
                return textBoxNombre.Text;
            }

            set
            {
                textBoxNombre.Text = value;
            }
        }

        public string Apellido
        {
            get
            {
                return textBoxApellido.Text;
            }

            set
            {
                textBoxApellido.Text = value;
            }
        }

        public decimal DNI
        {
            get
            {
                return decimal.Parse(textBoxDni.Text);
            }

            set
            {
                textBoxDni.Text = value.ToString();
            }
        }

        public string Domicilio
        {
            get
            {
                return textBoxDomicilio.Text;
            }

            set
            {
                textBoxDomicilio.Text = value;
            }
        }

        public Decimal Numero
        {
            get
            {
                return decimal.Parse(textBoxNumero.Text);
            }

            set
            {
                textBoxNumero.Text = value.ToString();
            }
        }

        public Decimal Piso
        {
            get
            {
                return decimal.Parse(textBoxPiso.Text);
            }

            set
            {
                textBoxPiso.Text = value.ToString();
            }
        }

        public string Dpto
        {
            get
            {
                return textBoxDpto.Text;
            }

            set
            {
                textBoxDpto.Text = value;
            }
        }

        public string Localidad
        {
            get
            {
                return textBoxLocalidad.Text;
            }

            set
            {
                textBoxLocalidad.Text = value;
            }
        }

        public decimal Telefono
        {
            get
            {
                return decimal.Parse(textBoxTelefono.Text);
            }

            set
            {
                textBoxTelefono.Text = value.ToString();
            }
        }

        public string Mail
        {
            get
            {
                return textBoxEmail.Text;
            }

            set
            {
                textBoxEmail.Text = value;
            }
        }

        public DateTime FechaNac
        {
            get
            {
                return dateTimePickerFechaNacimiento.Value;
            }

            set
            {
                dateTimePickerFechaNacimiento.Value = value;
            }
        }

        public decimal CodigoPostal
        {
            get
            {
                return decimal.Parse(textBoxCodigoPostal.Text);
            }
            set
            {
                textBoxCodigoPostal.Text = value.ToString();
            }
        }

        public bool Habilitado
        {
            get
            {
                return checkBoxHabilitado.Checked;
            }

            set
            {
                checkBoxHabilitado.Checked = value;
            }
        }

        private void aceptar_Click_1(object sender, EventArgs e)
        {
            try
            {
                validar();                                      //valido los datos ingresados
                clienteAEditar.nombre = Nombre;                 //edito el chofer
                clienteAEditar.apellido = Apellido;
                clienteAEditar.dni = DNI;
                clienteAEditar.domicilio = Domicilio;
                clienteAEditar.numero = Numero;
                clienteAEditar.piso = Piso;
                clienteAEditar.dpto = Dpto;
                clienteAEditar.localidad = Localidad;
                clienteAEditar.telefono = Telefono;
                clienteAEditar.mail = Mail;
                clienteAEditar.fechaNac = FechaNac;
                clienteAEditar.codigoPostal = CodigoPostal;
                clienteAEditar.habilitado = Habilitado;

                clienteAEditar.editar();                        //persisto los cambios

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

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validar()      // valido los datos ingresados
        {
            if (string.IsNullOrWhiteSpace(Nombre)) throw new CampoVacioException("Nombre");
            if (string.IsNullOrWhiteSpace(Apellido)) throw new CampoVacioException("Apellido");
            if (string.IsNullOrWhiteSpace(textBoxDni.Text)) throw new CampoVacioException("DNI");
            if (string.IsNullOrWhiteSpace(Domicilio)) throw new CampoVacioException("Domicilio");
            if (string.IsNullOrWhiteSpace(textBoxNumero.Text)) throw new CampoVacioException("Numero");
            if (string.IsNullOrWhiteSpace(textBoxPiso.Text)) throw new CampoVacioException("Piso");
            if (string.IsNullOrWhiteSpace(textBoxDpto.Text)) throw new CampoVacioException("Dpto");
            if (string.IsNullOrWhiteSpace(textBoxLocalidad.Text)) throw new CampoVacioException("Localidad");
            if (string.IsNullOrWhiteSpace(textBoxTelefono.Text)) throw new CampoVacioException("Telefono");
            if (FechaNac == null) throw new CampoVacioException("Fecha_Nac");
            if (string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text)) throw new CampoVacioException("Codigo_Postal");

            if (Cliente.esClienteExistenteMail(textBoxEmail.Text)) throw new EmailExistenteException(textBoxEmail.Text);
            if (!esFormatoEmail()) throw new EmailFormatException(textBoxEmail.Text);

            if (DNI <= 0) throw new ValorNegativoException("DNI");
            if (Telefono <= 0) throw new ValorNegativoException("Telefono");
            if (CodigoPostal <= 0) throw new ValorNegativoException("Codigo_Postal");
        }

        private Boolean esFormatoEmail()
        {
            if (!Regex.IsMatch(textBoxEmail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
                return false;
            return true;
        }

    }
}
