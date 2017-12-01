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

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class ListadoEstadisticoForm : PagoAgilFrba.Modelo.ReturnForm
    {
        DataTable tablaListado = new DataTable();

        public ListadoEstadisticoForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
            cargarTrimestres();
            comboBoxTrimestre.SelectedItem = 1;
            cargarOpcionesInformes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarTrimestres()
        {
            int i = 1;
            while (i <= 4)
            {
                comboBoxTrimestre.Items.Add(i);
                i++;
            }
        }

        private void cargarOpcionesInformes()
        {
            comboBoxInforme.Items.Add("Porcentaje de facturas cobradas por empresa");
            comboBoxInforme.Items.Add("Empresas con mayor monto rendido");
            comboBoxInforme.Items.Add("Clientes con mas pagos");
            comboBoxInforme.Items.Add("Clientes con mayor porcentaje de facturas pagadas");
            comboBoxInforme.SelectedIndex = -1;
        }

        public void actualizarGrid()
        {
            dataGridViewTablaInformes.DataSource = tablaListado;
        }

        private void comboBoxInforme_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxInforme.SelectedItem != null)
                inicializarTablaInforme(comboBoxInforme.SelectedIndex);
        }

        public void inicializarTablaInforme(int opcionListado)
        {
            tablaListado.Rows.Clear();
            tablaListado.Columns.Clear();

            if (opcionListado == 0)
            { // FacturasCobradasEmpresa

                tablaListado.Columns.Add("Empresa", typeof(string));
                tablaListado.Columns.Add("Facturas Totales", typeof(string));
                tablaListado.Columns.Add("Facturas Cobradas", typeof(string));
                tablaListado.Columns.Add("Porcentaje", typeof(string));
            }

            if (opcionListado == 1)
            { // EmpresaMontoRendido
                tablaListado.Columns.Add("Empresa", typeof(string));
                tablaListado.Columns.Add("Cantidad Rendiciones", typeof(string));
                tablaListado.Columns.Add("Monto Rendido", typeof(string));
            }

            if (opcionListado == 2)
            { // ClientesPagosTotales
                tablaListado.Columns.Add("DNI", typeof(string));
                tablaListado.Columns.Add("Apellido", typeof(string));
                tablaListado.Columns.Add("Nombre", typeof(string));
                tablaListado.Columns.Add("Mail", typeof(string));
                tablaListado.Columns.Add("Cantidad Pagos", typeof(string));
                tablaListado.Columns.Add("Monto Total de Pagos", typeof(string));
            }
            if (opcionListado == 3)
            { // ClientesProcentajePagos

                tablaListado.Columns.Add("Id Cliente", typeof(string));
                tablaListado.Columns.Add("DNI", typeof(string));
                tablaListado.Columns.Add("Apellido", typeof(string));
                tablaListado.Columns.Add("Nombre", typeof(string));
                tablaListado.Columns.Add("Mail", typeof(string));
                tablaListado.Columns.Add("Cantidad Facturas", typeof(string));
                tablaListado.Columns.Add("Cantidad Facturas Pagas", typeof(string));
                tablaListado.Columns.Add("Porcentaje Pago", typeof(string));
            }

            actualizarGrid();
        }

        private void buttonCargarFacturasPagas_Click(object sender, EventArgs e)
        {
            Trimestre trimestre = new Trimestre();
            trimestre.configurar(dateTimePickerAnio.Value.Year, (int)comboBoxTrimestre.SelectedItem);

            int cantidad = Convert.ToInt32(numericUpDownCantidadElementos.Value);

            if (comboBoxInforme.SelectedItem != null)
            {
                if (cantidad == 0) cantidad = 5;

                if (comboBoxInforme.SelectedIndex == 0)
                    tablaListado = Empresa.obtenerListadoEmpresas(trimestre.fecha_inicio, trimestre.fecha_fin, cantidad, "FACTURAS");

                if (comboBoxInforme.SelectedIndex == 1)
                    tablaListado = Empresa.obtenerListadoEmpresas(trimestre.fecha_inicio, trimestre.fecha_fin, cantidad, "RENDIDAS");

                if (comboBoxInforme.SelectedIndex == 2)
                    tablaListado = Cliente.obtenerListadoClientes(trimestre.fecha_inicio, trimestre.fecha_fin, cantidad, "TOTALES");

                if (comboBoxInforme.SelectedIndex == 3)
                    tablaListado = Cliente.obtenerListadoClientes(trimestre.fecha_inicio, trimestre.fecha_fin, cantidad, "PORCENTAJE");

                actualizarGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxInforme.SelectedIndex = -1;
            comboBoxTrimestre.SelectedIndex = 0;
            tablaListado.Rows.Clear();
            tablaListado.Columns.Clear();
        }
    }
}
