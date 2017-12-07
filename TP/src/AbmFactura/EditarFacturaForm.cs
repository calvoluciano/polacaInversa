using PagoAgilFrba.AbmEmpresa;
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
    public partial class EditarFacturaForm : ReturnForm
    {
        public EditarFacturaForm()
        {
            InitializeComponent();
        }

        public EditarFacturaForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
            DataRow fila = cargarFila();
            facturaAEditar = new Factura(fila);

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("Monto", System.Type.GetType("System.Decimal")));
        }

        public EditarFacturaForm(ReturnForm caller, Factura factura) : base(caller)
        {
            InitializeComponent();
            Factura = factura;
            edicion = true;

            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("Monto", System.Type.GetType("System.Decimal")));

            Empresa = new Empresa(Empresa.getXsConFiltros("", factura.cuitEmpresa, "").Rows[0]);

            dt= Factura.getDetalle();
            textBoxNumeroFactura.ReadOnly = true;

            DataGridViewDetalleFactura.DataSource = dt;
        }

        private Factura facturaAEditar = null;
        private DataTable dt;
        private Boolean edicion = false;

        private Empresa empresa = null;

        public decimal DNICliente
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxDNICliente.Text)) return 0;

                return decimal.Parse(textBoxDNICliente.Text);
            }
            set
            {
                textBoxDNICliente.Text = value.ToString();
            }
        }

        public decimal idFactura
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxNumeroFactura.Text)) return 0;

                return decimal.Parse(textBoxNumeroFactura.Text);
            }
        }

        public Empresa Empresa
        {
            get
            {
                return empresa;
            }
            set
            {
                empresa = value;
                textBoxNombreEmpresa.Text = empresa.nombre;
            }
        }

        internal Factura Factura
        {
            get
            {
                return facturaAEditar;
            }
            set
            {
                facturaAEditar = value;
                textBoxDNICliente.Text = Factura.dniCliente.ToString();
                textBoxNombreEmpresa.Text = Factura.nombreEmpresa;
                textBoxNumeroFactura.Text = Factura.idFactura.ToString();
                dateTimePickerFechaAlta.Value = Factura.fechaAlta;
                dateTimePickerFechaVencimiento.Value = Factura.fechaVencimiento;
                labelTotal.Text += "Total: " + Factura.total;
                checkBoxHabilitado.Checked = Factura.habilitado;
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

        public Boolean CheckBoxHabilitado
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
                Factura.dniCliente = DNICliente;
                Factura.fechaAlta = FechaAlta;
                Factura.fechaVencimiento = FechaVencimiento;
                Factura.idEmpresa = Empresa.id;
                Factura.habilitado = CheckBoxHabilitado;
                Factura.detalleFactura = dt;
                if(edicion){
                    Factura.editar();
                }else{
                    Factura.idFactura = idFactura;
                    Factura.nuevo();
                }

                //Factura.guardarDetalle(); Esto paso a la clase Factura
                this.Close();
            }
            catch (SqlException) { }
            catch (Exception exception)
            {
                if (exception is FormatException
                    || exception is EmpresaNoSeleccionadaException
                    || exception is CampoVacioException
                    || exception is ExpireDateBeforeException
                    || exception is ClienteInexistenteException) Error.show(exception.Message);
                else throw;
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow item = dt.NewRow();
            item = new ItemEditarForm(this,item).getItem();   // selecciono cliente
            if (item != null)
            {
                dt.Rows.Add(item);
                //No se multiplica la cantidad
                //Factura.total += Convert.ToDecimal(item["Monto"]) * Convert.ToInt32(item["Cantidad"]);
                Factura.total += Convert.ToDecimal(item["Monto"]);
                labelTotal.Text = "Total: " + Factura.total;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow item = ((DataRowView)DataGridViewDetalleFactura.SelectedRows[0].DataBoundItem).Row;
            if (item != null)
            {
                //Factura.total -= Convert.ToDecimal(item["Monto"]) * Convert.ToInt32(item["Cantidad"]);
                //No se multiplica la cantidad
                Factura.total -= Convert.ToDecimal(item["Monto"]);
                dt.Rows.RemoveAt((DataGridViewDetalleFactura.SelectedRows[0].Index));
                labelTotal.Text = "Total: " + Factura.total;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validar()
        {
                if (string.IsNullOrWhiteSpace(textBoxDNICliente.Text)) throw new CampoVacioException("DNI Cliente");
                if (!Cliente.esClienteExistente(Convert.ToDecimal(textBoxDNICliente.Text))) throw new ClienteInexistenteException(textBoxDNICliente.Text);
                if (string.IsNullOrWhiteSpace(textBoxNumeroFactura.Text)) throw new CampoVacioException("Numero de Factura");
                if (Empresa == null) throw new EmpresaNoSeleccionadaException();    // valido los datos ingresados
                if (dateTimePickerFechaAlta == null) throw new CampoVacioException("Fecha de Alta");
                if (dateTimePickerFechaVencimiento == null) throw new CampoVacioException("Fecha de Vencimiento");
                if (FechaAlta > FechaVencimiento) throw new ExpireDateBeforeException("Corrija las fechas de alta con las de vencimiento. Fecha de alta debe ser anterior al vencimiento.");
                if (FechaVencimiento < System.DateTime.Today) throw new ExpireDateBeforeException("Corrija la fecha de vencimiento para que sea posterior a la fecha actual");
        }

        private void buttonSeleccionarEmpresa_Click(object sender, EventArgs e)
        {
            Empresa seleccionado = new SeleccionarEmpresaForm(this).getEmpresa();   // selecciono cliente
            if (seleccionado != null) Empresa = seleccionado;  
        }

        private DataRow cargarFila()
        {

            DataTable dt = new DataTable();
            DataRow fila = dt.NewRow();

            dt.Columns.Add(new DataColumn("ID_FACTURA", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("Nombre Empresa", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Cuit Empresa", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("Nombre Cliente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("DNI", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("Fecha Alta", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("Fecha Vencimiento", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("Total", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("HABILITADO", System.Type.GetType("System.Boolean")));

            fila["ID_FACTURA"] = DNICliente;
            fila["Nombre Empresa"] = "";
            fila["Cuit Empresa"] = 0;
            fila["Nombre Cliente"] = "";
            fila["DNI"] = DNICliente;
            fila["Fecha Alta"] = FechaAlta;
            fila["Fecha Vencimiento"] = FechaVencimiento;
            fila["Total"] = 0;
            fila["HABILITADO"] = CheckBoxHabilitado;

            return fila;

        }
    }
}
