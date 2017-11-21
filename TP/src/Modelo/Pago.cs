using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Pago
    {
        public int idPago { get; set; }
        public List<Factura> facturas = new List<Factura>();
        public DateTime fechaCobro {get; set;}
        public Double total {get; set;}
        public int idCliente {get; set;}
        public int idSucursal {get; set;}
    

    public List<Factura> getFacturasAPagar()
    {
        return this.facturas;
    }

    public void agregarFacturaAPagar(Factura factura)
    {
        this.facturas.Add(factura);
    }

    public void aumentarImporteTotal(Double importeFactura)
    {
        this.total += importeFactura;
    }

    }
}
