using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Modelo;
using System.Data.SqlClient;
using PagoAgilFrba.Modelo.Exceptions;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class NuevaSucursalForm : ReturnForm
    {
        public NuevaSucursalForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }

        public string Nombre
        {
            set
            {
                textBoxNombre.Text = value;
            }
        }

        public string CodigoPostal
        {
            set
            {
                textBoxCodigoPostal.Text = value;
            }
        }


        public string Direccion
        {
            set
            {
                textBoxDireccion.Text = value;
            }
        }

      
        public bool Habilitado
        {
            set
            {
                checkBoxHabilitado.Checked = value;
            }
        }

        public void validar()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text)) throw new CampoVacioException("Nombre");
            if (string.IsNullOrWhiteSpace(textBoxDireccion.Text)) throw new CampoVacioException("Direccion");
            if (string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text)) throw new CampoVacioException("Codigo Postal");
            if (decimal.Parse(textBoxCodigoPostal.Text) <= 0) throw new ValorNegativoException("Codigo Postal");
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
           try
            {
                validar();    // valido los datos ingresados

                Sucursal.nuevo( Convert.ToString(textBoxNombre.Text),
                                Convert.ToString(textBoxDireccion.Text),
                                Convert.ToDecimal(textBoxCodigoPostal.Text),
                                Convert.ToBoolean(checkBoxHabilitado.Checked));          // persisto el nuevo chofer

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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}


