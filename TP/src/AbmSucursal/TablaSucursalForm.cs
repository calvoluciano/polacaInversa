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
using PagoAgilFrba.Modelo.Exceptions;


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
            CargarTabla();
            DataGridViewSucursal.Columns["ID_SUCURSAL"].Visible = false;  // oculto columna que no quiero mostrar
            //DataGridViewSucursal.Columns["Habilitado"].Visible = false; //  cambio nombre visible de columna
        }
        public DataGridView DataGridViewSucursal
        {
            get { return dataGridViewSucursal; }
        }
        public string Nombre
        {
            get
            {
                return textBoxNombre.Text;
            }
        }
        public string Direccion
        {
            get
            {
                return textBoxDireccion.Text;
            }
        }
        public Decimal Codigo_Postal
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxCodigoPostal.Text)) return 0;

                return Convert.ToDecimal(textBoxCodigoPostal.Text);
;
            }
        }
        protected virtual void CargarTabla()
        {
            dataGridViewSucursal.DataSource = Sucursal.getXsConFiltros( // obtengo las sucursales y las cargo en la tabla
                                                                        Nombre,
                                                                        Direccion,
                                                                        Codigo_Postal);
        }

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                validar();                                                                      // valido los datos ingresados
                CargarTabla();                                                                  // cargo la tabla
            }
            catch (Exception ex)
            {
                if (ex is FormatException || ex is ValorNegativoException) Error.show(ex.Message);
                else throw;
            }
        }

        private void validar()
        {
            if (Codigo_Postal < 0) throw new ValorNegativoException("Codigo Postal");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxDireccion.Text = "";
            textBoxCodigoPostal.Text = "";
        }
    }
}
