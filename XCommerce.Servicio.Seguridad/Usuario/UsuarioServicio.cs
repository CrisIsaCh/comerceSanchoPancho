using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCommerce.AccesoDatos;

namespace XCommerce.Servicio.Seguridad.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        public void CambiarEstado(string nombreUsuario, bool estado)
        {
            using (var context = new ModeloXCommerceContainer())
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Nombre == nombreUsuario);
                if(usuario==null) throw new Exception("El Ususario no existe");
                usuario.EstaBloqueado = estado;
                context.SaveChanges();
            }
        }
    }
}
