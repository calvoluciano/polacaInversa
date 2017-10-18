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
    public partial class NuevaSucursalForm : ReturnForm
    {
        public NuevaSucursalForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }
        private Usuario usuarioSeleccionado = null;

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

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
           /* try
            {
                if (usuarioSeleccionado == null) throw new UsuarioNoSeleccionadoException();    // valido los datos ingresados
                else Sucursal.nuevo(usuarioSeleccionado.id, checkBoxHabilitado.Checked);          // persisto el nuevo chofer

                this.Close();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException || exception is UsuarioNoSeleccionadoException) Error.show(exception.Message);
                else throw;
            } */
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSeleccionarUsuario_Click(object sender, EventArgs e)
        {
            /*Usuario seleccionado = new SeleccionarUsuarioForm(this).getNoSucursal();  // Selecciono una sucursal
            if(seleccionado != null)                                                // Si es null(porque cancelaron) no hago nada
            {
                usuarioSeleccionado = seleccionado;                                 // en caso contrario lleno los campos
                Nombre = seleccionado.nombre;
                Direccion = seleccionado.direccion;           
            }*/
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


