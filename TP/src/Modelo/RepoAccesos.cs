using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public static class RepoAccesos
    {
        public static List<Acceso> repoAccesos = new List<Acceso>() { // creo una lista de los Accesos
            new Acceso(1, typeof(AbmRol.ABMRolForm)),
            new Acceso(2, typeof(AbmCliente.ABMClienteForm)),
            new Acceso(3, typeof(AbmEmpresa.ABMEmpresaForm)),
            new Acceso(4, typeof(AbmFactura.ABMFacturaForm)),
            new Acceso(5, typeof(AbmSucursal.ABMSucursalForm)),
            new Acceso(6, typeof(RegistroPago.RegistroPagoForm)),
            new Acceso(7, typeof(Rendicion.RendicionForm)),
            new Acceso(8, typeof(Devoluciones.DevolucionesForm)),
            new Acceso(9, typeof(ListadoEstadistico.ListadoEstadisticoForm))};

        public static Acceso get(byte idAcceso)                               // obtengo una funcionalidad
        {
            return repoAccesos.Find(f => f.id == idAcceso);
        }
    }
}
