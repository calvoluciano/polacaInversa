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

namespace PagoAgilFrba.SeleccionarRol
{
    public partial class SeleccionarRolForm : ReturnForm
    {
        private List<String> roles = new List<String>();

        public SeleccionarRolForm(ReturnForm caller)
            : base(caller)
        {
            InitializeComponent();
        }

        public override void Refrescar()
        {
            //comboBoxRoles.Items.Clear();                                    // saco los items del combobox
            //Usuario.getRoles().ForEach(r => comboBoxRoles.Items.Add(r));    // obtengo y agrego los nuevos
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
