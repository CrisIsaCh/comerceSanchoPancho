using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommerce.Servicio.Seguridad.Usuario
{
    public interface IUsuarioServicio
    {
        void CambiarEstado(string nombreUsuario, bool estado);


    }
}
