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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class TablaEmpresaForm : ReturnForm
    {
        public TablaEmpresaForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }


        public TablaEmpresaForm()
        {
            InitializeComponent();
        }

        public override void Refrescar()
        {
            base.Refrescar();
            DataGridViewUsuario.Columns["Usuario_Habilitado"].Visible = false;  // oculto columna que no quiero mostrar
            DataGridViewUsuario.Columns["Chofer_Habilitado"].HeaderText = "Habilitado"; //  cambio nombre visible de columna
        }
        public DataGridView DataGridViewUsuario
        {
            get { return dataGridView1; }
        }
        public string Nombre
        {
            get
            {
                return nombre.Text;
            }
        }
        public string Direccion
        {
            get
            {
                return direccion.Text;
            }
        }
        protected virtual void CargarTabla()
        {
            dataGridView1.DataSource = Empresa.getXsConFiltros("Empresas", // obtengo las empresas y las cargo en la tabla
                                                                        Nombre,
                                                                        Direccion);
        }
        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void codigoPostal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
