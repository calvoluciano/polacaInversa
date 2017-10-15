using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using PagoAgilFrba.Modelo;

namespace PagoAgilFrba
{
    static class Program
    {
        public static DateTime FechaEjecucion = DateTime.Parse(ConfigurationManager.AppSettings["FechaEjecucion"]);

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DB.miConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["PagoAgilFrba.Properties.Settings.GD2C2017ConnectionString"].ConnectionString);    // preparo conexion a base de datos
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UsuarioForm());
        }
    }
}
