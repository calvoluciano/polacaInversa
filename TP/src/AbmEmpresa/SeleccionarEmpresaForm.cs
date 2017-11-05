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
    public partial class SeleccionarEmpresaForm : PagoAgilFrba.AbmEmpresa.TablaEmpresaForm
    {
        private Empresa empresaSeleccionada;

        public SeleccionarEmpresaForm(ReturnForm caller) : base(caller)
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            DataRow fila = ((DataRowView)DataGridViewEmpresas.SelectedRows[0].DataBoundItem).Row;    // obtengo la fila seleccionada

            if (!(Boolean)fila["ESTADO_EMPRESA"])    // si la sucursal no está habilitada...
            {
                Error.show("No se puede seleccionar una empresa inhabilitada.");
                return;
            }

            empresaSeleccionada = new Empresa(fila);      // creo una sucursal de la fila seleccionada
            this.Close();
        }

        public Empresa getEmpresa()
        {
            abrir();
            return empresaSeleccionada;                  // devuelvo la sucursal seleccionada
        }
    }
}
