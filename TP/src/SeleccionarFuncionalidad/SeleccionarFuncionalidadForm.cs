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

namespace PagoAgilFrba.SeleccionarFuncionalidad
{
    public partial class SeleccionarFuncionalidadForm : ReturnForm
    {
        public SeleccionarFuncionalidadForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
        }

        public override void Refrescar()
        {
            comboBox1.Items.Clear();                      // saco los items del combobox
            Rol.rolSeleccionado.getAccesos()                    // obtengo y cargo los nuevos
                .ForEach(f => comboBox1.Items.Add(f));
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)   // si hay una funcionalidad seleccionada...
            {
                Acceso accesoSeleccionado = (Acceso)comboBox1.SelectedItem;
                accesoSeleccionado.elegir(this);         // la elijo
            }
        }

        private void buttonAancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
