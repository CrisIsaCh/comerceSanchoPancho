using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Seguridad.Acceso
{
    public interface IAccesoSeguridad
    {
        bool VerificarAcceso(string nombreUsuario, string password);

        bool VerificarSiUsuarioEstaBloqueado(string nombreUsuario);


    }
}
