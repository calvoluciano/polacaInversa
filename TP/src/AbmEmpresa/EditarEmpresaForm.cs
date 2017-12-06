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
using PagoAgilFrba.Modelo.Exceptions;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class EditarEmpresaForm : ReturnForm
    {
        private Boolean edicion = false;
        private Empresa editarEmpresa = null;


         public EditarEmpresaForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
            this.Text = "Nueva Empresa";
            comboBoxRubro.Items.Add("");
            Empresa.getDetalle().ForEach(detalle => comboBoxRubro.Items.Add(detalle));
        }

         public EditarEmpresaForm(ReturnForm caller, Empresa empresaAEditar)
             : base(caller)
         {
             edicion = true;
             this.editarEmpresa = empresaAEditar;
             InitializeComponent();
             this.Text = "Editar Empresa";

             comboBoxRubro.Items.Add("");
             Empresa.getDetalle().ForEach(detalle => comboBoxRubro.Items.Add(detalle));

             Nombre = empresaAEditar.nombre;             // cargo los campos con los datos del cliente
             Cuit = empresaAEditar.cuit;
             Direccion = empresaAEditar.direccion;
             Rubro = empresaAEditar.rubro;
             Habilitado = empresaAEditar.habilitado;
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

        public string Direccion
        {
            get
            {
                return textBoxDireccion.Text;
            }
            set
            {
                textBoxDireccion.Text = value.ToString();
            }
        }

        public Decimal Cuit
        {
            get
            {
                return Convert.ToDecimal(textBoxCuit.Text);
            }
            set
            {
                textBoxCuit.Text = value.ToString();
            }
        }

        public string Rubro
        {
            get
            {
                return (String)comboBoxRubro.SelectedItem;
            }
            set
            {
                comboBoxRubro.SelectedItem = value;
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

        private void validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre)) throw new CampoVacioException("Nombre");
            if (Cuit < 0) throw new ValorNegativoException("Cuit");
            if (Cuit == 0) throw new CampoVacioException("Cuit");
            if (string.IsNullOrWhiteSpace(textBoxCuit.Text)) throw new CampoVacioException("Cuit");
            if (string.IsNullOrWhiteSpace(Direccion)) throw new CampoVacioException("Direccion");
            if (string.IsNullOrWhiteSpace(Rubro)) throw new CampoVacioException("Rubro");   
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validar();
                if (edicion)
                {
                    editarEmpresa.nombre = Nombre;
                    editarEmpresa.cuit = Cuit;
                    editarEmpresa.direccion = Direccion;
                    editarEmpresa.rubro = Rubro;
                    editarEmpresa.habilitado = Habilitado;

                    editarEmpresa.editar();
                }
                else
                {
                    Empresa.nuevo(Nombre, Cuit, Direccion, Rubro, Habilitado);
                }
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
