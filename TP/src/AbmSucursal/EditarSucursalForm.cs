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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class EditarSucursalForm : ReturnForm
    {
        public EditarSucursalForm(ReturnForm caller, Sucursal sucursalAEditar) : base(caller)            
        {
            this.sucursalAEditar = sucursalAEditar;

            InitializeComponent();

            Nombre = sucursalAEditar.nombre;      // cargo los campos con los datos del chofer
            Direccion = sucursalAEditar.direccion;
            Codigo_Postal = sucursalAEditar.codigoPostal;
            Habilitado = sucursalAEditar.habilitado;
        }



        private Sucursal sucursalAEditar = null;

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
        public string Codigo_Postal
        {
            get
            {
                return textBoxCodigoPostal.Text;
            }

            set
            {
                textBoxCodigoPostal.Text = value;
            }
        }

     
        public string Direccion
        {
            get
            {
                return textBoxDireccion.Text;
            }

            set
            {
                textBoxDireccion.Text = value;
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

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
           /* try
            {
                validar();                              //valido los datos ingresados
                sucursalAEditar.nombre = Nombre;          //edito el chofer
                sucursalAEditar.direccion = Direccion;
                sucursalAEditar.habilitado = Habilitado;

                sucursalAEditar.editar();                 //persisto los cambios

                this.Close();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException ||
                    exception is CampoVacioException ||
                    exception is ValorNegativoException) Error.show(exception.Message);
                else throw;
            }*/
        }

        private void validar()  // valido los datos ingresados
        {
           /* if (string.IsNullOrWhiteSpace(Nombre)) throw new CampoVacioException("Nombre");
            if (string.IsNullOrWhiteSpace(Direccion)) throw new CampoVacioException("Domicilio");*/
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
