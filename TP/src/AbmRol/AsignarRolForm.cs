using PagoAgilFrba.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class AsignarRolForm : ReturnForm
    {
        public Rol rolAAsignar;

        public AsignarRolForm(ReturnForm caller, Rol rolAAsignar) : base(caller)
        {
            InitializeComponent();
            dataGridViewUsuarios.ReadOnly = false;
            this.rolAAsignar = rolAAsignar;
            dataGridViewUsuarios.CellValueChanged += new DataGridViewCellEventHandler(this.cellValueChanged);
        }

        public AsignarRolForm()
        {
            InitializeComponent();
        }

        protected void CargarTabla()
        {
            dataGridViewUsuarios.DataSource = Usuario.getTablaRolX( Nombre,
                                                                    Apellido,
                                                                    DNI,
                                                                    rolAAsignar.id);
        }

        public string Nombre
        {
            get
            {
                return textBoxNombre.Text;
            }
        }

        public string Apellido
        {
            get
            {
                return textBoxApellido.Text;
            }
        }

        public Decimal DNI
        {
            get
            {
                return Decimal.Parse(textBoxDni.Text);
            }
        }

        protected void cellValueChanged(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)dataGridViewUsuarios.SelectedRows[0].DataBoundItem).Row;    // obtengo la fila seleccionada
            Usuario.rolUpdate((int)fila["usua_id"], rolAAsignar.id, (Boolean)fila["Habilitado"]); // cambio estado del rol para el usuario seleccionado
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";                                                            // borro los campos de filtros
            textBoxApellido.Text = "";
            textBoxDni.Text = "";
            CargarTabla();  
        }
    }
}
