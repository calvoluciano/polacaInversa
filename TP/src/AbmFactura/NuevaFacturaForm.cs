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
using PagoAgilFrba.AbmEmpresa;
using PagoAgilFrba.Modelo.Exceptions;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmFactura
{
    public partial class NuevaFacturaForm : ReturnForm
    {
        public NuevaFacturaForm()
        {
            InitializeComponent();
        }
        public NuevaFacturaForm(ReturnForm caller) : base(caller)            
        {           
            InitializeComponent();
        }
        private Empresa empresa = null;


        public Empresa Empresa
        {
            get
            {
                return empresa;
            }
            set
            {
                empresa = value;
                textBoxCUITCliente.Text = empresa.nombre;
            }
        }
        public decimal DNICliente
        {
            get
            {
                return Convert.ToDecimal(textBoxDNICliente.Text);
            }
        }

        public decimal idFactura
        {
            get
            {
                return Convert.ToDecimal(textBoxNumeroFactura.Text);
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

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
             {
                if (string.IsNullOrWhiteSpace(textBoxDNICliente.Text)) throw new CampoVacioException("DNI Cliente");
                if (string.IsNullOrWhiteSpace(textBoxNumeroFactura.Text)) throw new CampoVacioException("Numero de Factura");
                if (Empresa == null) throw new EmpresaNoSeleccionadaException();    // valido los datos ingresados
                if (dateTimePickerFechaAlta == null) throw new CampoVacioException("Fecha de Alta");
                if (dateTimePickerFechaVencimiento == null) throw new CampoVacioException("Fecha de Vencimiento");
                if (FechaAlta > FechaVencimiento) throw new ExpireDateBeforeException("Corrija las fechas");
                else Factura.nuevo(DNICliente, idFactura, Empresa.id, FechaAlta, FechaVencimiento);          // persisto el nuevo chofer

                DataRow fila = cargarFila();

                new NuevaFacturaDetalle(this,new Factura(fila), false).abrir();
                this.Close();
             }
             catch (SqlException) { }
             catch (Exception exception)
             {
                 if (exception is FormatException 
                     || exception is EmpresaNoSeleccionadaException) Error.show(exception.Message);
                 else throw;
             } 
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

            dt.Columns.Add(new DataColumn("ID_FACTURA", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("Nombre Empresa", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Cuit Empresa", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("Nombre Cliente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("DNI", System.Type.GetType("System.Decimal")));
            dt.Columns.Add(new DataColumn("Fecha Alta", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("Fecha Vencimiento", System.Type.GetType("System.DateTime")));
            dt.Columns.Add(new DataColumn("Total", System.Type.GetType("System.Decimal")));

            fila["ID_FACTURA"] = textBoxNumeroFactura.Text;
            fila["Nombre Empresa"] = Empresa.nombre;
            fila["Cuit Empresa"] = Empresa.cuit;
            fila["Nombre Cliente"] = "";
            fila["DNI"] = textBoxDNICliente.Text;
            fila["Fecha Alta"] = dateTimePickerFechaAlta.Value;
            fila["Fecha Vencimiento"] = dateTimePickerFechaVencimiento.Value;
            fila["Total"] = 0;

            return fila;

        }

    }
}
