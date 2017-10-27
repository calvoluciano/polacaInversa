using PagoAgilFrba.AbmCliente;
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

namespace PagoAgilFrba.AbmRol
{
    public partial class ABMRolForm : ReturnForm
    {
        public ABMRolForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }

        public ABMRolForm()
        {
            InitializeComponent();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            new EditarRolForm(this).abrir();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)dataGridViewRoles.SelectedRows[0].DataBoundItem).Row;  //Obtengo la fila seleccionada
            new EditarRolForm(this, new Rol(fila)).abrir();  // creo rol a partir de la fila y se lo paso a la ventana de edicion
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            Rol.inhabilitar((byte)dataGridViewRoles.SelectedRows[0].Cells["rol_id"].Value);       // obtengo id del rol seleccionado y lo inhabilito
            CargarTabla();
        }

        public override void Refrescar()
        {
            CargarTabla();
            dataGridViewRoles.Columns["id_Rol"].Visible = false;                                  // oculto columna que no quiero mostrar
        }

        protected void CargarTabla()
        {
            dataGridViewRoles.DataSource = Rol.getRoles();
        }

        private void buttonAsignar_Click(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)dataGridViewRoles.SelectedRows[0].DataBoundItem).Row;        // obtengo fila seleccionada
            Rol rol = new Rol(fila);                                                                // creo rol a partir de la fila
            if (!rol.habilitado)
            {                                                                  // si esta deshabilitado...
                Error.show("No se puede asignar usuarios a un rol inhabilitado!");
                return;
            }
            new AsignarRolForm(this, rol).abrir();    
        }

    }
}
