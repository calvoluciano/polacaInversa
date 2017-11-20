using PagoAgilFrba.Modelo;
using PagoAgilFrba.Modelo.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class ItemEditarForm : ReturnForm
    {
        public ItemEditarForm()
        {
            InitializeComponent();
        }

        public ItemEditarForm(ReturnForm caller, DataRow item) : base(caller)
        {
            InitializeComponent();
            Item = item;
        }

        private DataRow item;

        private DataRow Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }

        private void validar()
        {
            if (decimal.Parse(textBoxCantidad.Text) <= 0) throw new ValorNegativoException("Cantidad");
            if (decimal.Parse(textBoxImporte.Text) <= 0) throw new ValorNegativoException("Monto");
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validar();
                item["Cantidad"] = int.Parse(textBoxCantidad.Text);
                Item["Monto"] = Decimal.Parse(textBoxImporte.Text);
                this.Close();
            }
            catch (Exception exception)
            {
                if (exception is FormatException ||
                    exception is CampoVacioException ||
                    exception is ValorNegativoException) Error.show(exception.Message);
                else throw;
            }
        }

        public DataRow getItem()
        {
            abrir();
            return Item;                  // devuelvo la sucursal seleccionada
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Item = null;
            this.Close();
        }
    }
}
