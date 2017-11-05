using PagoAgilFrba.Modelo;
using PagoAgilFrba.Modelo.Exceptions;
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

namespace PagoAgilFrba.AbmFactura
{
    public partial class NuevaFacturaDetalle : ReturnForm
    {
        public NuevaFacturaDetalle()
        {
            InitializeComponent();
        }

        public NuevaFacturaDetalle(ReturnForm caller, Factura factura, Boolean edicion) : base(caller)
        {
            InitializeComponent();
            Factura = factura;

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("Monto", System.Type.GetType("System.Decimal")));

            if (edicion)
                dt= Factura.getDetalle();

            DataGridViewDetalleFactura.DataSource = dt;
        }

        private Factura factura;
        private DateTime fechaAlta;
        private DateTime fechaVencimiento;
        private decimal total;
        private DataTable dt;

        internal Factura Factura
        {
            get
            {
                return factura;
            }
            set
            {
                factura = value;
                labelDniCliente.Text += Factura.dniCliente;
                labelEmpresa.Text += Factura.cuitEmpresa + ", " + Factura.nombreEmpresa;
                labelIdFactura.Text += Factura.idFactura;
                labelFechaAlta.Text += Factura.fechaAlta;
                labelFechaVencimiento.Text += Factura.fechaVencimiento;
                labelTotal.Text += Factura.total;
            }
        }

        public override void Refrescar()
        {
            base.Refrescar();
            dataGridViewDetalleFactura.DataSource = dt;
        }

        internal DataGridView DataGridViewDetalleFactura
        {
            get
            {
                return dataGridViewDetalleFactura;
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                    Factura.detalleFactura = dt;
                    factura.guardarDetalle();
                    this.Close();
            }
            catch (SqlException) { }
            /*catch (Exception exception)
            {
                if (exception is FormatException ||
                    exception is CampoVacioException ||
                    exception is ValorNegativoException) Error.show(exception.Message);
                else throw;
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow item = dt.NewRow();
            item = new FacturaDetalleEditarForm(this,item).getItem();   // selecciono cliente
            if (item != null) dt.Rows.Add(item);
            Factura.total += Convert.ToDecimal(item["Monto"]);
            labelTotal.Text = "Total: " + Factura.total;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Factura.total -= Convert.ToDecimal(DataGridViewDetalleFactura.SelectedRows[0].DataGridView["Monto",0].Value);
            dt.Rows.RemoveAt((DataGridViewDetalleFactura.SelectedRows[0].Index));
            labelTotal.Text = "Total: " + Factura.total;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
