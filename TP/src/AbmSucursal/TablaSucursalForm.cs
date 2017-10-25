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
    public partial class TablaSucursalForm : ReturnForm
    {
        public TablaSucursalForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }
        public TablaSucursalForm()
        {
            InitializeComponent();
        }
        public override void Refrescar()
        {
            base.Refrescar();
            DataGridViewUsuario.Columns["Usuario_Habilitado"].Visible = false;  // oculto columna que no quiero mostrar
            DataGridViewUsuario.Columns["Sucursal_Habilitada"].HeaderText = "Habilitada"; //  cambio nombre visible de columna
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
        public string Codigo_Postal
        {
            get
            {
                return codigoPostal.Text;
;
            }
        }
        protected virtual void CargarTabla()
        {
            dataGridView1.DataSource = Sucursal.getXsConFiltros("Sucursales", // obtengo las sucursales y las cargo en la tabla
                                                                        Nombre,
                                                                        Direccion,
                                                                        Codigo_Postal);
        }
        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void codigoPostal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
