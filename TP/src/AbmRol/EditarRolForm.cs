using PagoAgilFrba.Modelo;
using PagoAgilFrba.Modelo.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class EditarRolForm : ReturnForm
    {
        private Boolean edicion = false;
        private Rol rolEditar = null;
        private DataTable accesos;

        public EditarRolForm(ReturnForm caller) : base(caller)
        {
            rolEditar = new Rol();
            InitializeComponent();
            accesos = Acceso.getTablaDe(0);
            dataGridViewRol.DataSource = accesos;
            dataGridViewRol.Columns["Id_Acceso"].Visible = false;
            dataGridViewRol.Columns["Nombre"].ReadOnly = true;
        }

        public EditarRolForm(ReturnForm caller, Rol rolEditar)
            : base(caller)
        {
            edicion = true;
            this.rolEditar = rolEditar;
            InitializeComponent();
            accesos = Acceso.getTablaDe(rolEditar.id);
            dataGridViewRol.DataSource = accesos;
            dataGridViewRol.Columns["Id_Acceso"].Visible = false;
            dataGridViewRol.ReadOnly = true;
            dataGridViewRol.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Nombre = rolEditar.nombre;
            Habilitado = rolEditar.habilitado;
        }

        internal String Nombre
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

        public Boolean Habilitado
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
                validar();
                rolEditar.nombre = Nombre;
                rolEditar.habilitado = Habilitado;

                if (edicion)
                {
                    rolEditar.editar(accesos);
                }
                else
                {
                    rolEditar.nuevo(accesos);
                }
                this.Close();
            }
            catch(CampoVacioException exception)
            {
                Error.show(exception.Message);
            }
        }

        private void validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre)) throw new CampoVacioException("Nombre");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
