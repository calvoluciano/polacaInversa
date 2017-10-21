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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class EditarEmpresaForm : ReturnForm
    {
        public EditarEmpresaForm(ReturnForm caller, Empresa empresaAEditar) : base(caller)       
        {
            this.empresaAEditar = empresaAEditar;

            InitializeComponent();

            Nombre = empresaAEditar.nombre;      // cargo los campos con los datos de la sucursal
            Direccion = empresaAEditar.direccion;
            Habilitado = empresaAEditar.habilitado;
        }

          private Empresa empresaAEditar = null;

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
            try
            {
                validar();                              //valido los datos ingresados
                empresaAEditar.nombre = Nombre;          //edito la sucursal
                empresaAEditar.direccion = Direccion;
                empresaAEditar.habilitado = Habilitado;

                empresaAEditar.editar();                 //persisto los cambios

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
            if (string.IsNullOrWhiteSpace(Nombre)) throw new EmptyFieldException("Nombre");
            if (string.IsNullOrWhiteSpace(Direccion)) throw new EmptyFieldException("Domicilio");

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
