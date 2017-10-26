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

namespace PagoAgilFrba.AbmFactura
{
    public partial class NuevaFacturaForm : ReturnForm
    {
        public NuevaFacturaForm()
        {
            InitializeComponent();
        }
        public NuevaFacturaForm(ReturnForm caller) : base(caller)            
        {           
            InitializeComponent();
        }
        private Usuario usuarioSeleccionado = null;



        private Sucursal sucursalAEditar = null;

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
    }
}
