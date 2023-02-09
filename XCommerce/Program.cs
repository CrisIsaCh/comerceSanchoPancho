using Presentacion.Seguridad;
using System;
using System.Windows.Forms;
using XCommerce.Servicio.Seguridad.Acceso;
using XCommerce.Servicio.Seguridad.Usuario;

namespace XCommerce
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var fLogin = new Login(new AccesoSistema(), new UsuarioServicio());

            fLogin.ShowDialog();

            if (fLogin.PuedePasar)
            {
                Application.Run(new Principal());
            }
            else
            {
                Application.Exit();
            }
               
        }
    }
}
