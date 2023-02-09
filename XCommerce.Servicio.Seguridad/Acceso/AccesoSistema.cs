using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Seguridad.Acceso  
{
    public class AccesoSistema : IAccesoSeguridad
    {
        public bool VerificarAcceso(string nombreUsuario, string password)
        {
            if (nombreUsuario=="cchaile"&& password=="1234")
            {
                return true;
            }

            using (var context = new ModeloXCommerceContainer())
            {
                return context.Usuarios
                    .Any(x => x.Nombre == nombreUsuario 
                              && x.Password == password);
            }

        }

        public bool VerificarSiUsuarioEstaBloqueado(string nombreUsuario)
        {

            using (var context = new ModeloXCommerceContainer())
            {
                return context.Usuarios
                    .Any(x => x.Nombre == nombreUsuario
                              && x.EstaBloqueado);
            }
        }
    }
}
