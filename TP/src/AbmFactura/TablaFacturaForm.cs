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
    public partial class TablaFacturaForm : ReturnForm
    {
        public TablaFacturaForm()
        {
            InitializeComponent();
        }
        public TablaFacturaForm(ReturnForm caller): base(caller)
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
        public String NumeroFactura
        {
            get
            {
                return numeroFactura.Text;
            }
        }
        public String CUIT
        {
            get
            {
                return cuit.Text;
            }
        }

        public String DNICliente
        {
            get
            {
                return dniCliente.Text;
            }
        }
        public String Total
        {
            get
            {
                return total.Text;
            }
        }
       
       
        /*protected virtual void CargarTabla()
        {
            dataGridView1.DataSource = Factura.getXsConFiltros("Facturas", // obtengo las sucursales y las cargo en la tabla
                                                                        NumeroFactura,
                                                                        CUIT,
                                                                        DNICliente,
                                                                        Total);*/
        }
}

